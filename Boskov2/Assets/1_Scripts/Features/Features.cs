using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boskov.Features
{
    public abstract class Features : ScriptableObject
    {
        public abstract bool Cast(MonoBehaviour _mono);
    }
}