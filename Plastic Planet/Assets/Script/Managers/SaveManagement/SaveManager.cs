using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager
{

    

    public static void SaveData(GameManager gameManager, string slotName)
    {

        BinaryFormatter formatter = new BinaryFormatter();
        string filePath = Application.persistentDataPath + "/player.SavaData " + slotName;
        FileStream stream = new FileStream(filePath, FileMode.Create);

        GameData data = new GameData(gameManager);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadData(string slotName)
    {
        string filePath = Application.persistentDataPath + "/player.SavaData " + slotName;
        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filePath, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;

        }
        else
        {
            return null;
        }
    }
    public static void Deletedata()
    {
        string[] filePaths = Directory.GetFiles(Application.persistentDataPath); foreach (string filePath in filePaths) File.Delete(filePath);
    }
    public static void Deletedata_(string slotName)
    {
        string filePath = (Application.persistentDataPath + "/player.SavaData " + slotName);
        File.Delete(filePath);
    }


}
