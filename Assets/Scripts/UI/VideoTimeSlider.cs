using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public void UpdateValue() { 
        slider.UpdateValue(vrVideoManager.player.frame); 
    }

    public void OnVideoSourceChanged()
    {
        slider.ResetSlider();
        slider.maxValue = VRVideoManager.instance.player.frameCount;
    }
}
