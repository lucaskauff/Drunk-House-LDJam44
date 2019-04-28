using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VladimirInfosToAnim : MonoBehaviour
{
    [SerializeField] private Animator vladAnim = default;
    [SerializeField] private Image sleepGFill = default;

    public float degradation = 1;
    public float sleepAmount = 1;

    private void Update()
    {
        sleepAmount = sleepGFill.fillAmount;

        if (sleepAmount == degradation)
        {
            return;
        }
        else if (sleepAmount < degradation && sleepAmount <= degradation - 0.16f)
        {
            VladGettingWorse();
        }
        else if (sleepAmount > degradation && sleepAmount >= degradation + 0.16f)
        {
            VladGettingBetter();
        }
    }

    void VladGettingWorse()
    {
        vladAnim.SetTrigger("Worse");
        degradation -= 0.16f;
    }

    void VladGettingBetter()
    {
        vladAnim.SetTrigger("Better");
        degradation += 0.16f;
    }
}