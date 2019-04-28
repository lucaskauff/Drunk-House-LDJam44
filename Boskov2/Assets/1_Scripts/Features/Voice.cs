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
            if (GameInput.Voice.GetKey()) PushToTalk();

            return false;
        }

        private void PushToTalk()
        {
            Debug.Log("Your are listened");
        }
    }
}