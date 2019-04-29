using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boskov.Inputs;

namespace Boskov.Features
{
    [CreateAssetMenu(fileName = "new Water Feature", menuName = "Features/Water")]
    public class Water : Features
    {
        private float time;
        private float amountInjected;

        public override bool Cast(MonoBehaviour _mono)
        {
            if (GameInput.Water.GetKeyDown() && !onCoolDown && gameCore.VladimirState.energy.current > energy)
            {
                Debug.Log("Plouf");
                onCoolDown = true;
                _mono.StartCoroutine(Delay(delay, _mono));
                return true;
            }
            return false;
        }

        IEnumerator Delay(float _delay, MonoBehaviour _mono)
        {
            GameCoreData.events.CallWaterBucket();

            yield return new WaitForSeconds(_delay);

            _mono.StartCoroutine(CoolDown());
            _mono.StartCoroutine(AffectSleep());
            _mono.StartCoroutine(AffectHB());
            _mono.StartCoroutine(EnergyCost());
        }

        IEnumerator AffectSleep()
        {
            time = 0;
            amountInjected = 0;
            float value = 0;

            while (amountInjected < sleep)
            {
                time += Time.deltaTime / duration;
                amountInjected = Mathf.SmoothStep(0, sleep, time);
                if (!gameCore.VladimirState.sleep.Increase(amountInjected - value)) break;
                value = amountInjected;
                yield return null;
            }
        }

        IEnumerator AffectHB()
        {
            float value = 0;
            float amountHB = 0;

            while (amountInjected < sleep)
            {
                amountHB = Mathf.SmoothStep(0, heartbeat, time);
                if (!gameCore.VladimirState.heartBeat.Increase(amountHB - value)) break;
                value = amountHB;
                yield return null;
            }
        }

        IEnumerator EnergyCost()
        {
            float time = 0;
            float amountInjected = 0;
            float value = 0;

            while (time < duration)
            {
                time += (Time.deltaTime / duration);
                Debug.Log(time);
                amountInjected = Mathf.SmoothStep(0, sleep, time);
                if (!gameCore.VladimirState.energy.Decrease(amountInjected - value)) break;
                value = amountInjected;
                yield return null;
            }
        }
    }
}