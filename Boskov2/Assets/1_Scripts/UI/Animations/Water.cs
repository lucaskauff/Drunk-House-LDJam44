using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boskov
{
    public class Water : GameEvents
    {
        [SerializeField] private Animator myAnim = default;

        public override void WaterThrow()
        {
            myAnim.SetTrigger("Purge");
        }
    }
}