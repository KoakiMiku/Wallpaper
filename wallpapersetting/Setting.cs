using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace wallpapersetting
{
    public partial class Setting : Form
    {
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
            RegistryEdit.SetSetting(excludeList.Name, string.Empty);
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
            Language.GetText(exitClose);
            Language.GetText(exitClear);
            Language.GetText(excludeLabel);
            Language.GetText(excludeAdd);
            Language.GetText(excludeDelete);
            Language.GetText(settingOk);
            Language.GetText(settingCancel);
            videoDialog.Filter = Language.GetString("videoFilter");
            excludeDialog.Filter = Language.GetString("excludeFilter");
        }

        private void LoadSetting()
        {
            videoLocation.Text = RegistryEdit.GetSetting(videoLocation.Name);
            wallpaperAutorun.Checked = Convert.ToBoolean(RegistryEdit.GetSetting(wallpaperAutorun.Name));
            wallpaperMenu.Checked = Convert.ToBoolean(RegistryEdit.GetSetting(wallpaperMenu.Name));
            wallpaperExclude.Checked = Convert.ToBoolean(RegistryEdit.GetSetting(wallpaperExclude.Name));
            if (!string.IsNullOrWhiteSpace(RegistryEdit.GetSetting(excludeList.Name)))
            {
                excludeList.Items.AddRange(RegistryEdit.GetSetting(excludeList.Name).Split('|'));
            }
        }

        private void LoadCheck()
        {
            videoLocation.TextChanged += Changed;
            wallpaperAutorun.CheckedChanged += Changed;
            wallpaperMenu.CheckedChanged += Changed;
            wallpaperExclude.CheckedChanged += Changed;
        }

        private void Changed(object sender, EventArgs e)
        {
            settingOk.Enabled = true;
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
            Wallpaper.Stop();
            settingOk.Enabled = false;
            Close();
        }

        private void stopClear_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(Language.GetString("exitMessage"), Language.GetString("warning"),
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK)
            {
                RegistryEdit.RemoveAutorun();
                RegistryEdit.RemoveDesktopMenu();
                RegistryEdit.RemoveSetting();
                Wallpaper.Stop();
                MessageBox.Show(Language.GetString("exitDone"), Language.GetString("information"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                settingOk.Enabled = false;
                Close();
            }
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
            if (excludeList.Items.Count == 0)
            {
                wallpaperExclude.Checked = false;
                RegistryEdit.SetSetting(excludeList.Name, string.Empty);
            }
            else
            {
                string exclude = string.Join("|", excludeList.Items.Cast<string>());
                RegistryEdit.SetSetting(excludeList.Name, exclude);
            }
            RegistryEdit.SetSetting(wallpaperExclude.Name, wallpaperExclude.Checked.ToString());
            Wallpaper.Restart();
            settingOk.Enabled = false;
            Close();
        }

        private void settingCancel_Click(object sender, EventArgs e)
        {
            settingOk.Enabled = false;
            Close();
        }

        private void Setting_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            exitClear.Enabled = true;
            e.Cancel = true;
        }

        private void Setting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (settingOk.Enabled)
            {
                DialogResult dialogResult = MessageBox.Show(Language.GetString("closeMessage"), Language.GetString("information"),
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dialogResult != DialogResult.OK)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
