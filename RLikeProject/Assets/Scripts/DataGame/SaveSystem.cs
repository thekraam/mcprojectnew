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
        float time = 0f;
        while (time < 3f)
        {
            if (time >= 2f)
            {
                isDataPresent = Application.persistentDataPath + "/game.fun";
                if (File.Exists(isDataPresent)) resumeGame.SetActive(true);
                else resumeGame.SetActive(false);
            }
                time += Time.deltaTime;
        }
    }

    public static void DeleteSave()
    {
        if (File.Exists(isDataPresent)) File.Delete(isDataPresent);
    }

    public static void SaveGame(string cityname ,Player player , Events events , Fattoria fattoria , Caserma caserma ,
                Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders,
                  Miniera miniera, Fabbro fabbro, Gilda gilda, Tutorial tutorial,
                  OldSoldiersManager oldSoldiers, Enemy enemy, Enemy.ESwordsmen eSwordsmen,
                  Enemy.EArchers eArchers, Enemy.ERiders eRiders, Captain1 capitano

        )
    {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/game.fun";
            isDataPresent = path;
            FileStream stream = new FileStream(path, FileMode.Create);

            GameData data = new GameData(cityname, player, events, fattoria, caserma,
                                        swordsmen, archers, riders, miniera,
                                        fabbro, gilda, tutorial, oldSoldiers, enemy,
                                        eSwordsmen, eArchers, eRiders, capitano);

            formatter.Serialize(stream, data);
            stream.Close();

        if (!(File.Exists(Application.persistentDataPath + "/bak.fun")))
        {
            BinaryFormatter formatter2 = new BinaryFormatter();
            string path2 = Application.persistentDataPath + "/bak.fun";

            FileStream stream2 = new FileStream(path2, FileMode.Create);

            GameData data2 = new GameData(cityname, player, events, fattoria, caserma,
                                        swordsmen, archers, riders, miniera,
                                        fabbro, gilda, tutorial, oldSoldiers, enemy,
                                        eSwordsmen, eArchers, eRiders, capitano);

            formatter2.Serialize(stream2, data2);
            stream2.Close();
        }
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

    public static GameData LoadNullData()
    {
        string path = Application.persistentDataPath + "/bak.fun";
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
