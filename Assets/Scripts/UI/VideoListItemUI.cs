using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoListItemUI : MonoBehaviour
{
    public int index;
    public Text titleText;
    public VideoListUI videoListUI;
    
    public void SetText(string text)
    {
        this.titleText.text = text;
    }

    public void SetVideoInfoOnUI(int index, VRVideo video)
    {
        this.index = index;
        this.titleText.text = video.name;
    }

    public void SelectThisItem()
    {
        videoListUI.SelectThisItem(this.index);
    }
}
