using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Boskov
{
    public class Micro_Test : MonoBehaviour
    {
        public Material matMicro;
        public AudioClip _audioClip;
        private AudioSource _audioSource;
        public bool _useMicrophone;
        public string _selectedDevice;

        public SpriteRenderer target;
        public float clampMin;
        public float clampMax;

        public float updateStep = 0.1f;
        public int sampleDataLength = 1024;

        private float currentUpdateTime = 0f;

        private float clipLoudness;
        private float[] clipSampleData;


        // Start is called before the first frame update
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

        // Update is called once per frame
        void Update()
        {

            currentUpdateTime += Time.deltaTime;
            if (currentUpdateTime >= updateStep)
            {
                currentUpdateTime = 0f;
                _audioSource.clip.GetData(clipSampleData, _audioSource.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
                clipLoudness = 0f;
                foreach (var sample in clipSampleData)
                {
                    clipLoudness += Mathf.Abs(sample);
                }
                clipLoudness /= sampleDataLength; //clipLoudness is what you are looking for

            }

            Vector3 trans = target.transform.localPosition;
            trans.y = Mathf.Clamp(trans.y, clampMin, clampMax);
            trans.y -= clipLoudness * 3;
            target.transform.localPosition = trans;

            matMicro.SetFloat("_MicroInput", clipLoudness);

            if (clipLoudness >= 0.0256066f)
            {
                 matMicro.SetFloat("_IsRed",1);
            }
            else { matMicro.SetFloat("_IsRed", 0); }
        }
    }
}
