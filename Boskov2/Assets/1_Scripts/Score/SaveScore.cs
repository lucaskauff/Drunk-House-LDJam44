using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boskov.Scores
{
    [System.Serializable]
    public class SaveScore
    {
        public Score[] score;

        public SaveScore(Score[] _score)
        {
            score = _score;
        }
        
    }
}