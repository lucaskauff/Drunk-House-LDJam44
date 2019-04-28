using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boskov.Inputs
{
    [CreateAssetMenu(fileName ="new Inputs Template", menuName = "Inputs/Template")]
    public class InputsTemplate : ScriptableObject
    {
        public InputsCode[] Voice;
        public InputsCode[] Water;
        public InputsCode[] PlayMusic;
        public InputsCode[] Coffeenjection;
        public InputsCode[] Chair;
        public InputsCode[] Generator;
        public InputsCode[] Calm;
        public InputsCode[] Eject;

        private bool trUsed;
        private bool tlUsed;

        public void UpdateData(MonoBehaviour _monoBehaviour)
        {
            SetInputs();
            TriggersAsKey(_monoBehaviour);
        }

        public void SetInputs()
        {
            GameInputsCore.assignations[0] = Voice;
            GameInputsCore.assignations[1] = Water;
            GameInputsCore.assignations[2] = PlayMusic;
            GameInputsCore.assignations[3] = Coffeenjection;
            GameInputsCore.assignations[4] = Chair;
            GameInputsCore.assignations[5] = Generator;
            GameInputsCore.assignations[6] = Calm;
            GameInputsCore.assignations[7] = Eject;
        }

        private void TriggersAsKey(MonoBehaviour _monoBehaviour)
        {
            GameInputsCore.SetBoolTriggerLeft(false);
            GameInputsCore.SetBoolTriggerRight(false);

            if (Input.GetAxis("JS_LeftTrigger") > .9f && !tlUsed) _monoBehaviour.StartCoroutine(TriggerLeftGetKeyDown());
            if (Input.GetAxis("JS_RightTrigger") > .9f && !trUsed) _monoBehaviour.StartCoroutine(TriggerRightGetKeyDown());
        }

        IEnumerator TriggerLeftGetKeyDown()
        {
            GameInputsCore.SetBoolTriggerLeft(true);
            tlUsed = true;

            while (Input.GetAxis("JS_LeftTrigger") > .75f)
            {
                yield return null;
            }

            tlUsed = false;
            GameInputsCore.SetBoolTriggerLeft(false);
        }

        IEnumerator TriggerRightGetKeyDown()
        {
            GameInputsCore.SetBoolTriggerRight(true);
            trUsed = true;

            while (Input.GetAxis("JS_RightTrigger") > .75f)
            {
                yield return null;
            }

            trUsed = false;
            GameInputsCore.SetBoolTriggerRight(false);
        }
    }
}