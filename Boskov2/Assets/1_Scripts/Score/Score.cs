using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boskov.Scores
{
    [System.Serializable]
    public class Score
    {
        public string name;
        public int score;

        public Score(string _name, int _score)
        {
            score = _score;
            name = _name;
        }
    }

}