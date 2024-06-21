using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Transition : MonoBehaviour
{
    private Animator animator;
    public static Transition Instance;
    [SerializeField] private Image transitionImg;
    [SerializeField] private Sprite[] transitionSprite;

    private void Awake()
    {
        if (Instance == null) { Instance = this; } else { Destroy(this); }

        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoTransitionForward()
    {
        animator.SetTrigger("transitionForward");
    }

    public void DoTransitionBackward()
    {
        animator.SetTrigger("transitionBackward");
    }

    public void DoDisolve()
    {
        animator.SetTrigger("sceneLoaded");
    }

    public void Setup(int _scene)
    {
        Debug.Log("Transition Scene:" + _scene);
        if (_scene < 0)
            return;

        if (_scene <= transitionSprite.Length)
            transitionImg.sprite = transitionSprite[_scene];
        else
            Debug.Log("Transition Sprite not founded");
    }
}
