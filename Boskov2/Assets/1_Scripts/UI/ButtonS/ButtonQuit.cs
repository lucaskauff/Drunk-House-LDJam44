using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boskov.UI
{
    [CreateAssetMenu(fileName = "new Quit Button", menuName = "Buttons/Quit")]
    public class ButtonQuit : ButtonUI
    {

        public override void Do()
        {
            Debug.Log("Application quit.");
            Application.Quit();
        }
    }
}