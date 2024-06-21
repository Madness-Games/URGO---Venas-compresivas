using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    private float progress;
    private bool isChangingScene;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        SceneChanger.Instace.ChangeScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (isChangingScene)
            return;

        for (int i = 0; i < videos.Length; i++)
        {
            if (videos[i].IsPrepared)
                progress += 1 / (float)videos.Length;
        }

        Debug.Log("loading videos progress: " + progress);

        if (progress >= 1)
        {
            SceneChanger.Instace.ChangeScene("01_MainScene");
            isChangingScene = true;
        }*/
    }
}
