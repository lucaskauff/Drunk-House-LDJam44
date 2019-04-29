using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boskov
{
    public static class EliesMethods
    {
        public static List<T> ToList<T>(this T[] _array)
        {
            List<T> result = new List<T>();

            for (int i = 0; i < _array.Length; i++)
            {
                result.Add(_array[i]);
            }

            return result;
        }
    }
}