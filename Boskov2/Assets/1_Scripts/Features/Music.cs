using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boskov.Inputs;

namespace Boskov.Features
{
    [CreateAssetMenu(fileName = "new Music Feature", menuName = "Features/Music")]
    public class Music : Features
    {
        float time;
        bool used;

        public override bool Cast(MonoBehaviour _mono)
        {
            if (GameInput.PlayMusic.GetKeyDown() && !onCoolDown && !used)
            {
                onCoolDown = true;
                _mono.StartCoroutine(Delay(delay, _mono));
                return true;
            }
            else if(used && GameInput.PlayMusic.GetKey())
            {
                AffectDeaf();
            }
            else if(used)
            {
                used = false;
                _mono.StartCoroutine(CoolDown());
            }

            return false;
        }

        IEnumerator Delay(float _delay, MonoBehaviour _mono)
        {
            GameCoreData.events.CallPlayMusic();

            yield return new WaitForSeconds(_delay);
            used = true;

            GameCoreData.events.CallStopMusic();
        }

        IEnumerator AffectDeafCoroutine()
        {
            time = 0;
            float impact = 0;
            float value = 0;

            while (impact < deafness)
            {
                time += Time.deltaTime / duration;
                impact = Mathf.SmoothStep(0, deafness, time);
                if (!gameCore.VladimirState.deafness.Decrease(impact - value)) break;
                value = impact;
                yield return null;
            }
        }


        void AffectDeaf()
        {
            gameCore.VladimirState.deafness.Decrease(deafness * Time.deltaTime);
            float value = sleep * Time.deltaTime * (gameCore.VladimirState.deafness.current / gameCore.VladimirState.deafness.max);
            gameCore.VladimirState.sleep.Increase(value);
        }
    }
}
