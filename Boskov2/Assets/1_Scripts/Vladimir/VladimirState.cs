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
        public Status deafness;
        public Status heartBeat;
        private NormalDistribution gauss = new NormalDistribution(-1, 85, 15);

        public void Initialize()
        {
            sleep.Initialize();
            energy.Initialize();
            heartBeat.Initialize();
            deafness.Initialize();
        }

        public void Sleepyness()
        {
            float value = heartBeat.max / heartBeat.current;
            value = Mathf.Clamp(value, 1, 5);
            sleep.Decrease(sleep.rate * value*Time.deltaTime);
        }

        public void HeartBeat()
        {
            float value = heartBeat.rate * (gauss.GetValueFrom(heartBeat.current) + 1) * Time.deltaTime;
            if (heartBeat.current < 85) heartBeat.Increase(value);
            else heartBeat.Decrease(value);
        }
    }
}