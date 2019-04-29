﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boskov.Inputs;

namespace Boskov.Features
{
    [CreateAssetMenu(fileName = "new Coffeenjection Feature", menuName = "Features/Coffeenjection")]
    public class Coffeenjection : Features
    {
        private float time;
        private float amountInjected;

        public override bool Cast(MonoBehaviour _mono)
        {
            if (GameInput.Coffeenjection.GetKeyDown() && !onCoolDown)
            {
                Debug.Log("COFFEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
                onCoolDown = true;
                _mono.StartCoroutine(Delay(delay, _mono));
                return true;
            }
            return false;
        }

        IEnumerator Delay(float _delay, MonoBehaviour _mono)
        {
            GameCoreData.events.CallCoffeenjectionStart();

            yield return new WaitForSeconds(_delay);

            _mono.StartCoroutine(CoolDown());
            _mono.StartCoroutine(AffectSleep());
            _mono.StartCoroutine(AffectHB());
            _mono.StartCoroutine(EnergyCost());

            GameCoreData.events.CallCoffeenjectionEnd();
        }

        IEnumerator AffectSleep()
        {
            float time = 0;
            float amountInjected = 0;
            float value = 0;

            while (time < duration)
            {
                time += (Time.deltaTime / duration);
                amountInjected = Mathf.SmoothStep(0, sleep, time);
                if (!gameCore.VladimirState.sleep.Increase(amountInjected-value)) break;
                value = amountInjected;
                yield return null;
            }

        }

        IEnumerator AffectHB()
        {
            float time = 0;
            float value = 0;
            float amountHB = 0;

            while (time < duration)
            {
                time += (Time.deltaTime / duration);
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
                amountInjected = Mathf.SmoothStep(0, sleep, time);
                if (!gameCore.VladimirState.energy.Decrease(amountInjected - value)) break;
                value = amountInjected;
                yield return null;
            }
        }


    }
}
