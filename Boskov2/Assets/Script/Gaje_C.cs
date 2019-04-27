using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaje_C : MonoBehaviour
{
    public Color Tint = new Color(1, 1, 1, 1);


    private Renderer _renderer;
    private MaterialPropertyBlock _propBlock;

    void Awake()
    {
        _propBlock = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();
    }
    // Update is called once per frame
    void Update()
    {
        // Get the current value of the material properties in the renderer.
        _renderer.GetPropertyBlock(_propBlock);
        // Assign our new value.
        _propBlock.SetColor("_Color", Tint * 1.3f);

        _renderer.SetPropertyBlock(_propBlock);
    }
}
