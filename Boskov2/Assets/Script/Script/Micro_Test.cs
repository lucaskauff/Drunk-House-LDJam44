using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Boskov
{
    public class Micro_Test : GameEvents
    {
        [SerializeField] private GameCoreData gameCore;

        public Material matMicro;
        public AudioClip _audioClip;
        private AudioSource _audioSource;
        public bool _useMicrophone;
        public bool _IsActive = false;
        public string _selectedDevice;

        public float clampMin;
        public float clampMax;

        public float updateStep = 0.1f;
        public int sampleDataLength = 1024;

        private float currentUpdateTime = 0f;

        private float clipLoudness;
        private float[] clipSampleData;

        public int whichMic;



        void Start()
        {
            _audioSource = GetComponent<AudioSource>();

            if (_useMicrophone)
            {
                if (Microphone.devices.Length > 0)
                {
                    _selectedDevice = Microphone.devices[0].ToString();
                    _audioSource.clip = Microphone.Start(_selectedDevice, true, 10, AudioSettings.outputSampleRate);
                }
                else
                {
                    _useMicrophone = false;
                }

            }

            _audioSource.Play();
            clipSampleData = new float[sampleDataLength];
        }


        void Update()
        {

            currentUpdateTime += Time.deltaTime;
            if (currentUpdateTime >= updateStep)
            {
                currentUpdateTime = 0f;
                _audioSource.clip.GetData(clipSampleData, _audioSource.timeSamples); 
                clipLoudness = 0f;
                foreach (var sample in clipSampleData)
                {
                    clipLoudness += Mathf.Abs(sample);
                }
                clipLoudness /= sampleDataLength;

            }

            if (clipLoudness >= 0.0256066f)
            {
                 matMicro.SetFloat("_IsRed",1);
                gameCore.Voice.valid = true;
            }
            else
            {
                matMicro.SetFloat("_IsRed", 0);
                gameCore.Voice.valid = false;

            }

            if (_IsActive == true) 
            {
                matMicro.SetFloat("_IsActive",1);
                matMicro.SetFloat("_MicroInput", clipLoudness);
            }
            else
            {
                matMicro.SetFloat("_IsActive",0);
                matMicro.SetFloat("_MicroInput", 0.001f);
            }
        }
    }
}
