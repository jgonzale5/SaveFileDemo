using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveScript
{
    public static SaveClass saveFile = new SaveClass();
    public static string path;

    public static void SAVE()
    {
        //If you wanted to have a folder inside the data path with the savefiles, you need to check the folder exists first
        //Create it if it doesnt
        if (!Directory.Exists(Application.dataPath + "/Savefiles/"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Savefiles/");
        }

        //"Hell" + "o World" = "Hello World"

        path = Application.dataPath + "/Savefiles/SaveFile.ggd";

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(path, FileMode.OpenOrCreate, FileAccess.Write);
        bf.Serialize(file, saveFile);
    }

    public static bool LOAD()
    {
        //If you wanted to have a folder inside the data path with the savefiles, you need to check the folder exists first
        //Create it if it doesnt
        if (!Directory.Exists(Application.dataPath + "/Savefiles/"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Savefiles/");
            return false;
        }

        path = Application.dataPath + "/Savefiles/SaveFile.ggd";

        if (!File.Exists(path))
        {
            return false;
        }

        //"Hell" + "o World" = "Hello World"

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read);
        saveFile = (SaveClass)bf.Deserialize(file);

        return true;
    }
}
