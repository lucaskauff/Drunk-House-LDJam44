using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Boskov
{
    public class GaugesManager : GameEvents
    {
        [SerializeField] private GameCoreData gameCore = default;
        [SerializeField] private Image sleep = default;
        [SerializeField] private Image energy = default;
        [SerializeField] private Image deaf = default;
        [SerializeField] private Animator life = default;

        private int heartBeatStatus;

        // Start is called before the first frame update
        void Start()
        {
            //gameCore.VladimirState.Initialize();
        }

        // Update is called once per frame
        void Update()
        {
            GaugesUpdate();
            gameCore.VladimirState.Sleepyness();
            gameCore.VladimirState.HeartBeat();
            gameCore.VladimirState.GeneratorUsage();
            Cardiogram();
        }

        private void GaugesUpdate()
        {
            float amountSleep = gameCore.VladimirState.sleep.current / gameCore.VladimirState.sleep.max;
            float amountLife = gameCore.VladimirState.heartBeat.current / gameCore.VladimirState.heartBeat.max;
            float amountDeaf = gameCore.VladimirState.deafness.current / gameCore.VladimirState.deafness.max;
            float amountPower = gameCore.VladimirState.energy.current / gameCore.VladimirState.energy.max;

            sleep.fillAmount = amountSleep;
            life.SetInteger("HeartBeat", heartBeatStatus);
            deaf.fillAmount = amountDeaf;
            energy.fillAmount = amountPower;
        }

        private void Cardiogram()
        {
            float currentHB = gameCore.VladimirState.heartBeat.current;

            if (currentHB == 0) heartBeatStatus = 0;
            else if (currentHB < 50) heartBeatStatus = 1;
            else if (currentHB < 100) heartBeatStatus = 2;
            else if (currentHB < 155) heartBeatStatus = 3;
            else heartBeatStatus = 4;
        }

        public float GetHeartBeatPhase()
        {
            return heartBeatStatus;
        }
    }
}