namespace SoundCore
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.grbRegistration = new System.Windows.Forms.GroupBox();
            this.grbBENCHMARKTELEMETRÍA = new System.Windows.Forms.GroupBox();
            this.grbLIVEpLAYLIST = new System.Windows.Forms.GroupBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblArtist = new System.Windows.Forms.Label();
            this.lblBpm = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblCustom = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtArtist = new System.Windows.Forms.TextBox();
            this.numBpm = new System.Windows.Forms.NumericUpDown();
            this.numDuration = new System.Windows.Forms.NumericUpDown();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.lblNET = new System.Windows.Forms.Label();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.lblList = new System.Windows.Forms.Label();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnPlayNext = new System.Windows.Forms.Button();
            this.btnNextTrack = new System.Windows.Forms.Button();
            this.btnBenchmark = new System.Windows.Forms.Button();
            this.btnPurge = new System.Windows.Forms.Button();
            this.btnReverse = new System.Windows.Forms.Button();
            this.lblPlaying = new System.Windows.Forms.Label();
            this.dgvPlaylist = new System.Windows.Forms.DataGridView();
            this.txtBenchmar = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblShow = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numBpm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlaylist)).BeginInit();
            this.SuspendLayout();
            // 
            // grbRegistration
            // 
            this.grbRegistration.Location = new System.Drawing.Point(14, 45);
            this.grbRegistration.Name = "grbRegistration";
            this.grbRegistration.Size = new System.Drawing.Size(196, 53);
            this.grbRegistration.TabIndex = 0;
            this.grbRegistration.TabStop = false;
            this.grbRegistration.Text = "Registration";
            // 
            // grbBENCHMARKTELEMETRÍA
            // 
            this.grbBENCHMARKTELEMETRÍA.Location = new System.Drawing.Point(14, 197);
            this.grbBENCHMARKTELEMETRÍA.Name = "grbBENCHMARKTELEMETRÍA";
            this.grbBENCHMARKTELEMETRÍA.Size = new System.Drawing.Size(196, 53);
            this.grbBENCHMARKTELEMETRÍA.TabIndex = 1;
            this.grbBENCHMARKTELEMETRÍA.TabStop = false;
            this.grbBENCHMARKTELEMETRÍA.Text = "BENCHMARK TELEMETRÍA";
            // 
            // grbLIVEpLAYLIST
            // 
            this.grbLIVEpLAYLIST.Location = new System.Drawing.Point(339, 197);
            this.grbLIVEpLAYLIST.Name = "grbLIVEpLAYLIST";
            this.grbLIVEpLAYLIST.Size = new System.Drawing.Size(196, 53);
            this.grbLIVEpLAYLIST.TabIndex = 1;
            this.grbLIVEpLAYLIST.TabStop = false;
            this.grbLIVEpLAYLIST.Text = "LIVE PLAYLIST";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(251, 43);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(53, 24);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Title:";
            // 
            // lblArtist
            // 
            this.lblArtist.AutoSize = true;
            this.lblArtist.Location = new System.Drawing.Point(464, 45);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(62, 24);
            this.lblArtist.TabIndex = 3;
            this.lblArtist.Text = "Artist:";
            // 
            // lblBpm
            // 
            this.lblBpm.AutoSize = true;
            this.lblBpm.Location = new System.Drawing.Point(702, 43);
            this.lblBpm.Name = "lblBpm";
            this.lblBpm.Size = new System.Drawing.Size(55, 24);
            this.lblBpm.TabIndex = 4;
            this.lblBpm.Text = "BPM:";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(942, 48);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(90, 24);
            this.lblDuration.TabIndex = 5;
            this.lblDuration.Text = "Duration:";
            // 
            // lblCustom
            // 
            this.lblCustom.AutoSize = true;
            this.lblCustom.Location = new System.Drawing.Point(143, 125);
            this.lblCustom.Name = "lblCustom";
            this.lblCustom.Size = new System.Drawing.Size(226, 24);
            this.lblCustom.TabIndex = 6;
            this.lblCustom.Text = "Custom Singly Linked List";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(310, 43);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(133, 31);
            this.txtTitle.TabIndex = 7;
            // 
            // txtArtist
            // 
            this.txtArtist.Location = new System.Drawing.Point(526, 45);
            this.txtArtist.Name = "txtArtist";
            this.txtArtist.Size = new System.Drawing.Size(149, 31);
            this.txtArtist.TabIndex = 8;
            // 
            // numBpm
            // 
            this.numBpm.Location = new System.Drawing.Point(774, 45);
            this.numBpm.Name = "numBpm";
            this.numBpm.Size = new System.Drawing.Size(140, 31);
            this.numBpm.TabIndex = 9;
            // 
            // numDuration
            // 
            this.numDuration.Location = new System.Drawing.Point(1034, 45);
            this.numDuration.Name = "numDuration";
            this.numDuration.Size = new System.Drawing.Size(140, 31);
            this.numDuration.TabIndex = 10;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(383, 125);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(81, 28);
            this.radioButton1.TabIndex = 11;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Node";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(700, 125);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(21, 20);
            this.radioButton2.TabIndex = 13;
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // lblNET
            // 
            this.lblNET.AutoSize = true;
            this.lblNET.Location = new System.Drawing.Point(510, 128);
            this.lblNET.Name = "lblNET";
            this.lblNET.Size = new System.Drawing.Size(177, 24);
            this.lblNET.TabIndex = 12;
            this.lblNET.Text = ".NET LinkedList<T>";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(882, 125);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(21, 20);
            this.radioButton3.TabIndex = 15;
            this.radioButton3.TabStop = true;
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // lblList
            // 
            this.lblList.AutoSize = true;
            this.lblList.Location = new System.Drawing.Point(752, 125);
            this.lblList.Name = "lblList";
            this.lblList.Size = new System.Drawing.Size(121, 24);
            this.lblList.TabIndex = 14;
            this.lblList.Text = ".NET List<T>";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(97, 125);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(21, 20);
            this.radioButton4.TabIndex = 17;
            this.radioButton4.TabStop = true;
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 24);
            this.label5.TabIndex = 16;
            this.label5.Text = "Mode";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(14, 269);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(108, 38);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnPlayNext
            // 
            this.btnPlayNext.Image = ((System.Drawing.Image)(resources.GetObject("btnPlayNext.Image")));
            this.btnPlayNext.Location = new System.Drawing.Point(14, 310);
            this.btnPlayNext.Name = "btnPlayNext";
            this.btnPlayNext.Size = new System.Drawing.Size(108, 38);
            this.btnPlayNext.TabIndex = 19;
            this.btnPlayNext.UseVisualStyleBackColor = true;
            this.btnPlayNext.Click += new System.EventHandler(this.btnPlayNext_Click);
            // 
            // btnNextTrack
            // 
            this.btnNextTrack.Image = ((System.Drawing.Image)(resources.GetObject("btnNextTrack.Image")));
            this.btnNextTrack.Location = new System.Drawing.Point(14, 352);
            this.btnNextTrack.Name = "btnNextTrack";
            this.btnNextTrack.Size = new System.Drawing.Size(108, 38);
            this.btnNextTrack.TabIndex = 20;
            this.btnNextTrack.UseVisualStyleBackColor = true;
            this.btnNextTrack.Click += new System.EventHandler(this.btnNextTrack_Click);
            // 
            // btnBenchmark
            // 
            this.btnBenchmark.Location = new System.Drawing.Point(278, 522);
            this.btnBenchmark.Name = "btnBenchmark";
            this.btnBenchmark.Size = new System.Drawing.Size(108, 38);
            this.btnBenchmark.TabIndex = 23;
            this.btnBenchmark.Text = "Benchmark";
            this.btnBenchmark.UseVisualStyleBackColor = true;
            this.btnBenchmark.Click += new System.EventHandler(this.btnBenchmark_Click);
            // 
            // btnPurge
            // 
            this.btnPurge.Image = ((System.Drawing.Image)(resources.GetObject("btnPurge.Image")));
            this.btnPurge.Location = new System.Drawing.Point(14, 443);
            this.btnPurge.Name = "btnPurge";
            this.btnPurge.Size = new System.Drawing.Size(108, 38);
            this.btnPurge.TabIndex = 22;
            this.btnPurge.UseVisualStyleBackColor = true;
            this.btnPurge.Click += new System.EventHandler(this.btnPurge_Click);
            // 
            // btnReverse
            // 
            this.btnReverse.Image = ((System.Drawing.Image)(resources.GetObject("btnReverse.Image")));
            this.btnReverse.Location = new System.Drawing.Point(14, 400);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(108, 38);
            this.btnReverse.TabIndex = 21;
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // lblPlaying
            // 
            this.lblPlaying.AutoSize = true;
            this.lblPlaying.Location = new System.Drawing.Point(350, 253);
            this.lblPlaying.Name = "lblPlaying";
            this.lblPlaying.Size = new System.Drawing.Size(73, 24);
            this.lblPlaying.TabIndex = 24;
            this.lblPlaying.Text = "Playing";
            // 
            // dgvPlaylist
            // 
            this.dgvPlaylist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlaylist.Location = new System.Drawing.Point(339, 294);
            this.dgvPlaylist.Name = "dgvPlaylist";
            this.dgvPlaylist.RowHeadersWidth = 62;
            this.dgvPlaylist.RowTemplate.Height = 28;
            this.dgvPlaylist.Size = new System.Drawing.Size(738, 209);
            this.dgvPlaylist.TabIndex = 25;
            // 
            // txtBenchmar
            // 
            this.txtBenchmar.Location = new System.Drawing.Point(397, 526);
            this.txtBenchmar.Name = "txtBenchmar";
            this.txtBenchmar.Size = new System.Drawing.Size(177, 31);
            this.txtBenchmar.TabIndex = 26;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(14, 487);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 38);
            this.button1.TabIndex = 27;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblShow
            // 
            this.lblShow.AutoSize = true;
            this.lblShow.Location = new System.Drawing.Point(601, 533);
            this.lblShow.Name = "lblShow";
            this.lblShow.Size = new System.Drawing.Size(293, 24);
            this.lblShow.TabIndex = 28;
            this.lblShow.Text = "-> Shows results and justification";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 633);
            this.Controls.Add(this.lblShow);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtBenchmar);
            this.Controls.Add(this.dgvPlaylist);
            this.Controls.Add(this.lblPlaying);
            this.Controls.Add(this.btnBenchmark);
            this.Controls.Add(this.btnPurge);
            this.Controls.Add(this.btnReverse);
            this.Controls.Add(this.btnNextTrack);
            this.Controls.Add(this.btnPlayNext);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.lblList);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.lblNET);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.numDuration);
            this.Controls.Add(this.numBpm);
            this.Controls.Add(this.txtArtist);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblCustom);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblBpm);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grbLIVEpLAYLIST);
            this.Controls.Add(this.grbBENCHMARKTELEMETRÍA);
            this.Controls.Add(this.grbRegistration);
            this.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numBpm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlaylist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbRegistration;
        private System.Windows.Forms.GroupBox grbBENCHMARKTELEMETRÍA;
        private System.Windows.Forms.GroupBox grbLIVEpLAYLIST;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.Label lblBpm;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblCustom;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtArtist;
        private System.Windows.Forms.NumericUpDown numBpm;
        private System.Windows.Forms.NumericUpDown numDuration;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label lblNET;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Label lblList;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnPlayNext;
        private System.Windows.Forms.Button btnNextTrack;
        private System.Windows.Forms.Button btnBenchmark;
        private System.Windows.Forms.Button btnPurge;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.Label lblPlaying;
        private System.Windows.Forms.DataGridView dgvPlaylist;
        private System.Windows.Forms.TextBox txtBenchmar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblShow;
    }
}

