using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Notifiers
{
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
                "<goodState enabled=\"false\" useSystemSounds=\"true\" soundPath=\"\" systemSound=\"1\" soundRepeatCount=\"1\" soundVolumePerc=\"-1\" />\r\n" +
                "<warningState enabled=\"true\" useSystemSounds=\"true\" soundPath=\"\" systemSound=\"3\" soundRepeatCount=\"1\" soundVolumePerc=\"-1\" />\r\n" +
                "<errorState enabled=\"true\" useSystemSounds=\"true\" soundPath=\"\" systemSound=\"2\" soundRepeatCount=\"1\" soundVolumePerc=\"-1\" />\r\n" +
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
