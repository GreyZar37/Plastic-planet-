using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="gameManager"></param>
    /// <param name="slotName"></param>

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


    /// <summary>
    ///
    /// </summary>
    /// <param name="mainMenuData"></param>

    public static void SaveMainMenuData(mainMenuManager mainMenuData)
    {

        BinaryFormatter formatter = new BinaryFormatter();
        string filePath = Application.persistentDataPath + "/player.SlotNames";
        FileStream stream = new FileStream(filePath, FileMode.Create);

        GameData data = new GameData(mainMenuData);
        formatter.Serialize(stream, data);
        stream.Close();
    }


    public static GameData LoadMainMenuData()
    {
        string filePath = Application.persistentDataPath + "/player.SlotNames";
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


    public static void Deletedata_(string slotName)
    {
        string filePath = (Application.persistentDataPath + "/player.SavaData " + slotName);
        File.Delete(filePath);
    }


}
