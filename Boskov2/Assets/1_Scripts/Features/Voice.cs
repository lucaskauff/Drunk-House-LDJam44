using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boskov.Inputs;

namespace Boskov.Features
{
    [CreateAssetMenu(fileName = "new Voice Feature", menuName = "Features/Voice")]
    public class Voice : Features
    {
        public override bool Cast(MonoBehaviour _mono)
        {
            if (GameInput.Voice.GetKey() && gameCore.VladimirState.energy.current > 0 && gameCore.VladimirState.deafness.current > 0) PushToTalk();

            return false;
        }

        private void PushToTalk()
        {
            Debug.Log("Your are listened");
            CostEnergy();
            Debug.Log(gameCore.Voice.valid);
            if (gameCore.Voice.valid)
            {
                float value = sleep * Time.deltaTime * (gameCore.VladimirState.deafness.current / gameCore.VladimirState.deafness.max);
                gameCore.VladimirState.sleep.Increase(value);

                float hearing = deafness * Time.deltaTime;
                gameCore.VladimirState.deafness.Decrease(hearing);

            }
        }

        private void CostEnergy()
        {
            gameCore.VladimirState.energy.Decrease(energy * Time.deltaTime);
        }
    }
}