using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boskov.Inputs
{
    public static class GameInputsCore 
    {
        /*public static InputsCode[] assignations = new InputsCode[]
        {
            InputsCode.ButtonX, // Water            0
            InputsCode.RightTrigger, // PlayMusic   1
            InputsCode.ButtonB, // Coffenjection    2
            InputsCode.DPadHorizontal, // Chair     3
            InputsCode.LeftJoystick, // Generator   4
            InputsCode.ButtonA, // Door             5
            InputsCode.RightJoystick // Eject       6
        };*/

        public static InputsCode[][] assignations = new InputsCode[][]
         {
            new InputsCode[] {InputsCode.ButtonX }, // Voic            0
            new InputsCode[] {InputsCode.ButtonX }, // Water           1
            new InputsCode[] {InputsCode.RightTrigger}, // PlayMusic   2
            new InputsCode[] {InputsCode.ButtonB}, // Coffenjection    3
            new InputsCode[] {InputsCode.DPadHorizontal}, // Chair     4
            new InputsCode[] {InputsCode.LeftJoystick}, // Generator   5
            new InputsCode[] {InputsCode.ButtonY}, // Calm             6
            new InputsCode[] {InputsCode.RightJoystick} // Eject       7
         };

        public static void EditKeyInput(this GameInput _gameInput, InputsCode[] _key)
        {
            assignations[(int)_gameInput] = _key;
        }

        public static bool triggerLeft { get; private set; }
        public static bool triggerRight { get; private set; }

        public static void SetBoolTriggerLeft(bool _value)
        {
            triggerLeft = _value;
        }

        public static void SetBoolTriggerRight(bool _value)
        {
            triggerRight = _value;
        }

        public static bool GetKeyDown(this GameInput _input)
        {
            bool getkey = false;
            bool getkeyDown = false;

            for (int i = 0; i < assignations[(int)_input].Length; i++)
            {
                if (GetKeyDown(assignations[(int)_input][i]))
                {
                    getkeyDown = true;
                    break;
                }
            }

            for (int i = 0; i < assignations[(int)_input].Length; i++)
            {
                if (GetKeyDown(assignations[(int)_input][i]))
                {
                    getkey = true;
                    break;
                }
            }

            return (getkey && getkeyDown);
        }

        private static bool GetKeyDown(InputsCode _input)
        {
            switch (_input)
            {
                case InputsCode.LeftTrigger:
                    return triggerLeft;
                case InputsCode.RightTrigger:
                    return triggerRight;
                case InputsCode.LeftButton:
                    return Input.GetKeyDown(KeyCode.JoystickButton4);
                case InputsCode.RightButton:
                    return Input.GetKeyDown(KeyCode.JoystickButton5);
                case InputsCode.ButtonA:
                    return Input.GetKeyDown(KeyCode.JoystickButton0);
                case InputsCode.ButtonB:
                    return Input.GetKeyDown(KeyCode.JoystickButton1);
                case InputsCode.ButtonX:
                    return Input.GetKeyDown(KeyCode.JoystickButton2);
                case InputsCode.ButtonY:
                    return Input.GetKeyDown(KeyCode.JoystickButton3);
                case InputsCode.ButtonBack:
                    return Input.GetKeyDown(KeyCode.JoystickButton6);
                case InputsCode.ButtonStart:
                    return Input.GetKeyDown(KeyCode.JoystickButton7);
                case InputsCode.ButtonJoystickLeft:
                    return Input.GetKeyDown(KeyCode.JoystickButton8);
                case InputsCode.ButtonJoystickRight:
                    return Input.GetKeyDown(KeyCode.JoystickButton9);
                default:
                    return false;
            }
        }

        public static float GetAxis(this GameInput _input)
        {
            return GetAxis(assignations[(int)_input][0]);
        }

        private static float GetAxis(InputsCode _key)
        {
            //if ((int)_key < 5) return 0;

            switch (_key)
            {
                case InputsCode.LeftJoystickHorizontal:
                    return Input.GetAxis("JS_LeftStick_X_Axis");
                case InputsCode.LeftJoystickVertical:
                    return Input.GetAxis("JS_LeftStick_Y_Axis");
                case InputsCode.RightJoystickHorizontal:
                    return Input.GetAxis("JS_RightStick_X_Axis");
                case InputsCode.RightJoystickVertical:
                    return Input.GetAxis("JS_RightStick_Y_Axis");
                case InputsCode.LeftTrigger:
                    return Input.GetAxis("JS_LeftTrigger");
                case InputsCode.RightTrigger:
                    return Input.GetAxis("JS_RightTrigger");
                case InputsCode.DPadHorizontal:
                    return Input.GetAxis("JS_DPad_X");
                case InputsCode.DPadVertical:
                    return Input.GetAxis("JS_DPad_Y");
                case InputsCode.DPad:
                    return (new Vector2(Input.GetAxis("JS_DPad_X"),Input.GetAxis("JS_DPad_Y"))).magnitude;
                case InputsCode.LeftJoystick:
                    return (new Vector2(Input.GetAxis("JS_LeftStick_X_Axis"), Input.GetAxis("JS_LeftStick_Y_Axis"))).magnitude;
                case InputsCode.RightJoystick:
                    return (new Vector2(Input.GetAxis("JS_RightStick_Y_Axis"), Input.GetAxis("JS_RightStick_Y_Axis"))).magnitude;
                case InputsCode.Triggers:
                    return (new Vector2(Input.GetAxis("JS_LeftTrigger"), Input.GetAxis("JS_RightTrigger"))).magnitude;
                default:
                    return 0;
            }
        }

        public static Vector2 GetAxisAsVector(this GameInput _input)
        {
            return GetAxisAsVector(assignations[(int)_input][0]);
        }

        private static Vector2 GetAxisAsVector(InputsCode _key)
        {
            switch (_key)
            {
                case InputsCode.LeftJoystickHorizontal:
                    return new Vector2(GetAxis(_key),0);
                case InputsCode.LeftJoystickVertical:
                    return new Vector2(0, GetAxis(_key));
                case InputsCode.RightJoystickHorizontal:
                    return new Vector2(GetAxis(_key), 0);
                case InputsCode.RightJoystickVertical:
                    return new Vector2(0, GetAxis(_key));
                case InputsCode.DPadHorizontal:
                    return new Vector2(GetAxis(_key), 0);
                case InputsCode.DPadVertical:
                    return new Vector2(0, GetAxis(_key));
                case InputsCode.LeftTrigger:
                    return new Vector2(GetAxis(_key)*2-1, 0);
                case InputsCode.RightTrigger:
                    return new Vector2(0, GetAxis(_key)*2-1);
                case InputsCode.LeftJoystick:
                    return new Vector2(GetAxis(InputsCode.LeftJoystickHorizontal), GetAxis(InputsCode.LeftJoystickVertical));
                case InputsCode.RightJoystick:
                    return new Vector2(GetAxis(InputsCode.RightJoystickHorizontal), GetAxis(InputsCode.RightJoystickVertical));
                case InputsCode.DPad:
                    return new Vector2(GetAxis(InputsCode.DPadHorizontal), GetAxis(InputsCode.DPadVertical));
                case InputsCode.Triggers:
                    return new Vector2(GetAxis(InputsCode.LeftTrigger), GetAxis(InputsCode.RightTrigger));
                default:
                    return Vector2.zero;
            }
        }

        public static InputsCode[] ToAxisKey(this InputsCode _axis)
        {
            InputsCode[] result = new InputsCode[2];

            switch (_axis)
            {
                case InputsCode.LeftJoystick:
                    result[0] = InputsCode.LeftJoystickHorizontal;
                    result[1] = InputsCode.LeftJoystickVertical;
                    break;
                case InputsCode.RightJoystick:
                    result[0] = InputsCode.RightJoystickHorizontal;
                    result[1] = InputsCode.RightJoystickVertical;
                    break;
                case InputsCode.DPad:
                    result[0] = InputsCode.DPadHorizontal;
                    result[1] = InputsCode.DPadVertical;
                    break;
                case InputsCode.Triggers:
                    result[0] = InputsCode.LeftTrigger;
                    result[1] = InputsCode.RightTrigger;
                    break;
                default:
                    result[0] = _axis;
                    result[1] = _axis;
                    break;
            }

            return result;
        }

        public static bool GetKey(this GameInput _input)
        {
            for (int i = 0; i < assignations[(int)_input].Length; i++)
            {
                Debug.Log(assignations[(int)_input][i]+" : "+GetKey(assignations[(int)_input][i]));
                if (!GetKey(assignations[(int)_input][i])) return false;
            }

            return true;
        }

        private static bool GetKey(InputsCode _key)
        {
            switch (_key)
            {
                case InputsCode.LeftButton:
                    return Input.GetKey(KeyCode.JoystickButton4);
                case InputsCode.RightButton:
                    return Input.GetKey(KeyCode.JoystickButton5);
                case InputsCode.ButtonA:
                    return Input.GetKey(KeyCode.JoystickButton0);
                case InputsCode.ButtonB:
                    return Input.GetKey(KeyCode.JoystickButton1);
                case InputsCode.ButtonX:
                    return Input.GetKey(KeyCode.JoystickButton2);
                case InputsCode.ButtonY:
                    return Input.GetKey(KeyCode.JoystickButton3);
                case InputsCode.ButtonBack:
                    return Input.GetKey(KeyCode.JoystickButton6);
                case InputsCode.ButtonStart:
                    return Input.GetKey(KeyCode.JoystickButton7);
                case InputsCode.ButtonJoystickLeft:
                    return Input.GetKey(KeyCode.JoystickButton8);
                case InputsCode.ButtonJoystickRight:
                    return Input.GetKey(KeyCode.JoystickButton9);
                default:
                    return GetAxis(_key) != 0;
            }
        }
    }
}