using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boskov
{
    [CreateAssetMenu(fileName ="New GameCore", menuName ="GameCore")]
    public class GameCoreData : ScriptableObject
    {
        public static Events events = new Events();
        [Header("Inputs")]
        public Inputs.InputsTemplate InputsTemplate;
        public MicroData Voice;
        public Features.Features[] features;
        [Header("Game Data")]
        public Vladimir.VladimirState VladimirState;
        public float score;
        public float timePlayed;
        public bool finished;
    }

}