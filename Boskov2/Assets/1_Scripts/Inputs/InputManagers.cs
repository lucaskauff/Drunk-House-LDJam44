using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boskov.Inputs
{
    public class InputManagers : GameEvents
    {
        [SerializeField] private GameCoreData gameCore = default;

        // Start is called before the first frame update
        void Start()
        {
            GameInputsCore.SetBoolTriggerLeft(false);
            GameInputsCore.SetBoolTriggerRight(false);
        }

        // Update is called once per frame
        void Update()
        {
            gameCore.InputsTemplate.UpdateData(this);

            gameCore.features[0].Cast(this);
            gameCore.features[1].Cast(this);
        }
    }
}