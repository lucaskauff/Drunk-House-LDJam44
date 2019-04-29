using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Boskov.Scores;

namespace Boskov
{
    [CreateAssetMenu(fileName ="New GameCore", menuName ="GameCore")]
    public class GameCoreData : ScriptableObject
    {
        public static Events events = new Events();
        [Header("Inputs")]
        public Inputs.InputsTemplate InputsTemplate;
        public MicroData Voice;
        public Features.Features[] features;
        [Header("Game Data")]
        public Vladimir.VladimirState VladimirState;
        public float timePlayed;
        public bool finished;
        [Header("Game Score")]
        public float score;
        public int scoreRounded;
        public Score[] scores;

        public void LoadSave()
        {
            string filePath = Application.persistentDataPath + "/score.json";

            if (!File.Exists(filePath))
            {
                Debug.Log("No save to load.");
                return;
            }

            scores = JsonUtility.FromJson<Score[]>(File.ReadAllText(filePath));
        }

        public void SaveScore(Score _score)
        {
            List<Score> tmp = scores.ToList();
            tmp.Add(_score);

            tmp = (List<Score>)tmp.OrderBy(item => item.score);

            while (tmp.Count>10)
            {
                tmp.RemoveAt(tmp.Count - 1);
            }

            scores = tmp.ToArray();

            string filePath = Application.persistentDataPath + "/score.json";

            Debug.Log("Saving game at: " + filePath + ".");

            File.WriteAllText(filePath, JsonUtility.ToJson(scores, true));

        }
    }

}