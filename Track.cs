namespace SoundCore.Models
{
    
    public sealed class Track
    {
        public int Id { get; }
        public string Title { get; }
        public string Artist { get; }
        public int Bpm { get; }
        public int DurationSeconds { get; }
        public string FilePath { get; }
        public Track(int id, string title, string artist, int bpm, int durationSeconds, string filePath = null)
        {
            Id = id;
            Title = title;
            Artist = artist;
            Bpm = bpm;
            DurationSeconds = durationSeconds;
            FilePath = filePath;
        }

        public override string ToString() =>
            $"[{Id:D3}] {Title} - {Artist} | {Bpm} BPM";
    }
}