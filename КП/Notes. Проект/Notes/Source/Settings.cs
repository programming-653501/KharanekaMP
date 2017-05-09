using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
    [Serializable]
    class SettingsInfo : ISerializable
    {
        public static bool Transparency { get; set; }
        public static bool OnTop { get; set; }
        public static bool InTaskbar { get; set; }
        

        public SettingsInfo()
        {

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("static.Transparency", SettingsInfo.Transparency, typeof(bool));
            info.AddValue("static.OnTop", SettingsInfo.OnTop, typeof(bool));
            info.AddValue("static.InTaskbar", SettingsInfo.InTaskbar, typeof(bool));
        }

        public SettingsInfo(SerializationInfo info, StreamingContext context)
        {
            SettingsInfo.Transparency = info.GetBoolean("static.Transparency");
            SettingsInfo.OnTop = info.GetBoolean("static.OnTop");
            SettingsInfo.InTaskbar = info.GetBoolean("static.InTaskbar");
        }
    }
}
