using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;

public class VRVideoManager : MonoBehaviour
{
    public static VRVideoManager instance;

    public VideoPlayer player;
    public VideoPicker videoPicker;
    //public List<VideoClip> videos;
    public VRVideoManagerConfigObj configObj;
    public int index;

    [Header("UI")]
    public Dropdown dropdown;
    public VideoListUI videoListUI;

    [Header("Events")]

    public UnityEvent videoListInitEvent;
    public UnityEvent videoPlayEvent, videoPauseEvent, videoRunningEvent, videoSourceChangeEvent, videoAddEvent;

    private void Awake()
    {
        if (instance != null)
            Debug.LogError("Two VR video manager exists!");
        instance = this;
    }

    public void Start()
    {
        configObj.LoadDataFromFile();
        AddOptionsToUI();
        videoListInitEvent.Invoke();
        if (configObj.config.videos.Count > 0)
            ChangeSource();         // change the source into the default video.
    }

    private void AddOptionsToUI()
    {
        videoListUI.AddOptions(configObj.config.videos);
        videoListUI.onValueChanged.AddListener(ChangeSource);

        videoPicker.videoPickedEvent.AddListener(AddVideo);
    }

    public void ChangeSource(int index)
    {
        if (player.isPlaying) player.Stop();
        player.url = configObj.config.videos[index].url;
        player.Prepare();           // must prepare first before enabling video controlling UI such as slider.

        videoSourceChangeEvent.Invoke();
        player.Play();
    }

    public void ChangeSource()
    {
        this.index = dropdown.value;
        ChangeSource(this.index);
    }

    public void PlayVideo() {
        player.Play();
        videoPlayEvent.Invoke();
    }
    public void PauseVideo() {
        player.Pause();
        videoPauseEvent.Invoke();
    }
    public void TogglePlayVideo() { 
        if (player.isPlaying) PauseVideo(); else PlayVideo(); 
    }

    public void StopVideo() { 
        player.Stop(); 
    }

    public void ChangeFrameOfVideo(float frame)
    {
        player.frame = (long)frame;
    }

    public void AddVideo(VRVideo video)
    {
        configObj.AddVideo(video);
        videoListUI.AddOptions(configObj.config.videos);
        ChangeSource(configObj.config.videos.Count - 1);
    }

    public void Update()
    {
        //timeSlider3D.UpdateValue(player.frame);
        if (player.isPlaying)
            videoRunningEvent.Invoke();
    }
}
