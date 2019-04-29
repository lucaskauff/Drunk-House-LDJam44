using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boskov.Inputs;

namespace Boskov
{
    public class Audio_Manager : MonoBehaviour
    {
        [SerializeField] private GameCoreData gameCore;

        [SerializeField] private AudioSource Music;
        [SerializeField] private AudioSource generatorWAV;
        [SerializeField] private AudioSource cafeWAV;
        [SerializeField] private AudioSource waterfallWAV;
        [SerializeField] private AudioSource whiteNoiseWAV;
        [SerializeField] private AudioSource cynballeWAV;
        [SerializeField] private AudioSource autistWAV;

        private bool generatorB;
        private bool autistB;
        private bool whiteNoiseB;

        // Start is called before the first frame update
        void Start()
        { 
            Music.Play();
        }

        // Update is called once per frame
        void Update()
        {
            LoopAudio();
            SingleAudio();
        }

        void LoopAudio()
        {
            if(GameInput.Generator.GetKey()) 
            {
                if(generatorB == true)
                {
                    generatorWAV.Play();
                    generatorB = false;
                }
            }
            else 
            {
                generatorB = true;
                generatorWAV.Stop();
            }

            if(gameCore.VladimirState.energy.current == 0) 
            {
                if(whiteNoiseB == true)
                {
                    whiteNoiseWAV.Play();
                    whiteNoiseB = false;
                }
            }
            else 
            {
                whiteNoiseB = true;
                whiteNoiseWAV.Stop();
            }

            /* if(GameInput.Generator.GetKey()) //////////// AUTISM
            {
                if(autistB == true)
                {
                    generatorWAV.Play();
                    autistB = false;
                }
            }
            else {autistB = true;}*/
        }

        void SingleAudio()
        {
            if(GameInput.PlayMusic.GetKeyDown() /* && !gameCore.features[2].onCoolDown*/) 
            {
                StartCoroutine(Cynballe());
            }

            if(GameInput.Water.GetKeyDown()  && !gameCore.features[1].onCoolDown) 
            {
                StartCoroutine(Water());
            }

            if(GameInput.Coffeenjection.GetKeyDown()  && !gameCore.features[3].onCoolDown) 
            {
                StartCoroutine(Cafe());
            }
        }

        IEnumerator Cynballe()
        {
            yield return new WaitForSeconds(1.0f);
            cynballeWAV.Play();
            yield return new WaitForSeconds(0.5f);
            //cynballeWAV.Stop();
            cynballeWAV.Play();
        }

        IEnumerator Water()
        {
            yield return new WaitForSeconds(1.70f);
            waterfallWAV.Play();
        }

        IEnumerator Cafe()
        {
            yield return new WaitForSeconds(4.5f);
            cafeWAV.Play();
        }
    }
}