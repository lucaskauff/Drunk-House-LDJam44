using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boskov.Inputs;

namespace Boskov.Features
{
    [CreateAssetMenu(fileName = "new Calm Feature", menuName = "Features/Calm")]
    public class Shake : Features
    {
        public float gaugeMax;
        public float gaugeCurrent;
        public float gaugeSpeed;
        public float gaugeIncrement;
        public bool used;

        //private float time;
        //private float amountInjected;

        public override bool Cast(MonoBehaviour _mono)
        {
            if (used) UpdateValue(_mono);

            if (!onCoolDown && !used && GameInput.Calm.GetKeyDown()) StartGauge();

            else if (GameInput.Calm.GetKeyDown() && used) GaugePush();

            return false;
        }

        private void UpdateValue(MonoBehaviour _mono)
        {
            if( gaugeCurrent > gaugeMax)
            {
                Activate(_mono);
                used = false;

                _mono.StartCoroutine(CoolDown());

                return;
            }

            gaugeCurrent -= Time.deltaTime * gaugeSpeed;

            if (gaugeCurrent < 0)
            {
                used = false;
                _mono.StartCoroutine(CoolDown());
            }
        }

        private void StartGauge()
        {
            onCoolDown = true;
            used = true;

            gaugeCurrent = gaugeMax / 10;
        }

        private void GaugePush()
        {
            gaugeCurrent += gaugeIncrement;
        }

        private void Activate(MonoBehaviour _mono)
        {
            Debug.Log("Succeed");
            _mono.StartCoroutine(AffectSleep());
            _mono.StartCoroutine(AffectHB());
        }

        IEnumerator AffectSleep()
        {
            float time = 0;
            float amountInjected = 0;
            float value = 0;

            while (time < duration)
            {
                time += (Time.deltaTime / duration);
                Debug.Log(time);
                amountInjected = Mathf.SmoothStep(0, sleep, time);
                if (!gameCore.VladimirState.sleep.Decrease(amountInjected - value)) break;
                value = amountInjected;
                yield return null;
            }

            Debug.Log("fini1");

        }

        IEnumerator AffectHB()
        {
            float time = 0;
            float value = 0;
            float amountHB = 0;

            while (time < duration)
            {
                time += ( Time.deltaTime / duration);
                amountHB = Mathf.SmoothStep(0, heartbeat, time);
                if (!gameCore.VladimirState.heartBeat.Decrease(amountHB - value)) break;
                value = amountHB;
                yield return null;
            }

            Debug.Log("fini2");
        }


    }
}
