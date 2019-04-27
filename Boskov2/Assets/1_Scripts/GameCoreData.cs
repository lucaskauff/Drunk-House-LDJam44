using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boskov
{
    [CreateAssetMenu(fileName ="New GameCore", menuName ="GameCore")]
    public class GameCoreData : ScriptableObject
    {
        [Header("Inputs")]
        public Inputs.InputsTemplate InputsTemplate;
        public Features.Features features;
        //[Header("Game Data")]
    }

}