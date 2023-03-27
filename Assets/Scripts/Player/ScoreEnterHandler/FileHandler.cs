using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Assets.Scripts.Player.ScoreEnterHandler;
using System.Linq;

public static class FileHandler { 
    public static void SaveToJSON<T>(List<T> toSave, string fileName)
    {
        string content = JsonHelper.ToJson<T>(toSave.ToArray() , true);
        WriteFile( GetPath(fileName) , content );
    }

    public static void SaveToJSON<T>(T toSave, string filename)
    {
        string content = JsonUtility.ToJson(toSave);
        WriteFile(GetPath(filename), content);
    }

    public static List<T> ReadListFromJSON<T>(string filename)
    {
        string content = ReadFile(GetPath(filename));
        if (string.IsNullOrEmpty(content) || content == "{}")
        {
            return new List<T>();
        }
        return JsonHelper.FromJson<T>(content).ToList();
    }

    public static T ReadFromJSON<T>(string filename)
    {
        string content = ReadFile(GetPath(filename));
        if (string.IsNullOrEmpty(content) || content == "{}")
        {
            return default(T);
        }
        return JsonUtility.FromJson<T>(content);
    }

    private static string GetPath(string filename)
    {
        return $"{Application.persistentDataPath}/{filename}";
    }

    private static void WriteFile(string path, string content)
    {
        FileStream fileStream = new FileStream(path, FileMode.Create);
        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(content);
        }
    }

    private static string ReadFile(string path)
    {
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string content = reader.ReadToEnd();
                return content;
            }
        }
        return string.Empty;
    }
}

