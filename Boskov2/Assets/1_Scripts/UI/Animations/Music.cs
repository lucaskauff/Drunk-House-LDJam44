using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boskov
{
    public class Music : GameEvents
    {
        [SerializeField] private Animator myAnim = default;

        public override void PlayMusic()
        {
            myAnim.SetTrigger("Play");
        }

        public override void StopMusic()
        {
            myAnim.SetTrigger("Stop");
        }
    }
}