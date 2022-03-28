using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;

public static class SaveSystem
{
    public static string isDataPresent;

    

    public static void DataStatus(GameObject resumeGame)
    {
        isDataPresent = Application.persistentDataPath + "/game.fun";
        if (File.Exists(isDataPresent)) resumeGame.SetActive(true);
        else resumeGame.SetActive(false);
    }

    public static void DeleteSave()
    {
        if (File.Exists(isDataPresent)) File.Delete(isDataPresent);
    }

    public static void SaveGame(string cityname ,Player player , Events events , Fattoria fattoria , Caserma caserma ,
                Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders,
                  Miniera miniera, Fabbro fabbro, Gilda gilda, Tutorial tutorial
        )
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game.fun";
        isDataPresent = path;
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(cityname ,player , events , fattoria , caserma , 
                                    swordsmen , archers , riders , miniera, 
                                    fabbro, gilda , tutorial);

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
