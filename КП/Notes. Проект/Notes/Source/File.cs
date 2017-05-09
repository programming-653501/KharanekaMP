using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace Notes
{
    static class MyFile
    {
        /*Файл отвечает за сериализацию и десериализацию заметок*/
        public static void Save(List<Note> ls)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("Notelist.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, ls);
            }
        }

        public static List<Note> Open()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("Notelist.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    return (List<Note>)formatter.Deserialize(fs);
                }
                catch
                {
                    return null;
                }
            }
        }

        public static void SaveSettings(SettingsInfo settings)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("Settings.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, settings);
            }
        }

        public static SettingsInfo LoadSettings()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            SettingsInfo s = new SettingsInfo();
            using (FileStream fs = new FileStream("Settings.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    s = (SettingsInfo)formatter.Deserialize(fs);
                }
                catch
                {
                    return null;
                }
            }
            return s;
        }
    }
}
