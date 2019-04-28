using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boskov
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameCoreData gameCore;
        

        // Start is called before the first frame update
        void Start()
        {
            gameCore.score = 0;
        }

        // Update is called once per frame
        void Update()
        {
            IncreaseScore();
        }

        private void IncreaseScore()
        {
            gameCore.timePlayed += Time.deltaTime;
            gameCore.score = Mathf.RoundToInt((Mathf.Pow(gameCore.score,2)/60) * Time.deltaTime);
        }
    }
}