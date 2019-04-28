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
            gameCore.InputsTemplate.SetInputs();

            gameCore.features[0].Init();
            gameCore.features[1].Init();
            gameCore.features[2].Init();
            gameCore.features[4].Init();
        }

        // Update is called once per frame
        void Update()
        {
            gameCore.InputsTemplate.UpdateData(this);

            /*for (int i = 0; i < gameCore.features.Length; i++)
            {
                gameCore.features[i].Cast(this);
            }*/
            gameCore.features[0].Cast(this);
            gameCore.features[1].Cast(this);
            gameCore.features[2].Cast(this);
            gameCore.features[4].Cast(this);
        }
    }
}