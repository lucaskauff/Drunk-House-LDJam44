using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Boskov
{
    public class Menu_Manager : GameEvents
    {
        [SerializeField] private UIButton playButton;
        [SerializeField] private UIButton exitButton;

        [SerializeField] private Image playRender;
        [SerializeField] private Image exitRender;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            SelectButton();
            ImagesManager(playRender, playButton);
            ImagesManager(exitRender, exitButton);
            Selection();
        }

        private void SelectButton()
        {
            if (Input.GetAxis("JS_LeftStick_X_Axis") < 0 || Input.GetAxis("JS_RightStick_X_Axis") < 0)
            {
                playButton.selected = true;
                exitButton.selected = false;
            }
            else if (Input.GetAxis("JS_LeftStick_X_Axis") > 0 || Input.GetAxis("JS_RightStick_X_Axis") > 0)
            {
                playButton.selected = false;
                exitButton.selected = true;
            }
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
            if(Select())
            {
                if (exitButton.selected) Quit();
                else if (playButton.selected) ChangeScene();
            }
        }

        public void Quit()
        {
            Debug.Log("Quit.");
            Application.Quit();
        }

        public void ChangeScene()
        {
            Debug.Log("Play Scene");
            //SceneManager.LoadSceneAsync(1);
        }

        private void ImagesManager(Image _render, UIButton _button)
        {
            _render.sprite = _button.selected ? _button.selectedImage : _button.unselectedImage;
        }
    }

    [System.Serializable]
    public struct UIButton
    {
        public Sprite selectedImage;
        public Sprite unselectedImage;
        public bool selected;
    }
}
