using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class GameManagerSaveScript
{
    public static void SaveGameSlotOne(GameManagerScript gm)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gm.sazei.slot1";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameManagerSaveData data = new GameManagerSaveData(gm);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveGameSlotTwo(GameManagerScript gm)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gm.sazei.slot2";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameManagerSaveData data = new GameManagerSaveData(gm);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveGameSlotThree(GameManagerScript gm)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gm.sazei.slot3";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameManagerSaveData data = new GameManagerSaveData(gm);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveGameSlotFour(GameManagerScript gm)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gm.sazei.slot4";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameManagerSaveData data = new GameManagerSaveData(gm);

        formatter.Serialize(stream, data);
        stream.Close();
    }


    public static GameManagerSaveData LoadGameSlotOne()
    {
        string path = Application.persistentDataPath + "/gm.sazei.slot1";
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

    public static GameManagerSaveData LoadGameSlotTwo()
    {
        string path = Application.persistentDataPath + "/gm.sazei.slot2";
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

    public static GameManagerSaveData LoadGameSlotThree()
    {
        string path = Application.persistentDataPath + "/gm.sazei.slot3";
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

    public static GameManagerSaveData LoadGameSlotFour()
    {
        string path = Application.persistentDataPath + "/gm.sazei.slot4";
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