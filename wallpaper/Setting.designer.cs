namespace wallpaper
{
    partial class Setting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.videoLabel = new System.Windows.Forms.Label();
            this.videoLocation = new System.Windows.Forms.TextBox();
            this.videoBrowser = new System.Windows.Forms.Button();
            this.wallpaperAutorun = new System.Windows.Forms.CheckBox();
            this.wallpaperMenu = new System.Windows.Forms.CheckBox();
            this.mpvAudio = new System.Windows.Forms.CheckBox();
            this.wallpaperLabel = new System.Windows.Forms.Label();
            this.mpvLabel = new System.Windows.Forms.Label();
            this.videoPanel = new System.Windows.Forms.Panel();
            this.settingOk = new System.Windows.Forms.Button();
            this.settingCancel = new System.Windows.Forms.Button();
            this.excludePanel = new System.Windows.Forms.Panel();
            this.excludeDelete = new System.Windows.Forms.Button();
            this.excludeAdd = new System.Windows.Forms.Button();
            this.excludeList = new System.Windows.Forms.ListBox();
            this.excludeLabel = new System.Windows.Forms.Label();
            this.settingPanel = new System.Windows.Forms.Panel();
            this.mpvPanel = new System.Windows.Forms.Panel();
            this.wallpaperPanel = new System.Windows.Forms.Panel();
            this.wallpaperExclude = new System.Windows.Forms.CheckBox();
            this.exitClose = new System.Windows.Forms.Button();
            this.exitClear = new System.Windows.Forms.Button();
            this.videoDialog = new System.Windows.Forms.OpenFileDialog();
            this.excludeDialog = new System.Windows.Forms.OpenFileDialog();
            this.videoPanel.SuspendLayout();
            this.excludePanel.SuspendLayout();
            this.settingPanel.SuspendLayout();
            this.mpvPanel.SuspendLayout();
            this.wallpaperPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // videoLabel
            // 
            this.videoLabel.AutoSize = true;
            this.videoLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.videoLabel.Location = new System.Drawing.Point(3, 8);
            this.videoLabel.Name = "videoLabel";
            this.videoLabel.Size = new System.Drawing.Size(82, 20);
            this.videoLabel.TabIndex = 0;
            this.videoLabel.Text = "videoLabel";
            // 
            // videoLocation
            // 
            this.videoLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.videoLocation.Location = new System.Drawing.Point(3, 42);
            this.videoLocation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.videoLocation.Name = "videoLocation";
            this.videoLocation.Size = new System.Drawing.Size(194, 23);
            this.videoLocation.TabIndex = 0;
            // 
            // videoBrowser
            // 
            this.videoBrowser.Location = new System.Drawing.Point(117, 4);
            this.videoBrowser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.videoBrowser.Name = "videoBrowser";
            this.videoBrowser.Size = new System.Drawing.Size(80, 30);
            this.videoBrowser.TabIndex = 0;
            this.videoBrowser.Text = "videoBrowser";
            this.videoBrowser.UseVisualStyleBackColor = true;
            this.videoBrowser.Click += new System.EventHandler(this.videoBrowser_Click);
            // 
            // wallpaperAutorun
            // 
            this.wallpaperAutorun.AutoSize = true;
            this.wallpaperAutorun.Location = new System.Drawing.Point(3, 27);
            this.wallpaperAutorun.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.wallpaperAutorun.Name = "wallpaperAutorun";
            this.wallpaperAutorun.Size = new System.Drawing.Size(130, 21);
            this.wallpaperAutorun.TabIndex = 0;
            this.wallpaperAutorun.Text = "wallpaperAutorun";
            this.wallpaperAutorun.UseVisualStyleBackColor = true;
            // 
            // wallpaperMenu
            // 
            this.wallpaperMenu.AutoSize = true;
            this.wallpaperMenu.Location = new System.Drawing.Point(3, 56);
            this.wallpaperMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.wallpaperMenu.Name = "wallpaperMenu";
            this.wallpaperMenu.Size = new System.Drawing.Size(117, 21);
            this.wallpaperMenu.TabIndex = 0;
            this.wallpaperMenu.Text = "wallpaperMenu";
            this.wallpaperMenu.UseVisualStyleBackColor = true;
            // 
            // mpvAudio
            // 
            this.mpvAudio.AutoSize = true;
            this.mpvAudio.Location = new System.Drawing.Point(3, 30);
            this.mpvAudio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mpvAudio.Name = "mpvAudio";
            this.mpvAudio.Size = new System.Drawing.Size(86, 21);
            this.mpvAudio.TabIndex = 0;
            this.mpvAudio.Text = "mpvAudio";
            this.mpvAudio.UseVisualStyleBackColor = true;
            // 
            // wallpaperLabel
            // 
            this.wallpaperLabel.AutoSize = true;
            this.wallpaperLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wallpaperLabel.Location = new System.Drawing.Point(3, 3);
            this.wallpaperLabel.Name = "wallpaperLabel";
            this.wallpaperLabel.Size = new System.Drawing.Size(111, 20);
            this.wallpaperLabel.TabIndex = 0;
            this.wallpaperLabel.Text = "wallpaperLabel";
            // 
            // mpvLabel
            // 
            this.mpvLabel.AutoSize = true;
            this.mpvLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mpvLabel.Location = new System.Drawing.Point(3, 6);
            this.mpvLabel.Name = "mpvLabel";
            this.mpvLabel.Size = new System.Drawing.Size(74, 20);
            this.mpvLabel.TabIndex = 0;
            this.mpvLabel.Text = "mpvLabel";
            // 
            // videoPanel
            // 
            this.videoPanel.Controls.Add(this.videoLabel);
            this.videoPanel.Controls.Add(this.videoLocation);
            this.videoPanel.Controls.Add(this.videoBrowser);
            this.videoPanel.Location = new System.Drawing.Point(12, 13);
            this.videoPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.videoPanel.Name = "videoPanel";
            this.videoPanel.Size = new System.Drawing.Size(200, 70);
            this.videoPanel.TabIndex = 0;
            // 
            // settingOk
            // 
            this.settingOk.Enabled = false;
            this.settingOk.Location = new System.Drawing.Point(291, 6);
            this.settingOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.settingOk.Name = "settingOk";
            this.settingOk.Size = new System.Drawing.Size(80, 30);
            this.settingOk.TabIndex = 0;
            this.settingOk.Text = "settingOk";
            this.settingOk.UseVisualStyleBackColor = true;
            this.settingOk.Click += new System.EventHandler(this.settingOk_Click);
            // 
            // settingCancel
            // 
            this.settingCancel.Location = new System.Drawing.Point(377, 6);
            this.settingCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.settingCancel.Name = "settingCancel";
            this.settingCancel.Size = new System.Drawing.Size(80, 30);
            this.settingCancel.TabIndex = 0;
            this.settingCancel.Text = "settingCancel";
            this.settingCancel.UseVisualStyleBackColor = true;
            this.settingCancel.Click += new System.EventHandler(this.settingCancel_Click);
            // 
            // excludePanel
            // 
            this.excludePanel.Controls.Add(this.excludeDelete);
            this.excludePanel.Controls.Add(this.excludeAdd);
            this.excludePanel.Controls.Add(this.excludeList);
            this.excludePanel.Controls.Add(this.excludeLabel);
            this.excludePanel.Enabled = false;
            this.excludePanel.Location = new System.Drawing.Point(222, 13);
            this.excludePanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.excludePanel.Name = "excludePanel";
            this.excludePanel.Size = new System.Drawing.Size(250, 247);
            this.excludePanel.TabIndex = 0;
            // 
            // excludeDelete
            // 
            this.excludeDelete.Location = new System.Drawing.Point(167, 4);
            this.excludeDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.excludeDelete.Name = "excludeDelete";
            this.excludeDelete.Size = new System.Drawing.Size(80, 30);
            this.excludeDelete.TabIndex = 0;
            this.excludeDelete.Text = "excludeDelete";
            this.excludeDelete.UseVisualStyleBackColor = true;
            this.excludeDelete.Click += new System.EventHandler(this.excludeDelete_Click);
            // 
            // excludeAdd
            // 
            this.excludeAdd.Location = new System.Drawing.Point(81, 4);
            this.excludeAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.excludeAdd.Name = "excludeAdd";
            this.excludeAdd.Size = new System.Drawing.Size(80, 30);
            this.excludeAdd.TabIndex = 0;
            this.excludeAdd.Text = "excludeAdd";
            this.excludeAdd.UseVisualStyleBackColor = true;
            this.excludeAdd.Click += new System.EventHandler(this.excludeAdd_Click);
            // 
            // excludeList
            // 
            this.excludeList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.excludeList.ItemHeight = 17;
            this.excludeList.Location = new System.Drawing.Point(3, 42);
            this.excludeList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.excludeList.Name = "excludeList";
            this.excludeList.Size = new System.Drawing.Size(244, 189);
            this.excludeList.Sorted = true;
            this.excludeList.TabIndex = 0;
            // 
            // excludeLabel
            // 
            this.excludeLabel.AutoSize = true;
            this.excludeLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.excludeLabel.Location = new System.Drawing.Point(3, 8);
            this.excludeLabel.Name = "excludeLabel";
            this.excludeLabel.Size = new System.Drawing.Size(97, 20);
            this.excludeLabel.TabIndex = 0;
            this.excludeLabel.Text = "excludeLabel";
            // 
            // settingPanel
            // 
            this.settingPanel.Controls.Add(this.exitClear);
            this.settingPanel.Controls.Add(this.exitClose);
            this.settingPanel.Controls.Add(this.settingCancel);
            this.settingPanel.Controls.Add(this.settingOk);
            this.settingPanel.Location = new System.Drawing.Point(12, 268);
            this.settingPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.settingPanel.Name = "settingPanel";
            this.settingPanel.Size = new System.Drawing.Size(460, 40);
            this.settingPanel.TabIndex = 0;
            // 
            // mpvPanel
            // 
            this.mpvPanel.Controls.Add(this.mpvLabel);
            this.mpvPanel.Controls.Add(this.mpvAudio);
            this.mpvPanel.Location = new System.Drawing.Point(12, 206);
            this.mpvPanel.Name = "mpvPanel";
            this.mpvPanel.Size = new System.Drawing.Size(200, 55);
            this.mpvPanel.TabIndex = 0;
            // 
            // wallpaperPanel
            // 
            this.wallpaperPanel.Controls.Add(this.wallpaperExclude);
            this.wallpaperPanel.Controls.Add(this.wallpaperLabel);
            this.wallpaperPanel.Controls.Add(this.wallpaperMenu);
            this.wallpaperPanel.Controls.Add(this.wallpaperAutorun);
            this.wallpaperPanel.Location = new System.Drawing.Point(12, 90);
            this.wallpaperPanel.Name = "wallpaperPanel";
            this.wallpaperPanel.Size = new System.Drawing.Size(200, 110);
            this.wallpaperPanel.TabIndex = 0;
            // 
            // wallpaperExclude
            // 
            this.wallpaperExclude.AutoSize = true;
            this.wallpaperExclude.Location = new System.Drawing.Point(3, 85);
            this.wallpaperExclude.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.wallpaperExclude.Name = "wallpaperExclude";
            this.wallpaperExclude.Size = new System.Drawing.Size(128, 21);
            this.wallpaperExclude.TabIndex = 0;
            this.wallpaperExclude.Text = "wallpaperExclude";
            this.wallpaperExclude.UseVisualStyleBackColor = true;
            this.wallpaperExclude.CheckedChanged += new System.EventHandler(this.wallpaperExclude_CheckedChanged);
            // 
            // exitClose
            // 
            this.exitClose.Location = new System.Drawing.Point(3, 6);
            this.exitClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exitClose.Name = "exitClose";
            this.exitClose.Size = new System.Drawing.Size(80, 30);
            this.exitClose.TabIndex = 0;
            this.exitClose.Text = "exitClose";
            this.exitClose.UseVisualStyleBackColor = true;
            this.exitClose.Click += new System.EventHandler(this.stopClose_Click);
            // 
            // exitClear
            // 
            this.exitClear.Enabled = false;
            this.exitClear.ForeColor = System.Drawing.Color.Red;
            this.exitClear.Location = new System.Drawing.Point(89, 6);
            this.exitClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exitClear.Name = "exitClear";
            this.exitClear.Size = new System.Drawing.Size(80, 30);
            this.exitClear.TabIndex = 0;
            this.exitClear.Text = "exitClear";
            this.exitClear.UseVisualStyleBackColor = true;
            this.exitClear.Click += new System.EventHandler(this.stopClear_Click);
            // 
            // videoDialog
            // 
            this.videoDialog.Filter = "mp4|*.mp4";
            // 
            // excludeDialog
            // 
            this.excludeDialog.Filter = "exe|*.exe";
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 321);
            this.Controls.Add(this.wallpaperPanel);
            this.Controls.Add(this.mpvPanel);
            this.Controls.Add(this.excludePanel);
            this.Controls.Add(this.settingPanel);
            this.Controls.Add(this.videoPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Setting_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Setting_FormClosing);
            this.Load += new System.EventHandler(this.Setting_Load);
            this.videoPanel.ResumeLayout(false);
            this.videoPanel.PerformLayout();
            this.excludePanel.ResumeLayout(false);
            this.excludePanel.PerformLayout();
            this.settingPanel.ResumeLayout(false);
            this.mpvPanel.ResumeLayout(false);
            this.mpvPanel.PerformLayout();
            this.wallpaperPanel.ResumeLayout(false);
            this.wallpaperPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label videoLabel;
        private System.Windows.Forms.TextBox videoLocation;
        private System.Windows.Forms.Button videoBrowser;
        private System.Windows.Forms.CheckBox wallpaperAutorun;
        private System.Windows.Forms.CheckBox wallpaperMenu;
        private System.Windows.Forms.CheckBox mpvAudio;
        private System.Windows.Forms.Label wallpaperLabel;
        private System.Windows.Forms.Label mpvLabel;
        private System.Windows.Forms.Panel videoPanel;
        private System.Windows.Forms.Button settingCancel;
        private System.Windows.Forms.Button settingOk;
        private System.Windows.Forms.Panel excludePanel;
        private System.Windows.Forms.Button excludeDelete;
        private System.Windows.Forms.Button excludeAdd;
        private System.Windows.Forms.ListBox excludeList;
        private System.Windows.Forms.Panel settingPanel;
        private System.Windows.Forms.Label excludeLabel;
        private System.Windows.Forms.Panel mpvPanel;
        private System.Windows.Forms.Panel wallpaperPanel;
        private System.Windows.Forms.Button exitClose;
        private System.Windows.Forms.Button exitClear;
        private System.Windows.Forms.CheckBox wallpaperExclude;
        private System.Windows.Forms.OpenFileDialog videoDialog;
        private System.Windows.Forms.OpenFileDialog excludeDialog;
    }
}