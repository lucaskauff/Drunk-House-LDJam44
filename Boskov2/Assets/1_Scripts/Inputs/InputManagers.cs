using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boskov.Inputs
{
    public class InputManagers : MonoBehaviour
    {
        [SerializeField] private GameCoreData gameCore;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            gameCore.features[0].Cast(this);
        }
    }
}