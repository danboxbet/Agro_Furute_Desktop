using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[Serializable]
public class Saver
{
    public static string Path(string filename)
    {
        return $"{Application.persistentDataPath}/{filename}";
    }
    public static DataSave TryLoad(string filename)
    {
        
        if(File.Exists(Path(filename)))
        {
           
            var dataJSON = File.ReadAllText(Path(filename));
            var dataFromJSON = JsonUtility.FromJson<DataSave>(dataJSON);
            return dataFromJSON;
        }
        return new DataSave { levelProgress=0};
    }    
    public static void Save(string filename, DataSave data)
    {
        Debug.Log(Path(filename));
        CreateFileIfNotExists(filename);
        var dataToJson = JsonUtility.ToJson(data);
        File.WriteAllText(Path(filename), dataToJson);
    }
    public static void Reset(string filename)
    {
        if(File.Exists(Path(filename)))
        {
            File.Delete(Path(filename));
           
        }
    }
    public static bool HasFile(string filename)
    {
        return File.Exists(Path(filename));
    }
    public static void CreateFileIfNotExists(string filename)
    {
        if (!File.Exists(Path(filename)))
        {
            File.Create(Path(filename)).Close();
        }
    }
}
