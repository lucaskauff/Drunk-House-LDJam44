using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Boskov
{
    [ExecuteInEditMode]
    public class Gaje_C : MonoBehaviour
    {
        private Color Tint = new Color(1, 1, 1, 1);

        private MaterialPropertyBlock _propBlock;

        private Image imageColor;

        public bool isBlinking = false;
        private float blink = 10;
        private float blinkOut = 1;

        void Awake()
        {
            _propBlock = new MaterialPropertyBlock();
            imageColor = GetComponent<Image>();
        }
        // Update is called once per frame
        void Update()
        {
            /* if (render != null)
             {
                 // Get the current value of the material properties in the renderer.
                 render.GetPropertyBlock(_propBlock);
                 // Assign our new value.
                 blinkOut += Time.deltaTime * blink;
                 _propBlock.SetFloat("_BlinkIntensity", blinkOut);

                 if (isBlinking == true)
                     _propBlock.SetFloat("_IsBlinking", 1);
                 else
                     _propBlock.SetFloat("_IsBlinking", 0);

                 render.SetPropertyBlock(_propBlock);
             }*/



            ColorGrading();
            Blinking();
        }

        void ColorGrading()
        {
            if (imageColor.fillAmount >= 0.5f) {imageColor.color = new Color(Mathf.Lerp(2, 0, imageColor.fillAmount), 1, 0, 1);}
            else if (imageColor.fillAmount < 0.5f) { imageColor.color = new Color(1, Mathf.Lerp(0, 1, imageColor.fillAmount * 2), 0, 1); }
            
            if(imageColor.fillAmount < 0.25f)
            {
                isBlinking = true;
            }
            else
            {
                isBlinking = false;
            }

        }

        void Blinking()
        {
            if (isBlinking == true)
            {
                blinkOut += Time.deltaTime * blink;
                imageColor.material.SetFloat("_BlinkIntensity", blinkOut);
                imageColor.material.SetFloat("_IsBlinking", 1);
            }
            else {imageColor.material.SetFloat("_IsBlinking", 0); }
            
        }
    }
}
