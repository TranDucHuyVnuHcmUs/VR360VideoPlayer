using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[System.Serializable]
public class VRVideoManagerConfig
{
    public List<VRVideo> videos;

    public VRVideoManagerConfig()
    {
        videos = new List<VRVideo>();
    }
}