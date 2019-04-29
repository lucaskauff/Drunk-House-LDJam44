using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boskov.UI
{
    [CreateAssetMenu(fileName = "new Skip Button", menuName = "Buttons/Skip")]
    public class ButtonSkip : ButtonUI
    {
        public override void Do()
        {
            GameObject.Find("CanvasSaveScore").SetActive(false);
        }
    }
}