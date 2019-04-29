using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echap : MonoBehaviour
{
    [SerializeField] GameObject rawImageUi;
    [SerializeField] GameObject micro;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                rawImageUi.SetActive(true);
                micro.SetActive(false);
            }
            else
            {
                Time.timeScale = 1;
                rawImageUi.SetActive(false);
                micro.SetActive(true);
            }
        }
    }
}
