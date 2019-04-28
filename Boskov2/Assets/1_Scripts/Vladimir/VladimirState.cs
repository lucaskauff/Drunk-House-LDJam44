using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boskov.Vladimir
{
    [CreateAssetMenu(fileName = "new Vladimir State", menuName = "Vladimir/State")]
    public class VladimirState : ScriptableObject
    {
        public Status sleep;
        public Status energy;
        public Status life;
        public Status deafness;

        public void Initialize()
        {
            sleep.Initialize();
            energy.Initialize();
            life.Initialize();
            deafness.Initialize();
        }
    }
}