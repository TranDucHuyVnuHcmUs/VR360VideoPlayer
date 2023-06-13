using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;

public class IntUnityEvent: UnityEvent<int> {}

public class VideoListUI : MonoBehaviour
{
    public VideoListItemUI playingItemUI;
    public List<VideoListItemUI> items;
    public List<VideoClip> videos;
    public int startIndex = 0;
    public bool isShowing = false;

    public IntUnityEvent onValueChanged;

    private void Awake()
    {
        onValueChanged = new IntUnityEvent();    
    }

    public void AddOptions(List<VideoClip> videos)
    {
        this.videos = videos;
        SetInfoOnItems();
    }

    public void SetInfoOnItems()
    {
        int j = startIndex;
        for (int i = 0; i < items.Count; i++)
        {
            if (j >= videos.Count) break;
            items[i].SetVideoInfoOnUI(j, this.videos[j]);
            ++j;
        }
    }

    public void ShowItems()
    {
        isShowing = !isShowing;
        for (int i = 0; i < items.Count; i++)
        {
            items[i].gameObject.SetActive(isShowing);
        }
    }

    public void SelectThisItem(int index)
    {
        this.onValueChanged.Invoke(index);
        this.playingItemUI.SetVideoInfoOnUI(index, this.videos[index]);
    }
}
