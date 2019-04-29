using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Boskov.UI
{
    [CreateAssetMenu(fileName = "new Restart Button", menuName = "Buttons/Restart")]
    public class ButtonRestart : ButtonUI
    {

        public override void Do()
        {
            SceneManager.LoadScene(1);
        }
    }
}
