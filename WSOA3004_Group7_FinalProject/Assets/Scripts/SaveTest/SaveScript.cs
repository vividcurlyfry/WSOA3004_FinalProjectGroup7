using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveScript
{
    public static void SaveSquare(Square square)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/square.hopeitworks";
        FileStream stream = new FileStream(path, FileMode.Create);

        SavingDataTest data = new SavingDataTest(square);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SavingDataTest LoadSquare()
    {
        string path = Application.persistentDataPath + "/square.hopeitworks";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SavingDataTest data = formatter.Deserialize(stream) as SavingDataTest;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
