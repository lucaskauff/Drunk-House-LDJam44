using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boskov.Inputs;

namespace Boskov.Features
{
    [CreateAssetMenu(fileName = "new Generator Feature", menuName = "Features/Generator")]
    public class Generator : Features
    {
        [Header("Debug Values")]
        private bool first;
        private bool second;
        private bool third;
        private bool forth;
        

        public override bool Cast(MonoBehaviour _mono)
        {
            return Generate();
        }

        public bool Generate()
        {
            CheckPoints();
            return HandlePoints();
        }

        private bool HandlePoints()
        {
            bool result = false;

            if(first && second)
            {
                Validate();
                first = false;
                result = true;
            }
            else if(second && third)
            {
                Validate();
                second = false;
                result = true;
            }
            else if (third && forth)
            {
                Validate();
                third = false;
                result = true;
            }
            else if (forth && first)
            {
                Validate();
                forth = false;
                result = true;
            }
            else if(first)
            {
                Reset();
                first = true;
            }
            else if (second)
            {
                Reset();
                second = true;
            }
            else if (third)
            {
                Reset();
                third = true;
            }
            else if (forth)
            {
                Reset();
                forth = true;
            }

            return false;
        }

        private bool CheckAngle(float _angle, int _ref)
        {
            _ref += 100;
            return (_angle < _ref + 5 && _angle > _ref - 5);
        }

        private void CheckPoints()
        {
            Vector2 input = GameInput.Generator.GetAxisAsVector();
            if (input == Vector2.zero)
            {
                Reset();
                return;
            }
            float angle = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg;
            angle = (angle < 0 ? 360 + angle : angle) + 100;

            if (CheckAngle(angle, 0)) first = true;
            else if (CheckAngle(angle, 90)) forth = true;
            else if (CheckAngle(angle, 180)) third = true;
            else if (CheckAngle(angle, 270)) second = true;

        }

        private void Reset()
        {
            first = false;
            second = false;
            third = false;
            forth = false;
        }

        private void Validate()
        {
            gameCore.VladimirState.energy.Increase(energy/100);
        }
    }
}
