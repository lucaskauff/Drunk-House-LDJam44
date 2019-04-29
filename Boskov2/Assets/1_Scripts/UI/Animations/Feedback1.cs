using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boskov
{
    public class Feedback1 : MonoBehaviour
    {
        [SerializeField] private GameCoreData gameCoreData = default;
        [SerializeField] private Animator myAnim = default;
        [SerializeField] private int whatFeature = 0;

        private void Update()
        {
            myAnim.SetBool("IsLocked", gameCoreData.features[whatFeature].onCoolDown);
        }
    }
}