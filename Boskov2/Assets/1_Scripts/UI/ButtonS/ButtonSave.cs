﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Boskov.Scores;

namespace Boskov.UI
{
    [CreateAssetMenu(fileName = "new Save Button", menuName = "Buttons/Save")]
    public class ButtonSave : ButtonUI
    {
        [SerializeField] private GameCoreData gameCore;

        public override void Do()
        {
            TextMeshProUGUI name = GameObject.Find("TextNamePlayer").GetComponent<TextMeshProUGUI>();
            gameCore.SaveScore(new Scores.Score(name.text, gameCore.scoreRounded));
            GameObject.Find("ScoreDisplay").GetComponent<ScoreManager>().SetScore();
            GameObject.Find("OtherButtonManager").GetComponent<UIButtonSelection>().isUsed = true;
            GameObject.Find("CanvasSaveScore").SetActive(false);
        }
    }
}