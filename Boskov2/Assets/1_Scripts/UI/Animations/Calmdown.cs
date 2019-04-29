using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boskov
{
    public class Calmdown : GameEvents
    {
        [SerializeField] private Animator myAnim = default;

        public override void CalmDownAppear()
        {
            myAnim.SetTrigger("CalmDown");
        }
    }
}