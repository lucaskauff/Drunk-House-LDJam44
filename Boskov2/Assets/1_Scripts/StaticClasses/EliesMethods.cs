using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boskov.Scores;

namespace Boskov
{
    public static class EliesMethods
    {
        public static List<T> ToList2<T>(this T[] _array)
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