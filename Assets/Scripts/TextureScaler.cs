using UnityEngine;
using System;
public class TextureScaler : MonoBehaviour
{
    private Vector2 startTextureScale;
    private Renderer renderer;

    private void Start()
    {
        if (renderer == null)
        {
            renderer = GetComponent<Renderer>();
            startTextureScale = renderer.material.mainTextureScale;
        }
        renderer.material.mainTextureScale = new Vector2(transform.localScale.x * startTextureScale.x, transform.localScale.y * startTextureScale.y);
    }
}