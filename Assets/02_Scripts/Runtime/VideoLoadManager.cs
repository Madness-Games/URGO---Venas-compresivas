using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoLoadManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer[] videos;
    [SerializeField] private FadeController fade;

    private bool videosLoaded;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        if (videosLoaded)
            return;

        int _nVideosPlaying = 0;
        for (int i = 0; i < videos.Length; i++)
        {
            if (videos[i].isPlaying)
                _nVideosPlaying += 1;
        }

        Debug.Log("Videos playing: " + _nVideosPlaying + " of " + videos.Length);

        if (_nVideosPlaying == videos.Length)
        {
            fade.FadeOutTrigger();
            videosLoaded = true;
        }
    }
}
