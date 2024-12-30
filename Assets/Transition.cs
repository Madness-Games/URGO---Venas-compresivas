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

    [SerializeField] private CanvasGroup loading;

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
        loading.alpha = 1;
        animator.SetTrigger("transitionForward");
    }

    public void DoTransitionBackward()
    {
        loading.alpha = 1;
        animator.SetTrigger("transitionBackward");
    }

    public void DoDisolve()
    {
        loading.alpha = 0;

        animator.ResetTrigger("transitionForward");
        animator.ResetTrigger("transitionBackward");
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
