using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoTimeSlider : MonoBehaviour
{
    public ThreeDSlider slider;
    public VRVideoManager vrVideoManager;

    private void Awake()
    {
        slider = GetComponent<ThreeDSlider>();
    }

    private void Start()
    {
        if (vrVideoManager == null) vrVideoManager = VRVideoManager.instance;
        slider.onValueChangedEvent.AddListener(vrVideoManager.ChangeFrameOfVideo);
        VRVideoManager.instance.player.prepareCompleted += OnVideoPreparationCompleted;
    }

    private void OnVideoPreparationCompleted(VideoPlayer player)
    {
        slider.maxValue = player.frameCount;
    }

    public void UpdateValue() { 
        slider.UpdateValue(vrVideoManager.player.frame); 
    }

    public void OnVideoSourceChanged()
    {
        slider.ResetSlider();
    }

}
