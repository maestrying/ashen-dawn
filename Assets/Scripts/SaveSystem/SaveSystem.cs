using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void Save<T>(string key, T savedata)
    {
        string path = Application.persistentDataPath + "/" + key + ".bin";

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, savedata);
        stream.Close();
    }

    public static T Load<T>(string key) where T : new()
    {
        string path = Application.persistentDataPath + "/" + key + ".bin";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            T data = (T)formatter.Deserialize(stream);
            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("File not found: " + path);
            return new T();
        }
    }
    
    public static void DeleteAllData()
    {
        string path = Application.persistentDataPath;

        foreach (var file in Directory.GetFiles(path))
        {
            File.Delete(file);
        }
    }
}
