using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoURLSolver : MonoBehaviour
{
    public bool IsPrepared;

    [SerializeField] private string videoName;
    private VideoPlayer vp;
    private void Awake()
    {
        string _url = Application.streamingAssetsPath + "/" + videoName;
        Debug.Log(_url);
        vp = GetComponent<VideoPlayer>();

        vp.url = _url;
        vp.Prepare();
    }
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (!vp.isPrepared)
        {
            yield return null;
        }

        vp.Play();
    }
}
