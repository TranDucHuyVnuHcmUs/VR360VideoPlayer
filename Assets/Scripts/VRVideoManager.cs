using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VRVideoManager : MonoBehaviour
{
    public VideoPlayer player;
    public List<VideoClip> videos;
    public int index;

    [Header("UI")]
    public Dropdown dropdown;
    public Slider timeSlider;
    public VideoListUI videoListUI;
    public ThreeDSlider timeSlider3D;

    public void Start()
    {
        
        AddOptionsToUI();
        ChangeSource();         // change the source into the default video.
    }

    private void AddOptionsToUI()
    {
        //var options = new List<Dropdown.OptionData>();
        //for (int i = 0; i < videos.Count; i++)
        //{
        //    options.Add(new Dropdown.OptionData(videos[i].name));
        //}
        //dropdown.AddOptions(options);
        videoListUI.AddOptions(this.videos);
        videoListUI.onValueChanged.AddListener(ChangeSource);

        timeSlider3D.maxValue = player.frameCount; 
        timeSlider3D.onValueChangedEvent.AddListener(ChangeFrameOfVideo);
    }

    public void ChangeSource(int index)
    {
        if (player.isPlaying)
        {
            player.Stop();
        }
        player.clip = videos[index];
        //timeSlider.maxValue = player.frameCount;
        timeSlider3D.maxValue = player.frameCount;
        //timeSlider.value = 0;           //reset the time slider.
        timeSlider3D.UpdateValue(0);        //reset
        player.Play();
    }

    public void ChangeSource()
    {
        this.index = dropdown.value;
        ChangeSource(this.index);
    }

    public void PlayVideo() { player.Play(); }
    public void PauseVideo() { player.Pause(); }
    public void StopVideo() { player.Stop(); }

    public void ChangeTimeOfVideo()
    {
        player.Pause();
        player.frame = (long)timeSlider.value;
        player.Play();
    }

    public void ChangeFrameOfVideo(float frame)
    {
        player.Pause();
        Debug.Log("Frame " + frame.ToString());
        player.frame = (long)frame;
        player.Play();
    }

    public void Update()
    {
        //timeSlider3D.UpdateValue(player.frame);
    }
}
