using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

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

    public class AudioNotifierConfig : INotifierConfig
    {
        public AudioNotifierConfig()
        {
            GoodSoundSettings = new AudioSetting() { Enabled = false, UseSystemSounds = true };
            WarningSoundSettings = new AudioSetting() { Enabled = true, UseSystemSounds = true, SystemSound = SystemSounds.Exclamation };
            ErrorSoundSettings = new AudioSetting() { Enabled = true, UseSystemSounds = true, SystemSound = SystemSounds.Hand };
        }
        public AudioSetting GoodSoundSettings { get; set; }
        public AudioSetting WarningSoundSettings { get; set; }
        public AudioSetting ErrorSoundSettings { get; set; }

        #region INotifierConfig Members
        public void FromXml(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            XmlElement root = config.DocumentElement;
            XmlNode audioConfigNode = root.SelectSingleNode("audioConfig");

            XmlNode goodState = audioConfigNode.SelectSingleNode("goodState");
            if (goodState != null)
            {
                GoodSoundSettings.Enabled = goodState.ReadXmlElementAttr("enabled", false);
                GoodSoundSettings.UseSystemSounds = goodState.ReadXmlElementAttr("useSystemSounds", false);
                GoodSoundSettings.AudioFilePath = goodState.ReadXmlElementAttr("audioFilePath", "");
                GoodSoundSettings.SystemSound = (SystemSounds)goodState.ReadXmlElementAttr("systemSound", 1);
                GoodSoundSettings.SoundRepeatCount = goodState.ReadXmlElementAttr("repeatCount", 1);
                GoodSoundSettings.SoundVolumePerc = goodState.ReadXmlElementAttr("soundVolumePerc", -1);
            }
            XmlNode warningState = audioConfigNode.SelectSingleNode("warningState");
            if (warningState != null)
            {
                WarningSoundSettings.Enabled = warningState.ReadXmlElementAttr("enabled", false);
                WarningSoundSettings.UseSystemSounds = warningState.ReadXmlElementAttr("useSystemSounds", false);
                WarningSoundSettings.AudioFilePath = warningState.ReadXmlElementAttr("audioFilePath", "");
                WarningSoundSettings.SystemSound = (SystemSounds)warningState.ReadXmlElementAttr("systemSound", 2);
                WarningSoundSettings.SoundRepeatCount = warningState.ReadXmlElementAttr("repeatCount", 1);
                WarningSoundSettings.SoundVolumePerc = warningState.ReadXmlElementAttr("soundVolumePerc", -1);
            }
            XmlNode errorState = audioConfigNode.SelectSingleNode("errorState");
            if (errorState != null)
            {
                ErrorSoundSettings.Enabled = errorState.ReadXmlElementAttr("enabled", false);
                ErrorSoundSettings.UseSystemSounds = errorState.ReadXmlElementAttr("useSystemSounds", false);
                ErrorSoundSettings.AudioFilePath = errorState.ReadXmlElementAttr("audioFilePath", "");
                ErrorSoundSettings.SystemSound = (SystemSounds)errorState.ReadXmlElementAttr("systemSound", 3);
                ErrorSoundSettings.SoundRepeatCount = errorState.ReadXmlElementAttr("repeatCount", 1);
                ErrorSoundSettings.SoundVolumePerc = errorState.ReadXmlElementAttr("soundVolumePerc", -1);
            }
        }

        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlNode audioConfigNode = config.SelectSingleNode("config/audioConfig");

            XmlNode goodState = audioConfigNode.SelectSingleNode("goodState");
            goodState.SetAttributeValue("enabled", GoodSoundSettings.Enabled);
            goodState.SetAttributeValue("useSystemSounds", GoodSoundSettings.UseSystemSounds);
            goodState.SetAttributeValue("audioFilePath", GoodSoundSettings.AudioFilePath);
            goodState.SetAttributeValue("systemSound", (int)GoodSoundSettings.SystemSound);
            goodState.SetAttributeValue("repeatCount", GoodSoundSettings.SoundRepeatCount);
            goodState.SetAttributeValue("soundVolumePerc", GoodSoundSettings.SoundVolumePerc);

            XmlNode warningState = audioConfigNode.SelectSingleNode("warningState");
            warningState.SetAttributeValue("enabled", WarningSoundSettings.Enabled);
            warningState.SetAttributeValue("useSystemSounds", WarningSoundSettings.UseSystemSounds);
            warningState.SetAttributeValue("audioFilePath", WarningSoundSettings.AudioFilePath);
            warningState.SetAttributeValue("systemSound", (int)WarningSoundSettings.SystemSound);
            warningState.SetAttributeValue("repeatCount", WarningSoundSettings.SoundRepeatCount);
            warningState.SetAttributeValue("soundVolumePerc", WarningSoundSettings.SoundVolumePerc);

            XmlNode errorState = audioConfigNode.SelectSingleNode("errorState");
            errorState.SetAttributeValue("enabled", ErrorSoundSettings.Enabled);
            errorState.SetAttributeValue("useSystemSounds", ErrorSoundSettings.UseSystemSounds);
            errorState.SetAttributeValue("audioFilePath", ErrorSoundSettings.AudioFilePath);
            errorState.SetAttributeValue("systemSound", (int)ErrorSoundSettings.SystemSound);
            errorState.SetAttributeValue("repeatCount", ErrorSoundSettings.SoundRepeatCount);
            errorState.SetAttributeValue("soundVolumePerc", ErrorSoundSettings.SoundVolumePerc);
            return config.OuterXml;
        }

        public string GetDefaultOrEmptyXml()
        {
            return "<config>\r\n" +
              "<audioConfig>\r\n" +
                "<goodState enabled=\"false\" useSystemSounds=\"true\" soundPath=\"\" systemSound=\"1\" repeatCount=\"1\" soundVolumePerc=\"-1\" />\r\n" +
                "<warningState enabled=\"true\" useSystemSounds=\"true\" soundPath=\"\" systemSound=\"3\" repeatCount=\"1\" soundVolumePerc=\"-1\" />\r\n" +
                "<errorState enabled=\"true\" useSystemSounds=\"true\" soundPath=\"\" systemSound=\"2\" repeatCount=\"1\" soundVolumePerc=\"-1\" />\r\n" +
              "</audioConfig>\r\n" +
            "</config>";
        }

        public string ConfigSummary
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (GoodSoundSettings.Enabled)
                {
                    sb.Append("Good: ");
                    if (GoodSoundSettings.UseSystemSounds)
                        sb.Append(((SystemSounds)GoodSoundSettings.SystemSound).ToString());
                    else
                        sb.Append(System.IO.Path.GetFileName(GoodSoundSettings.AudioFilePath));
                    if (GoodSoundSettings.SoundRepeatCount > 1 && GoodSoundSettings.SoundVolumePerc > -1)
                        sb.Append(" (" + GoodSoundSettings.SoundRepeatCount.ToString() + ", v" + GoodSoundSettings.SoundVolumePerc.ToString() + "%)");
                    else if (GoodSoundSettings.SoundRepeatCount > 1)
                        sb.Append(" (" + GoodSoundSettings.SoundRepeatCount.ToString() + ")");
                    else if (GoodSoundSettings.SoundVolumePerc > -1)
                        sb.Append(" ( v" + GoodSoundSettings.SoundVolumePerc.ToString() + "%)");
                }
                if (WarningSoundSettings.Enabled)
                {
                    sb.Append(", Warning: ");
                    if (WarningSoundSettings.UseSystemSounds)
                        sb.Append(((SystemSounds)WarningSoundSettings.SystemSound).ToString());
                    else
                        sb.Append(System.IO.Path.GetFileName(WarningSoundSettings.AudioFilePath));
                    if (WarningSoundSettings.SoundRepeatCount > 1 && WarningSoundSettings.SoundVolumePerc > -1)
                        sb.Append(" (" + WarningSoundSettings.SoundRepeatCount.ToString() + ", v" + WarningSoundSettings.SoundVolumePerc.ToString() + "%)");
                    else if (WarningSoundSettings.SoundRepeatCount > 1)
                        sb.Append(" (" + WarningSoundSettings.SoundRepeatCount.ToString() + ")");
                    else if (WarningSoundSettings.SoundVolumePerc > -1)
                        sb.Append(" ( v" + WarningSoundSettings.SoundVolumePerc.ToString() + "%)");
                }
                if (ErrorSoundSettings.Enabled)
                {
                    sb.Append(", Error: ");
                    if (ErrorSoundSettings.UseSystemSounds)
                        sb.Append(((SystemSounds)ErrorSoundSettings.SystemSound).ToString());
                    else
                        sb.Append(System.IO.Path.GetFileName(ErrorSoundSettings.AudioFilePath));
                    if (ErrorSoundSettings.SoundRepeatCount > 1 && ErrorSoundSettings.SoundVolumePerc > -1)
                        sb.Append(" (" + ErrorSoundSettings.SoundRepeatCount.ToString() + ", v" + ErrorSoundSettings.SoundVolumePerc.ToString() + "%)");
                    else if (ErrorSoundSettings.SoundRepeatCount > 1)
                        sb.Append(" (" + ErrorSoundSettings.SoundRepeatCount.ToString() + ")");
                    else if (ErrorSoundSettings.SoundVolumePerc > -1)
                        sb.Append(" ( v" + ErrorSoundSettings.SoundVolumePerc.ToString() + "%)");
                }
                return sb.ToString().Trim(',', ' ');
            }
        }
        #endregion
    }

    public enum SystemSounds
    {
        Asterisk,
        Beep,
        Exclamation,
        Hand,
        Question
    }

    public class AudioSetting
    {
        public bool Enabled { get; set; }
        public bool UseSystemSounds { get; set; }
        public string AudioFilePath { get; set; }
        public SystemSounds SystemSound { get; set; }
        public int SoundRepeatCount { get; set; }
        public int SoundVolumePerc { get; set; }
    }
}
