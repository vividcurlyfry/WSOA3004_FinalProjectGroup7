using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class GameManagerSaveScript
{
    public static void SaveGame(GameManagerScript gm)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gm.sazei";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameManagerSaveData data = new GameManagerSaveData(gm);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameManagerSaveData LoadGame()
    {
        string path = Application.persistentDataPath + "/gm.sazei";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameManagerSaveData data = formatter.Deserialize(stream) as GameManagerSaveData;
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