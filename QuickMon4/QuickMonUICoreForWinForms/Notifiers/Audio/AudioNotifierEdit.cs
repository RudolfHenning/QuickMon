using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Notifiers
{
    public partial class AudioNotifierEdit : Form, IAgentConfigEntryEditWindow
    {
        public AudioNotifierEdit()
        {
            InitializeComponent();
        }

        public IAgentConfig SelectedEntry { get; set; }

        public QuickMonDialogResult ShowEditEntry()
        {
            LoadEditData();
            return (QuickMonDialogResult)ShowDialog();
        }

        private  void LoadEditData()
        {
            AudioNotifierConfig currentConfig;
            if (SelectedEntry != null)
            {
                currentConfig = (AudioNotifierConfig)SelectedEntry;
                chkGoodEnabled.Checked = currentConfig.GoodSoundSettings.Enabled;
                chkGoodUseSystemSounds.Checked = currentConfig.GoodSoundSettings.UseSystemSounds;
                txtGoodAudioFilePath.Text = currentConfig.GoodSoundSettings.AudioFilePath;
                cboGoodSystemSound.SelectedIndex = (int)currentConfig.GoodSoundSettings.SystemSound;
                try
                {
                    goodRepeatCountNumericUpDown.Value = currentConfig.GoodSoundSettings.SoundRepeatCount;
                }
                catch { }
                goodVolumePercTrackBar.Value = currentConfig.GoodSoundSettings.SoundVolumePerc;

                chkWarningEnabled.Checked = currentConfig.WarningSoundSettings.Enabled;
                chkWarningUseSystemSounds.Checked = currentConfig.WarningSoundSettings.UseSystemSounds;
                txtWarningAudioFilePath.Text = currentConfig.WarningSoundSettings.AudioFilePath;
                cboWarningSystemSound.SelectedIndex = (int)currentConfig.WarningSoundSettings.SystemSound;
                try
                {
                    warningRepeatCountNumericUpDown.Value = currentConfig.WarningSoundSettings.SoundRepeatCount;
                }
                catch { }
                warningVolumePercTrackBar.Value = currentConfig.WarningSoundSettings.SoundVolumePerc;

                chkErrorEnabled.Checked = currentConfig.ErrorSoundSettings.Enabled;
                chkErrorUseSystemSounds.Checked = currentConfig.ErrorSoundSettings.UseSystemSounds;
                txtErrorAudioFilePath.Text = currentConfig.ErrorSoundSettings.AudioFilePath;
                cboErrorSystemSound.SelectedIndex = (int)currentConfig.ErrorSoundSettings.SystemSound;
                try
                {
                    errorRepeatCountNumericUpDown.Value = currentConfig.ErrorSoundSettings.SoundRepeatCount;
                }
                catch { }
                errorVolumePercTrackBar.Value = currentConfig.ErrorSoundSettings.SoundVolumePerc;
            }
        }

        private void SetSoundSystemOrNot()
        {
            chkGoodUseSystemSounds.Enabled = chkGoodEnabled.Checked;
            txtGoodAudioFilePath.Enabled = chkGoodEnabled.Checked;
            txtGoodAudioFilePath.Visible = !chkGoodUseSystemSounds.Checked;
            cmdGoodBrowseAudioFile.Enabled = chkGoodEnabled.Checked;
            cmdGoodBrowseAudioFile.Visible = !chkGoodUseSystemSounds.Checked;
            cmdGoodTestSound.Enabled = chkGoodEnabled.Checked;
            cboGoodSystemSound.Enabled = chkGoodEnabled.Checked;
            cboGoodSystemSound.Visible = chkGoodUseSystemSounds.Checked;
            goodRepeatCountNumericUpDown.Enabled = chkGoodEnabled.Checked;
            goodVolumePercTrackBar.Enabled = chkGoodEnabled.Checked;

            chkWarningUseSystemSounds.Enabled = chkWarningEnabled.Checked;
            txtWarningAudioFilePath.Enabled = chkWarningEnabled.Checked;
            txtWarningAudioFilePath.Visible = !chkWarningUseSystemSounds.Checked;
            cmdWarningBrowseAudioFile.Enabled = chkWarningEnabled.Checked;
            cmdWarningBrowseAudioFile.Visible = !chkWarningUseSystemSounds.Checked;
            cmdWarningTestSound.Enabled = chkWarningEnabled.Checked;
            cboWarningSystemSound.Enabled = chkWarningEnabled.Checked;
            cboWarningSystemSound.Visible = chkWarningUseSystemSounds.Checked;
            warningRepeatCountNumericUpDown.Enabled = chkWarningEnabled.Checked;
            warningVolumePercTrackBar.Enabled = chkWarningEnabled.Checked;

            chkErrorUseSystemSounds.Enabled = chkErrorEnabled.Checked;
            txtErrorAudioFilePath.Enabled = chkErrorEnabled.Checked;
            txtErrorAudioFilePath.Visible = !chkErrorUseSystemSounds.Checked;
            cmdErrorBrowseAudioFile.Enabled = chkErrorEnabled.Checked;
            cmdErrorBrowseAudioFile.Visible = !chkErrorUseSystemSounds.Checked;
            cmdErrorTestSound.Enabled = chkErrorEnabled.Checked;
            cboErrorSystemSound.Enabled = chkErrorEnabled.Checked;
            cboErrorSystemSound.Visible = chkErrorUseSystemSounds.Checked;
            errorRepeatCountNumericUpDown.Enabled = chkErrorEnabled.Checked;
            errorVolumePercTrackBar.Enabled = chkErrorEnabled.Checked;
            CheckOKEnabled();
        }
        private void CheckOKEnabled()
        {
            cmdOK.Enabled = (chkGoodEnabled.Checked || chkWarningEnabled.Checked || chkErrorEnabled.Checked) &&
                    ((!chkGoodEnabled.Checked) || ((chkGoodUseSystemSounds.Checked && cboGoodSystemSound.SelectedIndex > -1) || (!chkGoodUseSystemSounds.Checked && txtGoodAudioFilePath.Text.Length > 0))) &&
                    ((!chkWarningEnabled.Checked) || ((chkWarningUseSystemSounds.Checked && cboWarningSystemSound.SelectedIndex > -1) || (!chkWarningUseSystemSounds.Checked && txtWarningAudioFilePath.Text.Length > 0))) &&
                    ((!chkErrorEnabled.Checked) || ((chkErrorUseSystemSounds.Checked && cboErrorSystemSound.SelectedIndex > -1) || (!chkErrorUseSystemSounds.Checked && txtErrorAudioFilePath.Text.Length > 0)));
        }

        private void AudioNotifierEdit_Load(object sender, EventArgs e)
        {
            
            SetSoundSystemOrNot();
        }
        private void cmdTestGoodSound_Click(object sender, EventArgs e)
        {
            try
            {
                AudioSetting audioSetting = new AudioSetting()
                {
                    Enabled = true,
                    AudioFilePath = txtGoodAudioFilePath.Text,
                    UseSystemSounds = chkGoodUseSystemSounds.Checked,
                    SoundRepeatCount = (int)goodRepeatCountNumericUpDown.Value,
                    SoundVolumePerc = goodVolumePercTrackBar.Value
                };
                if (chkGoodUseSystemSounds.Checked)
                    audioSetting.SystemSound = (SystemSounds)cboGoodSystemSound.SelectedIndex;
                else
                    audioSetting.AudioFilePath = txtGoodAudioFilePath.Text;
                backgroundWorker1.RunWorkerAsync(audioSetting);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmdTestWarningSound_Click(object sender, EventArgs e)
        {
            try
            {
                AudioSetting audioSetting = new AudioSetting()
                {
                    Enabled = true,
                    AudioFilePath = txtWarningAudioFilePath.Text,
                    UseSystemSounds = chkWarningUseSystemSounds.Checked,
                    SoundRepeatCount = (int)warningRepeatCountNumericUpDown.Value,
                    SoundVolumePerc = warningVolumePercTrackBar.Value
                };
                if (chkWarningUseSystemSounds.Checked)
                    audioSetting.SystemSound = (SystemSounds)cboWarningSystemSound.SelectedIndex;
                else
                    audioSetting.AudioFilePath = txtWarningAudioFilePath.Text;
                backgroundWorker1.RunWorkerAsync(audioSetting);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdTestErrorSound_Click(object sender, EventArgs e)
        {
            try
            {
                AudioSetting audioSetting = new AudioSetting()
                {
                    Enabled = true,
                    AudioFilePath = txtErrorAudioFilePath.Text,
                    UseSystemSounds = chkErrorUseSystemSounds.Checked,
                    SoundRepeatCount = (int)errorRepeatCountNumericUpDown.Value,
                    SoundVolumePerc = errorVolumePercTrackBar.Value
                };
                if (chkErrorUseSystemSounds.Checked)
                    audioSetting.SystemSound = (SystemSounds)cboErrorSystemSound.SelectedIndex;
                else
                    audioSetting.AudioFilePath = txtErrorAudioFilePath.Text;
                backgroundWorker1.RunWorkerAsync(audioSetting);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmdBrowseGoodSoundFile_Click(object sender, EventArgs e)
        {
            soundOpenFileDialog.FileName = txtGoodAudioFilePath.Text;
            if (txtGoodAudioFilePath.Text.Length > 0 && System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(txtGoodAudioFilePath.Text)))
            {
                soundOpenFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(txtGoodAudioFilePath.Text);
            }
            if (soundOpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtGoodAudioFilePath.Text = soundOpenFileDialog.FileName;
            }
        }
        private void cmdBrowseWarningSoundFile_Click(object sender, EventArgs e)
        {
            soundOpenFileDialog.FileName = txtWarningAudioFilePath.Text;
            if (txtWarningAudioFilePath.Text.Length > 0 && System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(txtWarningAudioFilePath.Text)))
            {
                soundOpenFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(txtWarningAudioFilePath.Text);
            }
            if (soundOpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtWarningAudioFilePath.Text = soundOpenFileDialog.FileName;
            }
        }
        private void cmdBrowseErrorSoundFile_Click(object sender, EventArgs e)
        {
            soundOpenFileDialog.FileName = txtErrorAudioFilePath.Text;
            if (txtErrorAudioFilePath.Text.Length > 0 && System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(txtErrorAudioFilePath.Text)))
            {
                soundOpenFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(txtErrorAudioFilePath.Text);
            }
            if (soundOpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtErrorAudioFilePath.Text = soundOpenFileDialog.FileName;
            }
        }

        private void triggerOKCheck(object sender, EventArgs e)
        {
            SetSoundSystemOrNot();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            AudioSetting audioSetting = (AudioSetting)e.Argument;
            if (audioSetting.UseSystemSounds)
                AudioNotifier.PlaySystemSound(audioSetting.SystemSound, audioSetting.SoundVolumePerc, audioSetting.SoundRepeatCount);
            else
                AudioNotifier.PlayCustomSound(audioSetting.AudioFilePath, audioSetting.SoundVolumePerc, audioSetting.SoundRepeatCount);
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                AudioNotifierConfig currentConfig;
                if (SelectedEntry == null)
                    SelectedEntry = new AudioNotifierConfig();
                currentConfig = (AudioNotifierConfig)SelectedEntry;

                if (chkGoodEnabled.Checked)
                {
                    if (chkGoodUseSystemSounds.Checked && cboGoodSystemSound.SelectedIndex < 0)
                    {
                        MessageBox.Show("You must specify a good system sound!");
                        cboGoodSystemSound.Focus();
                        return;
                    }
                    else if (!chkGoodUseSystemSounds.Checked && txtGoodAudioFilePath.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("You must specify a good sound!");
                        txtGoodAudioFilePath.Focus();
                        return;
                    }
                }
                if (chkWarningEnabled.Checked)
                {
                    if (chkWarningUseSystemSounds.Checked && cboWarningSystemSound.SelectedIndex < 0)
                    {
                        MessageBox.Show("You must specify a warning system sound!");
                        cboWarningSystemSound.Focus();
                        return;
                    }
                    else if (!chkWarningUseSystemSounds.Checked && txtWarningAudioFilePath.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("You must specify a warning sound!");
                        txtWarningAudioFilePath.Focus();
                        return;
                    }
                }
                if (chkErrorEnabled.Checked)
                {
                    if (chkErrorUseSystemSounds.Checked && cboErrorSystemSound.SelectedIndex < 0)
                    {
                        MessageBox.Show("You must specify an error system sound!");
                        cboErrorSystemSound.Focus();
                        return;
                    }
                    else if (!chkErrorUseSystemSounds.Checked && txtErrorAudioFilePath.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("You must specify an error sound!");
                        txtErrorAudioFilePath.Focus();
                        return;
                    }
                }

                currentConfig.GoodSoundSettings.Enabled = chkGoodEnabled.Checked;
                currentConfig.GoodSoundSettings.UseSystemSounds = chkGoodUseSystemSounds.Checked;
                currentConfig.GoodSoundSettings.AudioFilePath = txtGoodAudioFilePath.Text;
                currentConfig.GoodSoundSettings.SystemSound = (SystemSounds)cboGoodSystemSound.SelectedIndex;
                currentConfig.GoodSoundSettings.SoundRepeatCount = (int)goodRepeatCountNumericUpDown.Value;
                currentConfig.GoodSoundSettings.SoundVolumePerc = goodVolumePercTrackBar.Value;

                currentConfig.WarningSoundSettings.Enabled = chkWarningEnabled.Checked;
                currentConfig.WarningSoundSettings.UseSystemSounds = chkWarningUseSystemSounds.Checked;
                currentConfig.WarningSoundSettings.AudioFilePath = txtWarningAudioFilePath.Text;
                currentConfig.WarningSoundSettings.SystemSound = (SystemSounds)cboWarningSystemSound.SelectedIndex;
                currentConfig.WarningSoundSettings.SoundRepeatCount = (int)warningRepeatCountNumericUpDown.Value;
                currentConfig.WarningSoundSettings.SoundVolumePerc = warningVolumePercTrackBar.Value;

                currentConfig.ErrorSoundSettings.Enabled = chkErrorEnabled.Checked;
                currentConfig.ErrorSoundSettings.UseSystemSounds = chkErrorUseSystemSounds.Checked;
                currentConfig.ErrorSoundSettings.AudioFilePath = txtErrorAudioFilePath.Text;
                currentConfig.ErrorSoundSettings.SystemSound = (SystemSounds)cboErrorSystemSound.SelectedIndex;
                currentConfig.ErrorSoundSettings.SoundRepeatCount = (int)errorRepeatCountNumericUpDown.Value;
                currentConfig.ErrorSoundSettings.SoundVolumePerc = errorVolumePercTrackBar.Value;

                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
