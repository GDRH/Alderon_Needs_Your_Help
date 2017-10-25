using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    /// <summary>
    /// Bugged to bits.
    /// </summary>
    /// <param name="transform"></param>
    /// <returns></returns>
    public static Vector3 degreeAngles(this Transform transform)
    {
        return (new Vector3(Mathf.Atan2(transform.up.z, transform.up.y) * Mathf.Rad2Deg + 180, Mathf.Atan2(1, transform.up.x) * Mathf.Rad2Deg + 180, Mathf.Atan2(1, transform.up.x) * Mathf.Rad2Deg + 180));
    }
}