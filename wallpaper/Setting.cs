using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace wallpaper
{
    public partial class Setting : Form
    {
        bool isChanged = false;

        public Setting()
        {
            InitializeComponent();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            if (!RegistryEdit.CheckSetting())
            {
                Initialize();
            }
            LoadText();
            LoadSetting();
            LoadCheck();
        }

        private void Initialize()
        {
            RegistryEdit.SetSetting(videoLocation.Name, string.Empty);
            RegistryEdit.SetSetting(wallpaperAutorun.Name, false.ToString());
            RegistryEdit.SetSetting(wallpaperMenu.Name, false.ToString());
            RegistryEdit.SetSetting(wallpaperExclude.Name, false.ToString());
            RegistryEdit.SetSetting(waitLabel.Name, 250.ToString());
            RegistryEdit.SetSetting(mpvSwdec.Name, false.ToString());
            RegistryEdit.SetSetting(mpvAudio.Name, false.ToString());
        }

        private void LoadText()
        {
            Language.GetText(this);
            Language.GetText(videoLabel);
            Language.GetText(videoBrowser);
            Language.GetText(wallpaperLabel);
            Language.GetText(wallpaperAutorun);
            Language.GetText(wallpaperMenu);
            Language.GetText(wallpaperExclude);
            Language.GetText(waitLabel);
            Language.GetText(mpvLabel);
            Language.GetText(mpvSwdec);
            Language.GetText(mpvAudio);
            Language.GetText(stopExit);
            Language.GetText(stopClear);
            Language.GetText(excludeLabel);
            Language.GetText(excludeAdd);
            Language.GetText(excludeDelete);
            Language.GetText(settingOk);
            Language.GetText(settingCancel);
        }

        private void LoadSetting()
        {
            videoLocation.Text = RegistryEdit.GetSetting(videoLocation.Name);
            wallpaperAutorun.Checked = Convert.ToBoolean(RegistryEdit.GetSetting(wallpaperAutorun.Name));
            wallpaperMenu.Checked = Convert.ToBoolean(RegistryEdit.GetSetting(wallpaperMenu.Name));
            wallpaperExclude.Checked = Convert.ToBoolean(RegistryEdit.GetSetting(wallpaperExclude.Name));
            string wait = RegistryEdit.GetSetting(waitLabel.Name);
            if (wait == wait5H.Text)
            {
                wait5H.Checked = true;
            }
            else if (wait == wait1K.Text)
            {
                wait1K.Checked = true;
            }
            else
            {
                wait2K.Checked = true;
            }
            mpvSwdec.Checked = Convert.ToBoolean(RegistryEdit.GetSetting(mpvSwdec.Name));
            mpvAudio.Checked = Convert.ToBoolean(RegistryEdit.GetSetting(mpvAudio.Name));
            for (int i = 0; i < int.MaxValue; i++)
            {
                try
                {
                    string item = RegistryEdit.GetExcludeList(i.ToString());
                    excludeList.Items.Add(item);
                }
                catch (Exception)
                {
                    break;
                }
            }
        }

        private void LoadCheck()
        {
            videoLocation.TextChanged += Changed;
            wallpaperAutorun.CheckedChanged += Changed;
            wallpaperMenu.CheckedChanged += Changed;
            wallpaperExclude.CheckedChanged += Changed;
            wait5H.CheckedChanged += Changed;
            wait1K.CheckedChanged += Changed;
            wait2K.CheckedChanged += Changed;
            mpvSwdec.CheckedChanged += Changed;
            mpvAudio.CheckedChanged += Changed;
        }

        private void Changed(object sender, EventArgs e)
        {
            settingOk.Enabled = true;
            isChanged = true;
        }

        private void videoBrowser_Click(object sender, EventArgs e)
        {
            if (videoDialog.ShowDialog() == DialogResult.OK)
            {
                videoLocation.Text = videoDialog.FileName;
            }
        }

        private void wallpaperExclude_CheckedChanged(object sender, EventArgs e)
        {
            if (wallpaperExclude.Checked == true)
            {
                excludePanel.Enabled = true;
            }
            else
            {
                excludePanel.Enabled = false;
            }
        }

        private void excludeAdd_Click(object sender, EventArgs e)
        {
            if (excludeDialog.ShowDialog() == DialogResult.OK)
            {
                excludeList.Items.Add(Path.GetFileNameWithoutExtension(excludeDialog.FileName));
                Changed(null, null);
            }
        }

        private void excludeDelete_Click(object sender, EventArgs e)
        {
            excludeList.Items.Remove(excludeList.SelectedItem);
            Changed(null, null);
        }

        private void stopClose_Click(object sender, EventArgs e)
        {
            Process[] process = Process.GetProcesses();
            foreach (var item in process)
            {
                if (item.ProcessName == "wallpaper" && item.MainWindowHandle != Handle)
                {
                    item.Kill();
                }
            }
            Wallpaper.Stop();
            DisableAll();
            Close();
        }

        private void stopClear_Click(object sender, EventArgs e)
        {
            string warning = Language.GetString("warning");
            string stopMessage = Language.GetString("stopMessage");
            DialogResult dialogResult = MessageBox.Show(stopMessage, warning, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK)
            {
                RegistryEdit.RemoveAutorun();
                RegistryEdit.RemoveDesktopMenu();
                RegistryEdit.RemoveSetting();
                Process[] process = Process.GetProcesses();
                foreach (var item in process)
                {
                    if (item.ProcessName == "wallpaper" && item.MainWindowHandle != Handle)
                    {
                        item.Kill();
                    }
                }
                Wallpaper.Stop();
                DisableAll();
                string information = Language.GetString("information");
                string done = Language.GetString("done");
                MessageBox.Show(done, information, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void DisableAll()
        {
            videoPanel.Enabled = false;
            wallpaperPanel.Enabled = false;
            waitPanel.Enabled = false;
            mpvPanel.Enabled = false;
            stopPanel.Enabled = false;
            excludePanel.Enabled = false;
            settingPanel.Enabled = false;
            isChanged = false;
        }

        private void settingOk_Click(object sender, EventArgs e)
        {
            RegistryEdit.SetSetting(videoLocation.Name, videoLocation.Text);
            if (wallpaperAutorun.Checked)
            {
                RegistryEdit.SetAutorun();
            }
            else
            {
                RegistryEdit.RemoveAutorun();
            }
            RegistryEdit.SetSetting(wallpaperAutorun.Name, wallpaperAutorun.Checked.ToString());
            if (wallpaperMenu.Checked)
            {
                RegistryEdit.SetDesktopMenu();
            }
            else
            {
                RegistryEdit.RemoveDesktopMenu();
            }
            RegistryEdit.SetSetting(wallpaperMenu.Name, wallpaperMenu.Checked.ToString());
            if (wait5H.Checked)
            {
                RegistryEdit.SetSetting(waitLabel.Name, wait5H.Text);
            }
            else if (wait1K.Checked)
            {
                RegistryEdit.SetSetting(waitLabel.Name, wait1K.Text);
            }
            else
            {
                RegistryEdit.SetSetting(waitLabel.Name, wait2K.Text);
            }
            RegistryEdit.SetSetting(mpvSwdec.Name, mpvSwdec.Checked.ToString());
            RegistryEdit.SetSetting(mpvAudio.Name, mpvAudio.Checked.ToString());
            if (excludeList.Items.Count == 0)
            {
                wallpaperExclude.Checked = false;
                RegistryEdit.RemoveExcludeList();
            }
            else
            {
                RegistryEdit.RemoveExcludeList();
                for (int i = 0; i < excludeList.Items.Count; i++)
                {
                    RegistryEdit.SetExcludeList(i.ToString(), excludeList.Items[i].ToString());
                }
            }
            RegistryEdit.SetSetting(wallpaperExclude.Name, wallpaperExclude.Checked.ToString());
            Wallpaper.Stop();
            DisableAll();
            Close();
        }

        private void settingCancel_Click(object sender, EventArgs e)
        {
            DisableAll();
            Close();
        }

        private void Setting_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            stopClear.Enabled = true;
            e.Cancel = true;
        }

        private void Setting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isChanged)
            {
                string information = Language.GetString("information");
                string closeMessage = Language.GetString("closeMessage");
                DialogResult dialogResult = MessageBox.Show(closeMessage, information, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dialogResult != DialogResult.OK)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
