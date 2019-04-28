using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boskov.Features
{
    public abstract class Features : ScriptableObject
    {
        [SerializeField] protected GameCoreData gameCore;
        [Header("General")]
        public float duration;
        public float delay;
        public float coolDown;

        [Header("Values")]
        public float sleep;
        public float energy;
        public float deafness;
        public float heartbeat;

        protected bool onCoolDown;

        public abstract bool Cast(MonoBehaviour _mono);

        protected IEnumerator CoolDown()
        {
            yield return new WaitForSeconds(coolDown);

            onCoolDown = false;
        }

    }
}