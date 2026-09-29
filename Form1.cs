using NAudio.Wave;
using SoundCore.CustomStructures;
using SoundCore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace SoundCore
{
    public partial class Form1 : Form
    {
        private readonly SinglyLinkedList<Track> _ownList = new SinglyLinkedList<Track>();
        private readonly LinkedListAdapter<Track> _linkedListNet = new LinkedListAdapter<Track>();
        private readonly ListTAdapter<Track> _listTNet = new ListTAdapter<Track>();
        private int _nextId = 1;

        private IWavePlayer _output;
        private WaveStream _reader;
        private bool _isPaused;
        private readonly ToolTip _tips = new ToolTip();

        private IDJStructure<Track> CurrentStructure =>
            radioButton2.Checked ? (IDJStructure<Track>)_linkedListNet :
            radioButton3.Checked ? (IDJStructure<Track>)_listTNet :
            (IDJStructure<Track>)_ownList;

        private IEnumerable<IDJStructure<Track>> AllStructures
        {
            get
            {
                yield return _ownList;
                yield return _linkedListNet;
                yield return _listTNet;
            }
        }

        public Form1()
        {
            InitializeComponent();
            Wire(btnAdd, btnAdd_Click);
            Wire(btnPlayNext, btnPlayNext_Click);
            Wire(btnNextTrack, btnNextTrack_Click);
            Wire(btnReverse, btnReverse_Click);
            Wire(button1, button1_Click);
            Wire(btnPurge, btnPurge_Click);
            Wire(btnBenchmark, btnBenchmark_Click);
     

            foreach (var rb in new[] { radioButton1, radioButton2, radioButton3 })
            {
                rb.CheckedChanged -= RbMode_CheckedChanged;
                rb.CheckedChanged += RbMode_CheckedChanged;
            }

            FormClosing += (s, e) => StopPlayback();

            Text = "SoundCore Engine v2.0 - DJ Set Controller [TecNM Monclova]";

            numBpm.Minimum = 1;
            numBpm.Maximum = 300;
            numBpm.Value = 124;
            numDuration.Minimum = 0;
            numDuration.Maximum = 36000;
            numDuration.Value = 210;

        
            _tips.SetToolTip(btnAdd, "Enqueue at End: adds the track typed above. If Title and Artist are empty, opens a dialog to import audio files.");
            _tips.SetToolTip(btnPlayNext, "Play Next: inserts the track typed above at position 2 (right after the one playing).");
            _tips.SetToolTip(btnNextTrack, "Advance Track: removes the first track of the queue.");
            _tips.SetToolTip(btnReverse, "Invert List (in-place).");
            _tips.SetToolTip(button1, "Order by BPM (ascending). Only visible if the BPM values are different.");
            _tips.SetToolTip(btnPurge, "Purge Duplicates: removes tracks with a repeated title, keeping the first.");
            _tips.SetToolTip(btnBenchmark, "Test 25,000 insertions in the 3 structures.");
            _tips.SetToolTip(txtTitle, "Title of the new track (needed by Enqueue and Play Next).");
            _tips.SetToolTip(txtArtist, "Artist of the new track (needed by Enqueue and Play Next).");
            _tips.SetToolTip(numBpm, "BPM of the new track.");
            _tips.SetToolTip(numDuration, "Duration in seconds of the new track.");

            LoadDemoData();
            RefreshUI();
        }

        private static void Wire(Button button, EventHandler handler)
        {
            button.Click -= handler;
            button.Click += handler;
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void LoadDemoData()
        {
            var demo = new[]
            {
                new Track(1, "Ghost Voices", "Virtual Self", 120, 240),
                new Track(2, "Opus", "Eric Prydz", 126, 540),
                new Track(3, "Language", "Porter Robinson", 128, 320),
            };
            _nextId = demo.Length + 1;

            foreach (var track in demo)
                AddToAllStructures(track);
        }

        private void AddToAllStructures(Track track)
        {
            foreach (var s in AllStructures)
                s.AddAtTheEnd(track);
        }

        private Track AdvanceAll()
        {
            Track removed = null;
            foreach (var s in AllStructures)
            {
                var t = s.AdvanceTrack();
                if (removed == null) removed = t;
            }
            return removed;
        }

        private void ReorderKeepingPlayback(Action change)
        {
            bool playing = _output != null && !_isPaused;
            var before = _ownList.ItIsEmpty ? null : _ownList.First;

            change();

            var after = _ownList.ItIsEmpty ? null : _ownList.First;
            if (before != after)
            {
                if (playing) PlayCurrent();
                else StopPlayback();
            }
        }

        private Track ReadForm()
        {
            var title = txtTitle.Text.Trim();
            var artist = txtArtist.Text.Trim();

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(artist))
            {
                MessageBox.Show(this, "You must provide a Title and Artist before continuing.",
                    "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            var track = new Track(_nextId, title, artist, (int)numBpm.Value, (int)numDuration.Value);
            _nextId++;
            return track;
        }

        private void ClearForm()
        {
            txtTitle.Clear();
            txtArtist.Clear();
            numBpm.Value = 124;
            numDuration.Value = 210;
            txtTitle.Focus();
        }

        private void RbMode_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && !rb.Checked) return;

            RefreshUI();
            SetStatus($"Mode: {GetActiveModeName()} (same tracks, different underlying structure)");
        }

        private void RefreshUI()
        {
            var structure = CurrentStructure;
            bool isArray = radioButton3.Checked;  

            var rows = structure
                .Select((track, index) => new
                {
                    Pos = index + 1,
                    Id = $"[{track.Id:D3}]",
                    Title = track.Title,
                    Artist = track.Artist,
                    Bpm = track.Bpm + " BPM",
                    Pointer = isArray
                        ? "idx " + index
                        : "0x" + (RuntimeHelpers.GetHashCode(track) & 0xFFFF).ToString("X4"),
                    Link = isArray
                        ? "[array]"
                        : (index == structure.Quantity - 1 ? "-> Null" : "-> Next")
                })
                .ToList();

            dgvPlaylist.DataSource = null;
            dgvPlaylist.DataSource = rows;
            dgvPlaylist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvPlaylist.Columns.Contains("Title")) dgvPlaylist.Columns["Title"].FillWeight = 200;
            if (dgvPlaylist.Columns.Contains("Artist")) dgvPlaylist.Columns["Artist"].FillWeight = 150;
            if (dgvPlaylist.Columns.Contains("Pos")) dgvPlaylist.Columns["Pos"].FillWeight = 50;

            string state = (_output != null && _isPaused) ? "Paused" : "Playing";
            lblPlaying.Text = structure.ItIsEmpty
                ? "▶ Playing: (empty queue)"
                : $"▶ {state}: \"{structure.First.Title}\" - {structure.First.Artist} ({structure.First.Bpm} BPM)";

            var total = TimeSpan.FromSeconds(structure.Sum(t => t.DurationSeconds));
            lblShow.Text =
                $"Active mode: {GetActiveModeName()}   |   Total in queue: {structure.Quantity} tracks   |   " +
                $"Total time: {(int)total.TotalMinutes:00}:{total.Seconds:00}";
        }

        private void SetStatus(string message) =>
            Text = "SoundCore Engine v2.0 - DJ Set Controller [TecNM Monclova]  |  " + message;

        private string GetActiveModeName() =>
            radioButton2.Checked ? ".NET LinkedList<T>" :
            radioButton3.Checked ? ".NET List<T>" :
            "Custom Singly Linked List (Nodes)";

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTitle.Text) || !string.IsNullOrWhiteSpace(txtArtist.Text))
            {
                var track = ReadForm();
                if (track is null) return;

                AddToAllStructures(track);
                ClearForm();
                RefreshUI();
                return;
            }

            ImportFromFiles();
        }

        private void btnPlayNext_Click(object sender, EventArgs e)
        {
            if (CurrentStructure.ItIsEmpty)
            {
                SetStatus("The playlist is empty.");
                return;
            }

            Track removed = AdvanceAll();

            if (removed != null)
            {
                RefreshUI();

                if (!CurrentStructure.ItIsEmpty)
                {
                    PlayCurrent();
                    SetStatus($"Play Next Song: \"{CurrentStructure.First.Title}\"");
                }
                else
                {
                    StopPlayback();
                    SetStatus("No more songs in the playlist.");
                }
            }

        }

        private void ImportFromFiles()
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "Select songs";
                dialog.Filter = "Audio files|*.mp3;*.wav;*.flac;*.m4a;*.wma|All files|*.*";
                dialog.Multiselect = true;
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

                if (dialog.ShowDialog(this) != DialogResult.OK) return;

                foreach (var path in dialog.FileNames)
                {
                    string title = Path.GetFileNameWithoutExtension(path);
                    string artist = "Unknown";
                    int bpm = (int)numBpm.Value;
                    int duration = 0;

                    try
                    {
                        using (var file = TagLib.File.Create(path))
                        {
                            if (!string.IsNullOrWhiteSpace(file.Tag.Title))
                                title = file.Tag.Title;
                            if (!string.IsNullOrWhiteSpace(file.Tag.FirstPerformer))
                                artist = file.Tag.FirstPerformer;
                            else if (!string.IsNullOrWhiteSpace(file.Tag.FirstAlbumArtist))
                                artist = file.Tag.FirstAlbumArtist;
                            if (file.Tag.BeatsPerMinute > 0)
                                bpm = (int)file.Tag.BeatsPerMinute;
                            duration = (int)file.Properties.Duration.TotalSeconds;
                        }
                    }
                    catch { /* unreadable tags: keep defaults */ }

                    if (artist == "Unknown")
                    {
                        var parts = Path.GetFileNameWithoutExtension(path).Split(new[] { " - " }, 2, StringSplitOptions.None);
                        if (parts.Length == 2 && !string.IsNullOrWhiteSpace(parts[0]) && !string.IsNullOrWhiteSpace(parts[1]))
                        {
                            artist = parts[0].Trim();
                            if (title == Path.GetFileNameWithoutExtension(path))
                                title = parts[1].Trim();
                        }
                    }

                    AddToAllStructures(new Track(_nextId++, title, artist, bpm, duration, path));
                }
            }

            RefreshUI();
        }

        private void btnNextTrack_Click(object sender, EventArgs e)
        {
            if (_ownList.ItIsEmpty)
            {
                MessageBox.Show(this, "The queue is empty. There is no track to advance.",
                    "Empty queue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool wasPlaying = _output != null;
            StopPlayback();

            var removed = AdvanceAll();

            if (wasPlaying && !_ownList.ItIsEmpty)
                PlayCurrent();

            RefreshUI();
            SetStatus($"Advance: \"{removed.Title}\" left the queue");

            if (!wasPlaying)
                MessageBox.Show(this, $"Now leaving the air: {removed}", "Track finished",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            ReorderKeepingPlayback(() =>
            {
                foreach (var s in AllStructures) s.Invert();
            });
            RefreshUI();
            SetStatus("Invert: list reversed in-place");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool alreadySorted = _ownList.Zip(_ownList.Skip(1), (a, b) => a.Bpm <= b.Bpm).All(ok => ok);

            ReorderKeepingPlayback(() =>
            {
                foreach (var s in AllStructures)
                    s.Order((a, b) => a.Bpm.CompareTo(b.Bpm));
            });
            RefreshUI();

            SetStatus(alreadySorted
                ? "Order by BPM: nothing changed (the list was already in ascending BPM order, or all BPM are equal)"
                : "Order by BPM: list sorted ascending");
        }

        private void btnPurge_Click(object sender, EventArgs e)
        {
          
            if (dgvPlaylist.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Selecciona una canción de la lista primero.",
                    "Eliminar canción",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int rowIndex = dgvPlaylist.SelectedRows[0].Index;

            if (rowIndex < 0 || rowIndex >= _ownList.Quantity)
                return;

            Track selectedTrack = _ownList.ElementAt(rowIndex);

            if (selectedTrack == null)
                return;

            DialogResult result = MessageBox.Show(
                $"¿Quieres eliminar esta canción?\n\n" +
                $"{selectedTrack.Title}\n" +
                $"{selectedTrack.Artist}",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            foreach (var structure in AllStructures)
            {
                structure.Remove(selectedTrack);
            }

            RefreshUI();

            SetStatus($"Canción eliminada: {selectedTrack.Title}");
        }
        

       

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (_output != null)
            {
                if (_isPaused) { _output.Play(); _isPaused = false; }
                else { _output.Pause(); _isPaused = true; }
            }
            else
            {
                PlayCurrent();
            }
            RefreshUI();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopPlayback();
            RefreshUI();
        }

        private void PlayCurrent()
        {
            StopPlayback();
            if (_ownList.ItIsEmpty) return;

            var track = _ownList.First;
            if (string.IsNullOrEmpty(track.FilePath) || !File.Exists(track.FilePath))
            {
                MessageBox.Show(this,
                    $"\"{track.Title}\" has no audio file (it was typed manually or is a demo track).\r\n" +
                    "Import songs with the Enqueue button while Title and Artist are empty.",
                    "Cannot play", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                _reader = CreateReader(track.FilePath);
                _output = new WaveOutEvent();
                _output.Init(_reader);
                _output.PlaybackStopped += Output_PlaybackStopped;
                _output.Play();
                _isPaused = false;
            }
            catch (Exception ex)
            {
                StopPlayback();
                MessageBox.Show(this, "Could not play the file:\r\n" + ex.Message,
                    "Playback error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static WaveStream CreateReader(string path)
        {
            try { return new AudioFileReader(path); }            
            catch { return new MediaFoundationReader(path); }    
        }

        private void Output_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            StopPlayback();

            if (_ownList.ItIsEmpty) { RefreshUI(); return; }

            AdvanceAll();
            if (!_ownList.ItIsEmpty)
                PlayCurrent();

            RefreshUI();
        }

        private void StopPlayback()
        {
            if (_output != null)
            {
                _output.PlaybackStopped -= Output_PlaybackStopped;
                _output.Stop();
                _output.Dispose();
                _output = null;
            }
            if (_reader != null)
            {
                _reader.Dispose();
                _reader = null;
            }
            _isPaused = false;
        }

        private void btnBenchmark_Click(object sender, EventArgs e)
        {
            const int totalTracks = 25_000;

            btnBenchmark.Enabled = false;
            txtBenchmar.Text = $"Running {totalTracks:N0} middle insertions on the 3 structures...\r\n";
            Application.DoEvents();

            long ownListMs = MeasureMiddleInsertions(new SinglyLinkedList<Track>(), totalTracks);
            long linkedListMs = MeasureMiddleInsertions(new LinkedListAdapter<Track>(), totalTracks);
            long listTMs = MeasureMiddleInsertions(new ListTAdapter<Track>(), totalTracks);

            txtBenchmar.AppendText(
                $"Custom List (Nodes)........ {ownListMs,6} ms  -> O(1): reconnects 2 references per insertion\r\n" +
                $".NET LinkedList<T>......... {linkedListMs,6} ms  -> O(1): native doubly linked nodes\r\n" +
                $".NET List<T>............... {listTMs,6} ms  -> O(n): Array.Copy on each middle insertion\r\n\r\n" +
                "Conclusion: linked lists only re-point references (no data is moved), so the cost is constant.\r\n" +
                "List<T> is an array: inserting at position 1 shifts every later element, so the cost grows with n.\r\n");

            btnBenchmark.Enabled = true;

            SetStatus($"Benchmark done: Custom {ownListMs} ms | LinkedList {linkedListMs} ms | List<T> {listTMs} ms");
            MessageBox.Show(this,
                $"{totalTracks:N0} middle insertions (position 2):\r\n\r\n" +
                $"Custom Singly Linked List:  {ownListMs} ms  (O(1))\r\n" +
                $".NET LinkedList<T>:  {linkedListMs} ms  (O(1))\r\n" +
                $".NET List<T>:  {listTMs} ms  (O(n), Array.Copy on every insertion)",
                "Benchmark results", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static long MeasureMiddleInsertions(IDJStructure<Track> structure, int totalTracks)
        {
            structure.AddAtTheEnd(new Track(0, "Seed", "N/A", 120, 180));

            var stopwatch = Stopwatch.StartNew();
            for (int i = 1; i <= totalTracks; i++)
                structure.PlayNext(new Track(i, $"Track {i}", "Bench", 100 + (i % 40), 200));
            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }
    }
}