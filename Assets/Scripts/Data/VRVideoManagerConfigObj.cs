using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;

[System.Serializable]
[CreateAssetMenu(fileName = "VRVideoManagerConfigObj", menuName = "Config/VR video manager")]
public class VRVideoManagerConfigObj : ScriptableObject
{
    public string dataFileName = "vidConfig.txt";
    public VRVideoManagerConfig config;


    public void Awake()
    {
        config = new VRVideoManagerConfig();
        InitPersistence();
    }

    public void AddVideo(VRVideo vid)
    {
        config.videos.Add(vid);
        SaveDataIntoPersistence();          // save every time something is added.
    }

    //https://learn.microsoft.com/en-us/dotnet/api/system.io.file?view=net-7.0
    public void LoadDataFromFile()
    {
        string path = Path.Combine(Application.persistentDataPath, dataFileName);
        if (dataFileName == null)
        {
            dataFileName = "vidConfig.txt";
        }
        if (!File.Exists(path))
        {
            File.Create(path);
            return;                 //cause it's new file, nothing to read
        }
        using (StreamReader sr = File.OpenText(path))
        {
            string s, s2;
            while (!sr.EndOfStream)
            {
                s = sr.ReadLine();
                s2 = sr.ReadLine();
                config.videos.Add(new VRVideo(s, s2));
            }
        }
    }

    public void SaveDataIntoPersistence()
    {
        string path = Path.Combine(Application.persistentDataPath, dataFileName);
        using (StreamWriter sw = File.CreateText(path))
        {
            for (int i = 0; i < config.videos.Count; i++)
            {
                sw.WriteLine(config.videos[i].name);
                sw.WriteLine(config.videos[i].url);
            }
        }
    }

    private void InitPersistence()
    {
        string path = Path.Combine(Application.persistentDataPath, dataFileName);
        Debug.Log(path);
        if (File.Exists(path)){
            Debug.LogWarning("Persistent file already exists! Recommended to change the file name if you intend to have different configurations. This config object will still load settings from this file, but many objects can edit the same files, so beware.");
            //LoadDataFromFile();
        }
    }
}