using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boskov.Inputs;

namespace Boskov.Features
{
    [CreateAssetMenu(fileName = "new Water Feature", menuName = "Features/Water")]
    public class Water : Features
    {
        public float water;

        public override bool Cast(MonoBehaviour _mono)
        {
            if (GameInput.Water.GetKeyDown()) Debug.Log("ça mouille");

            return false;
        }
    }
}