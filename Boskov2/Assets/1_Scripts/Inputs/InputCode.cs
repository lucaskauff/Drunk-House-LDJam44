using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boskov.Inputs
{
    [System.Serializable]
    public class InputCode
    {
        public InputType type;

        public KeyCode keyCode;
        public AxisCode axisCode;
        public Axis axis;

        public object Value
        {
            get
            {
                switch (type)
                {
                    case InputType.KeyCode:
                        return keyCode;
                    case InputType.AxisCode:
                        return axisCode;
                    case InputType.Axis:
                        return axis;
                    default:
                        return null;
                }
            }
        }
    }
}