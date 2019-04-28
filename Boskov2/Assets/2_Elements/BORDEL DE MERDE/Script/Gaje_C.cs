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

        public float value;

        void Awake()
        {
            _propBlock = new MaterialPropertyBlock();
            imageColor = GetComponent<Image>();
        }
        // Update is called once per frame
        void Update()
        {
            /* // Get the current value of the material properties in the renderer.
             _renderer.GetPropertyBlock(_propBlock);
             // Assign our new value.
             _propBlock.SetColor("_Color", Tint * 1.3f);

             _renderer.SetPropertyBlock(_propBlock);*/

            ColorGrading();
        }

        void ColorGrading()
        {
            if (imageColor.fillAmount >= 0.5f)
            {
                imageColor.color = new Color(Mathf.Lerp(1, 0, imageColor.fillAmount * value), 1, 0, 1);
                value = Mathf.Lerp(0, 1, imageColor.fillAmount / 2);

            }
            else if (imageColor.fillAmount < 0.5f)
                imageColor.color = new Color(1, Mathf.Lerp(0, 1, imageColor.fillAmount * 2), 0, 1);

            Debug.Log(imageColor.color);
        }
    }
}
