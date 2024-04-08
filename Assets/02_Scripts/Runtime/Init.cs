using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        SceneChanger.Instace.ChangeScene("01_MainScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
