using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangerBridge : MonoBehaviour
{
    public void ChangeScene(int _scene)
    {
        SceneChanger.Instace.ChangeScene(_scene);
    }
}
