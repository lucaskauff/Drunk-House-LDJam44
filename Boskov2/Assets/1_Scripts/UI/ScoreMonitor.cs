using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Boskov
{
    public class ScoreMonitor : MonoBehaviour
    {
        [SerializeField] private GameCoreData gameCore;
        [SerializeField] private TextMeshProUGUI monitor;
        [SerializeField] private bool useInUpdate;

        private void OnEnable()
        {
            monitor.text = gameCore.scoreRounded.ToString();
        }

        // Update is called once per frame
        void Update()
        {
            if(useInUpdate) monitor.text = gameCore.scoreRounded.ToString();
        }
    }
}