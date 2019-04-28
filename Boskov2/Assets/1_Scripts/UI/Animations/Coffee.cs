using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boskov
{
    public class Coffee : GameEvents
    {
        [SerializeField] private Animator myAnim = default;

        public override void CoffeenjectionStart()
        {
            myAnim.SetTrigger("CoffeeGo");
        }

        public override void CoffeenjectionEnd()
        {
            myAnim.SetTrigger("CoffeeStop");
        }
    }
}