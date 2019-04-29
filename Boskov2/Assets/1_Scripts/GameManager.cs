using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boskov
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameCoreData gameCore;
        [SerializeField] private GameObject finish;

        private void Awake()
        {
            gameCore.LoadSave();
            gameCore.finished = false;
        }

        // Start is called before the first frame update
        void Start()
        {
            gameCore.score = 1;
            gameCore.timePlayed = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if(!gameCore.finished)IncreaseScore();
            if ((gameCore.VladimirState.heartBeat.current >= 220 || gameCore.VladimirState.heartBeat.current <= 0 || gameCore.VladimirState.sleep.current <= 0) && !gameCore.finished) StartCoroutine(Finish());
        }

        private void IncreaseScore()
        {
            gameCore.timePlayed += Time.deltaTime;
            gameCore.score = (Mathf.Pow(gameCore.timePlayed, 2)/60);

            gameCore.scoreRounded = Mathf.CeilToInt(gameCore.score);
        }

        private IEnumerator Finish()
        {
            gameCore.finished = true;
            float time = 0;
            while (time < 1)
            {
                time += .05f;
                Time.timeScale = Mathf.Clamp01(1 - time);
                yield return new WaitForSecondsRealtime(.05f);
            }

            Time.timeScale = 0;
            if(finish != null) finish.SetActive(true);
        }


    }
}