using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boskov.Inputs;

namespace Boskov.Features
{
    [CreateAssetMenu(fileName = "new Eject Feature", menuName = "Features/Eject")]
    public class Eject : Features
    {
        bool left;
        bool right;

        public override bool Cast(MonoBehaviour _mono)
        {
            Attack(_mono);

            return false;
        }

        public void Attack(MonoBehaviour _mono)
        {
            if (GameInput.Eject.GetAxis() > .8f && !right) _mono.StartCoroutine(EjectRight());
            else if (GameInput.Eject.GetAxis() < -.8f && !left) _mono.StartCoroutine(EjectLeft());
        }

        private IEnumerator EjectRight()
        {
            GameCoreData.events.CallEjectRight();
            right = true;
            yield return new WaitForSeconds(coolDown);
            right = false;
        }

        private IEnumerator EjectLeft()
        {
            GameCoreData.events.CallEjectLeft();
            left = true;
            yield return new WaitForSeconds(coolDown);
            left = false;
        }
    }
}