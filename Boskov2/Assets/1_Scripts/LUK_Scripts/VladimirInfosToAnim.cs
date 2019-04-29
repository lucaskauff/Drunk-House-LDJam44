using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Boskov.UI
{
    public class VladimirInfosToAnim : MonoBehaviour
    {
        [SerializeField] private Animator vladAnim = default;
        [SerializeField] private Image sleepGFill = default;

        private void Update()
        {
            vladAnim.SetInteger("Degradation", Mathf.RoundToInt(sleepGFill.fillAmount * 6));
        }
    }
}