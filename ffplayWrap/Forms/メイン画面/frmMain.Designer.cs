namespace ffplayWrap
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnStart = new Button();
            btnStop = new Button();
            btnSeekMinus10 = new Button();
            PlayListView = new cctlPlayListView();
            btnSeekPlus10 = new Button();
            btnSeekMinus60 = new Button();
            btnSeekPlus60 = new Button();
            btnVolUp = new Button();
            btnVolDn = new Button();
            btnMute = new Button();
            btnPause = new Button();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(43, 38);
            btnStart.Margin = new Padding(4);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(114, 48);
            btnStart.TabIndex = 0;
            btnStart.Text = "起動";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(191, 38);
            btnStop.Margin = new Padding(4);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(114, 48);
            btnStop.TabIndex = 0;
            btnStop.Text = "停止";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnSeekMinus10
            // 
            btnSeekMinus10.Location = new Point(105, 388);
            btnSeekMinus10.Name = "btnSeekMinus10";
            btnSeekMinus10.Size = new Size(80, 48);
            btnSeekMinus10.TabIndex = 1;
            btnSeekMinus10.Text = "-10秒";
            btnSeekMinus10.UseVisualStyleBackColor = true;
            btnSeekMinus10.Click += btnSeekMinus10_Click;
            // 
            // PlayListView
            // 
            PlayListView.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PlayListView.Location = new Point(18, 105);
            PlayListView.Name = "PlayListView";
            PlayListView.Size = new Size(419, 277);
            PlayListView.TabIndex = 2;
            PlayListView.UseCompatibleStateImageBehavior = false;
            PlayListView.View = View.Details;
            // 
            // btnSeekPlus10
            // 
            btnSeekPlus10.Location = new Point(225, 388);
            btnSeekPlus10.Name = "btnSeekPlus10";
            btnSeekPlus10.Size = new Size(80, 48);
            btnSeekPlus10.TabIndex = 1;
            btnSeekPlus10.Text = "+10秒";
            btnSeekPlus10.UseVisualStyleBackColor = true;
            btnSeekPlus10.Click += btnSeekPlus10_Click;
            // 
            // btnSeekMinus60
            // 
            btnSeekMinus60.Location = new Point(18, 388);
            btnSeekMinus60.Name = "btnSeekMinus60";
            btnSeekMinus60.Size = new Size(80, 48);
            btnSeekMinus60.TabIndex = 1;
            btnSeekMinus60.Text = "-60秒";
            btnSeekMinus60.UseVisualStyleBackColor = true;
            btnSeekMinus60.Click += btnSeekMinus60_Click;
            // 
            // btnSeekPlus60
            // 
            btnSeekPlus60.Location = new Point(345, 388);
            btnSeekPlus60.Name = "btnSeekPlus60";
            btnSeekPlus60.Size = new Size(80, 48);
            btnSeekPlus60.TabIndex = 1;
            btnSeekPlus60.Text = "+60秒";
            btnSeekPlus60.UseVisualStyleBackColor = true;
            btnSeekPlus60.Click += btnSeekPlus60_Click;
            // 
            // btnVolUp
            // 
            btnVolUp.Location = new Point(472, 218);
            btnVolUp.Name = "btnVolUp";
            btnVolUp.Size = new Size(80, 48);
            btnVolUp.TabIndex = 1;
            btnVolUp.Text = "+ VOL";
            btnVolUp.UseVisualStyleBackColor = true;
            btnVolUp.Click += btnVolUp_Click;
            // 
            // btnVolDn
            // 
            btnVolDn.Location = new Point(472, 283);
            btnVolDn.Name = "btnVolDn";
            btnVolDn.Size = new Size(80, 48);
            btnVolDn.TabIndex = 1;
            btnVolDn.Text = "- VOL";
            btnVolDn.UseVisualStyleBackColor = true;
            btnVolDn.Click += btnVolDn_Click;
            // 
            // btnMute
            // 
            btnMute.Location = new Point(472, 337);
            btnMute.Name = "btnMute";
            btnMute.Size = new Size(80, 48);
            btnMute.TabIndex = 1;
            btnMute.Text = "Mute";
            btnMute.UseVisualStyleBackColor = true;
            btnMute.Click += btnMute_Click;
            // 
            // btnPause
            // 
            btnPause.Location = new Point(453, 391);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(80, 48);
            btnPause.TabIndex = 1;
            btnPause.Text = "Pause";
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += btnPause_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(693, 478);
            Controls.Add(PlayListView);
            Controls.Add(btnSeekPlus60);
            Controls.Add(btnPause);
            Controls.Add(btnMute);
            Controls.Add(btnVolDn);
            Controls.Add(btnVolUp);
            Controls.Add(btnSeekPlus10);
            Controls.Add(btnSeekMinus60);
            Controls.Add(btnSeekMinus10);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "frmMain";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnStart;
        private Button btnStop;
        private Button btnSeekMinus10;
        private cctlPlayListView PlayListView;
        private Button btnSeekPlus10;
        private Button btnSeekMinus60;
        private Button btnSeekPlus60;
        private Button btnVolUp;
        private Button btnVolDn;
        private Button btnMute;
        private Button btnPause;
    }
}