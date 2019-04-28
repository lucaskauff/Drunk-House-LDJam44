using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boskov.Inputs
{
    public enum GameInput
    {
        Voice,
        Water,
        PlayMusic,
        Coffeenjection,
        Chair,
        Generator,
        Calm,
        Eject
    }
    public enum AxisCode {LeftJoystickHorizontal, LeftJoystickVerticl, RightJoystickHorizontal, RightJoystickVertical, DPadHorizontal, DPadVertical, LeftTrigger, RightTrigger }
    public enum Axis {LeftJoystick, RightJoystick, DPad, Triggers }
    public enum InputType { KeyCode, AxisCode, Axis}
    public enum InputsCode
    {
        LeftJoystickHorizontal,
        LeftJoystickVertical,
        RightJoystickHorizontal,
        RightJoystickVertical,
        DPadHorizontal,
        DPadVertical,
        LeftTrigger,
        RightTrigger,
        LeftJoystick,
        RightJoystick,
        DPad,
        Triggers,
        LeftButton,
        RightButton, 
        ButtonA,
        ButtonB, 
        ButtonX, 
        ButtonY, 
        ButtonBack,
        ButtonStart,
        ButtonJoystickLeft,
        ButtonJoystickRight,
    }
}