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
                score.GetComponent<TextMeshProUGUI>().text = Rank(i+1) + " " + GenerateLine(gameCore.scores[i]);
            }
        }

        private string GenerateLine(Score _score)
        {
            string result = "";

            result += _score.name + ": " + _score.score.ToString();

            return result;
        }

        private string Rank(int _rank)
        {
            string result = "";
            string value = _rank.ToString()[_rank.ToString().Length - 1].ToString();

            if (value == "1") result = _rank.ToString() + "st";
            else if (value == "2") result = _rank.ToString() + "nd";
            else if (value == "3") result = _rank.ToString() + "rd";
            else result = _rank.ToString() + "th";

            return result;
        }
    }
}