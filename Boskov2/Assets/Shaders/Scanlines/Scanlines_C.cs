using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanlines_C : MonoBehaviour
{
    public Material material;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {

        Graphics.Blit(source, destination, material);
    }
}
