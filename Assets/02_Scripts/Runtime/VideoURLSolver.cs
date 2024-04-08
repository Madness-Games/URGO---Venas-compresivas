using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoURLSolver : MonoBehaviour
{
    [SerializeField] private string videoName;
    private VideoPlayer vp;
    // Start is called before the first frame update
    void Start()
    {
        string _url = Application.streamingAssetsPath+"/" + videoName;
        Debug.Log(_url);
        vp = GetComponent<VideoPlayer>();

        vp.url = _url;
        vp.Prepare();

        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
