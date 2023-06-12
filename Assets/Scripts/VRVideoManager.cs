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
    public List<VideoClip> videos;
    public int index;

    [Header("UI")]
    public Dropdown dropdown;
    public VideoListUI videoListUI;

    [Header("Events")]
    public UnityEvent videoListInitEvent, videoPlayEvent, videoPauseEvent, videoRunningEvent, videoSourceChangeEvent;

    private void Awake()
    {
        if (instance != null)
            Debug.LogError("Two VR video manager exists!");
        instance = this;
    }

    public void Start()
    {
        AddOptionsToUI();
        videoListInitEvent.Invoke();
        ChangeSource();         // change the source into the default video.
    }

    private void AddOptionsToUI()
    {
        videoListUI.AddOptions(this.videos);
        videoListUI.onValueChanged.AddListener(ChangeSource);
    }

    public void ChangeSource(int index)
    {
        if (player.isPlaying)
        {
            player.Stop();
        }
        player.clip = videos[index];

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

    public void Update()
    {
        //timeSlider3D.UpdateValue(player.frame);
        if (player.isPlaying)
            videoRunningEvent.Invoke();
    }
}
