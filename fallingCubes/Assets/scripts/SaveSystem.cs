using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void Save(player highScore)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fall";
        FileStream stream = new FileStream(path, FileMode.Create);

        playerData data = new playerData(highScore);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static playerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fall";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            playerData data = formatter.Deserialize(stream) as playerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }

}
