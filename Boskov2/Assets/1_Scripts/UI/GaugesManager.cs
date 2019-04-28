using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Boskov
{
    [ExecuteInEditMode]
    public class GaugesManager : MonoBehaviour
    {
        [SerializeField] private GameCoreData gameCore;
        [SerializeField] private Image sleep;
        [SerializeField] private Image energy;
        [SerializeField] private Image deaf;
        [SerializeField] private Image life;

        // Start is called before the first frame update
        void Start()
        {
            gameCore.VladimirState.Initialize();
        }

        // Update is called once per frame
        void Update()
        {
            GaugesUpdate();
        }

        private void GaugesUpdate()
        {
            float amountSleep = gameCore.VladimirState.sleep.current / gameCore.VladimirState.sleep.max;
            float amountLife = gameCore.VladimirState.life.current / gameCore.VladimirState.life.max;
            float amountDeaf = gameCore.VladimirState.deafness.current / gameCore.VladimirState.deafness.max;
            float amountPower = gameCore.VladimirState.energy.current / gameCore.VladimirState.energy.max;

            sleep.fillAmount = amountSleep;
            life.fillAmount = amountLife;
            deaf.fillAmount = amountDeaf;
            energy.fillAmount = amountPower;
        }
    }
}