using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;
using System.IO;

public class VRVideoUnityEvent: UnityEvent<VRVideo> { }

public class VideoPicker : MonoBehaviour
{
    public VRVideoUnityEvent videoPickedEvent;

    private void Awake()
    {
        videoPickedEvent = new VRVideoUnityEvent();
    }

    public void PickFile()
    {
        NativeFilePicker.Permission permission = NativeFilePicker.PickFile(
            (path) =>
            {
                if (path == null)
                    Debug.LogWarning("No vid.");
                else
                {
                    var fileInfo = new FileInfo(path);
                    videoPickedEvent.Invoke(new VRVideo(fileInfo.Name, path));
                }
            }, new string[] { "video/*" } );
    }
}
