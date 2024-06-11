using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComparativaController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit()
    {
        SceneChanger.Instace.ChangeScene(SceneChanger.Instace.previousScene );
    }

    public void Temps()
    {
        SceneChanger.Instace.ChangeSceneExtra("05_Temps");
    }

    public void Return()
    {
        SceneChanger.Instace.ChangeSceneExtra("04_Comparacio");
    }
}
