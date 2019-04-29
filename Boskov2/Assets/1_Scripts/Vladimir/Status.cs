using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boskov.Vladimir
{
    [System.Serializable]
    public class Status
    {
        public int max;
        public float current;
        public float rate;

        public bool Increase(float _value)
        {
            if (current + _value > max && _value > 0)
            {
                current = max;
                return false;
            }

            current += _value;

            return true;
        }

        public bool Decrease(float _value)
        {
            if (current - _value < 0 && _value > 0)
            {
                current = 0;
                return false;
            }

            current -= _value;

            return true;
        }

        public void Initialize()
        {
            current = max;
        }

        public void Initialize(int _value)
        {
            current = _value;
        }

    }
}