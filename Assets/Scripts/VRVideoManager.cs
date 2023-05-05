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

    public void Start()
    {
        var options = new List<Dropdown.OptionData>();
        for (int i = 0; i < videos.Count; i++)
        {
            options.Add(new Dropdown.OptionData(videos[i].name));
        }
        dropdown.AddOptions(options);
        ChangeSource();         // change the source into the default video.
    }

    public void ChangeSource()
    {
        this.index = dropdown.value;
        if (player.isPlaying)
        {
            player.Stop();
        }
        player.clip = videos[index];
        timeSlider.maxValue = player.frameCount;
        timeSlider.value = 0;           //reset the time slider.
        player.Play();
        
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
}
