using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boskov.Scores;

namespace Boskov.UI
{
    [CreateAssetMenu(fileName = "new Skip Button", menuName = "Buttons/Skip")]
    public class ButtonSkip : ButtonUI
    {
        public override void Do()
        {
            GameObject.Find("ScoreDisplay").GetComponent<ScoreManager>().SetScore();
            GameObject.Find("OtherButtonManager").GetComponent<UIButtonSelection>().isUsed = true;
            GameObject.Find("CanvasSaveScore").SetActive(false);
        }
    }
}