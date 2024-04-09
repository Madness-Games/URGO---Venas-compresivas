using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SwapSprite : MonoBehaviour
{
    [SerializeField] private Sprite primarySprite;
    [SerializeField] private Sprite secondarySprite;

    private SpriteRenderer renderer;
    // Start is called before the first frame update
    void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();

        if (primarySprite == null)
            primarySprite = renderer.sprite;
    }

    public void Swap()
    {
        if (renderer.sprite == primarySprite)
            renderer.sprite = secondarySprite;
        else
            renderer.sprite = primarySprite;
    }

    public void SetActive(bool _b = true)
    {
        if (_b)
            renderer.sprite = secondarySprite;
        else
            renderer.sprite = primarySprite;
    }
}
