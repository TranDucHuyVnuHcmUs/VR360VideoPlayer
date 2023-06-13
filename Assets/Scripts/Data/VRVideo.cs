using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[System.Serializable]
public class VRVideo
{
    public string name;
    public string url;

    public VRVideo(string name, string url)
    {
        this.name = name;
        this.url = url;
    }

}