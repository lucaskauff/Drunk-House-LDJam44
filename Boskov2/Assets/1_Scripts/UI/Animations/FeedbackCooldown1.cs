using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Boskov.Features;

namespace Boskov
{
    public class FeedbackCooldown1 : MonoBehaviour
    {
        [SerializeField] private GameCoreData gameCoreData = default;
        [SerializeField] private Image myImage = default;

        private void Update()
        {
            Shake calm = gameCoreData.features[4] as Shake;
            myImage.fillAmount = 1 - (calm.gaugeCurrent / calm.gaugeMax);
        }
    }
}