using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Boskov.Scores
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private GameCoreData gameCore;
        [SerializeField] private GameObject prefab;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetScore()
        {
            for (int i = 0; i < gameCore.scores.Length; i++)
            {
                GameObject score = Instantiate(prefab, transform);
                score.GetComponent<TextMeshProUGUI>().text = i.ToString() + ". " + GenerateLine(gameCore.scores[i]);
            }
        }

        private string GenerateLine(Score _score)
        {
            string result = "";

            result += _score.name + ": " + _score.score.ToString();

            return result;
        }
    }
}