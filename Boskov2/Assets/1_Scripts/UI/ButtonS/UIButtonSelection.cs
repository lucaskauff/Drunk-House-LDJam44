using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Boskov.UI
{
    public class UIButtonSelection : MonoBehaviour
    {
        [SerializeField] private ButtonUI[] buttons;
        [SerializeField] private Image[] buttonRenderers;

        private bool onCoolDown;
        private int index;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            IndexManager();
            Selection();
        }

        private bool Select()
        {
            for (int i = 330; i < 350; i++)
            {
                if (Input.GetKeyDown((KeyCode)i)) return true;
            }

            return false;
        }

        private void Selection()
        {
            if (Select())
            {
                foreach (ButtonUI button in buttons)
                {
                    if (button.selected) button.Do();
                }
            }
        }

        private void IndexManager()
        {
            if ((Input.GetAxis("JS_LeftStick_X_Axis") != 0 || Input.GetAxis("JS_RightStick_X_Axis") != 0) && !onCoolDown)
            {
                if (Input.GetAxis("JS_LeftStick_X_Axis") < 0 || Input.GetAxis("JS_RightStick_X_Axis") < 0)
                {
                    index--;
                }
                else if (Input.GetAxis("JS_LeftStick_X_Axis") > 0 || Input.GetAxis("JS_RightStick_X_Axis") > 0)
                {
                    index++;
                }

                index = Mathf.Clamp(index, 0, buttons.Length - 1);

                SelectButton(index);
                StartCoroutine(CoolDown());
            }
        }

        private void SelectButton(int _index)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].selected = (i == _index);
                buttonRenderers[i].sprite = buttons[i].activeSprite();
            }
        }

        IEnumerator CoolDown()
        {
            onCoolDown = true;

            yield return new WaitForSeconds(.5f);

            onCoolDown = false;
        }
    }
}