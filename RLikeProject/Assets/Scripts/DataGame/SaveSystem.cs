using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    public static void SaveGame(Player player , Events events , Fattoria fattoria , Caserma caserma ,
                Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders
                    )
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(player , events , fattoria , caserma , swordsmen , archers , riders);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadGame ()
    {
        string path = Application.persistentDataPath + "/game.fun";
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
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

}
