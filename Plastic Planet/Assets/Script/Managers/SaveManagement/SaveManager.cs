using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager
{
   
    public static void SaveData(GameManager gameManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.SavaData";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(gameManager);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadData()
    {
        string path = Application.persistentDataPath + "/player.SavaData";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;

        }
        else
        {
            Debug.LogError("Save file not fount in " + path);
            return null;
        }
    }
    public static void Deletedata()
    {
        string[] filePaths = Directory.GetFiles(Application.persistentDataPath); foreach (string filePath in filePaths) File.Delete(filePath);
    }


}
