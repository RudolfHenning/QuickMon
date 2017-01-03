using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace QuickMon.Notifiers
{
    [Description("Audio Notifier")]
    public class AudioNotifier : NotifierAgentBase
    {
        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);

        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        public AudioNotifier()
        {
            AgentConfig = new AudioNotifierConfig();
        }

        public override void RecordMessage(AlertRaised alertRaised)
        {
            if (AgentConfig != null)
            {
                AudioNotifierConfig config = (AudioNotifierConfig)AgentConfig;

                if (alertRaised.Level == AlertLevel.Info || alertRaised.Level == AlertLevel.Debug)
                {
                    if (config.GoodSoundSettings.Enabled)
                    {
                        PlaySoundForState(config.GoodSoundSettings);
                    }
                }
                else if (alertRaised.Level == AlertLevel.Warning)
                {
                    if (config.WarningSoundSettings.Enabled)
                    {
                        PlaySoundForState(config.WarningSoundSettings);
                    }
                }
                else if (alertRaised.Level == AlertLevel.Error)
                {
                    if (config.ErrorSoundSettings.Enabled)
                    {
                        PlaySoundForState(config.ErrorSoundSettings);
                    }
                }                
            }
        }

        public override AttendedOption AttendedRunOption { get { return AttendedOption.OnlyAttended; } }

        #region Play Sounds
        private void PlaySoundForState(AudioSetting audioSetting)
        {
            if (audioSetting.UseSystemSounds)
            {
                PlaySystemSound(audioSetting.SystemSound, audioSetting.SoundVolumePerc, audioSetting.SoundRepeatCount);
            }
            else
            {
                PlayCustomSound(audioSetting.AudioFilePath, audioSetting.SoundVolumePerc, audioSetting.SoundRepeatCount);
            }
        }
        public static void PlayCustomSound(string audioFilePath, int volumePerc, int repeats)
        {
            uint oldVolume;
            waveOutGetVolume(IntPtr.Zero, out oldVolume);
            if (audioFilePath.Length > 0 && System.IO.File.Exists(audioFilePath))
            {
                //if (CheckWMPInstalled())
                try
                {


                    // Calculate the volume that's being set. BTW: this is a trackbar!
                    int newVolume = ((ushort.MaxValue / 100) * volumePerc);
                    // Set the same volume for both the left and the right channels
                    uint newVolumeAllChannels = (((uint)newVolume & 0x0000ffff) | ((uint)newVolume << 16));
                    // Set the volume
                    waveOutSetVolume(IntPtr.Zero, newVolumeAllChannels);

                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(audioFilePath);
                    player.Play();

                    //WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
                    //if (volumePerc > -1)
                    //    wplayer.settings.volume = volumePerc;
                    //wplayer.settings.autoStart = false;
                    //wplayer.URL = audioFilePath;
                    //wplayer.controls.play();
                    //wplayer = null;
                    if (repeats > 1)
                        for (int i = 1; i < repeats; i++)
                        {
                            player.Play();
                            System.Threading.Thread.Sleep(500);
                            PlayCustomSound(audioFilePath, volumePerc, 1);
                        }
                }
                finally
                {
                    waveOutSetVolume(IntPtr.Zero, oldVolume);
                }
                
                //else
                //{
                //    throw new Exception("Notification cannot be raised! It appears Windows Media Player is not installed on this computer!");
                //}
            }
        }
        //public static bool CheckWMPInstalled()
        //{
        //    bool found = false;
        //    try
        //    {
        //        Microsoft.Win32.RegistryKey wmpKey = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Default).OpenSubKey(@"Software\Microsoft\MediaPlayer\PlayerUpgrade");
        //        string versionInfo = wmpKey.GetValue("PlayerVersion").ToString();
        //        if (versionInfo.Contains(","))
        //        {
        //            int majorVersion = int.Parse(versionInfo.Split(',')[0]);
        //            found = true;
        //        }
        //    }
        //    catch { }
        //    return found;
        //}
        public static void PlaySystemSound(SystemSounds systemSounds, int volumePerc, int repeats)
        {
            uint oldVolume;
            waveOutGetVolume(IntPtr.Zero, out oldVolume);
            // Calculate the volume that's being set. BTW: this is a trackbar!
            int newVolume = ((ushort.MaxValue / 100) * volumePerc);
            // Set the same volume for both the left and the right channels
            uint newVolumeAllChannels = (((uint)newVolume & 0x0000ffff) | ((uint)newVolume << 16));
            // Set the volume
            waveOutSetVolume(IntPtr.Zero, newVolumeAllChannels);

            try
            {
                System.Media.SystemSound ss;
                switch (systemSounds)
                {
                    case SystemSounds.Asterisk:
                        ss = System.Media.SystemSounds.Asterisk;
                        break;
                    case SystemSounds.Beep:
                        ss = System.Media.SystemSounds.Beep;
                        break;
                    case SystemSounds.Exclamation:
                        ss = System.Media.SystemSounds.Exclamation;
                        break;
                    case SystemSounds.Hand:
                        ss = System.Media.SystemSounds.Hand;
                        break;
                    case SystemSounds.Question:
                        ss = System.Media.SystemSounds.Question;
                        break;
                    default:
                        ss = System.Media.SystemSounds.Exclamation;
                        break;
                }
                ss.Play();
                if (repeats > 1)
                    for (int i = 1; i < repeats; i++)
                    {
                        System.Threading.Thread.Sleep(500);
                        PlaySystemSound(systemSounds, volumePerc, 1);
                    }
            }
            finally
            {
                waveOutSetVolume(IntPtr.Zero, oldVolume);
            }
        }
        #endregion
    }
}
