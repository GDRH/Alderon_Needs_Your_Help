using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroLib{
    public class ZeroMaths
    {
        /// <summary>
        /// Plot a value from a given value, a range for the given value, and a range for the output value.
        /// </summary>
        /// <param name="values">Given value</param>
        /// <param name="minValue">Given range's minimum</param>
        /// <param name="maxValue">Given range's maximum</param>
        /// <param name="minRange">Output's range minimum</param>
        /// <param name="maxRange">Output's range maximum</param>
        /// <returns>Plotted Value</returns>
        public static float Map(float values, float minValue, float maxValue, float minRange, float maxRange)
        {
            return ((((values - minValue) / (maxValue - minValue)) * (maxRange - minRange)) + minRange);
        }
    }
}
