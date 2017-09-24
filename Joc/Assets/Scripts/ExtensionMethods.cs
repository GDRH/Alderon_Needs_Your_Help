using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    //This Works but i wnat to have degreeAngles.x or .y or .z, for the sake of somplicity
    /*public static float degreeAnglesX(this Transform transform)
    {
        return (Mathf.Atan2(transform.forward.z, transform.forward.y) * Mathf.Rad2Deg + 180);
    }
    public static float degreeAnglesY(this Transform transform)
    {
        return (Mathf.Atan2(transform.forward.z, transform.forward.x) * Mathf.Rad2Deg + 180);
    }
    public static float degreeAnglesZ(this Transform transform)
    {
        return (Mathf.Atan2(transform.forward.y, transform.forward.x) * Mathf.Rad2Deg + 180);
    }*/
    public static Vector3 degreeAngles(this Transform transform)
    {
        return (new Vector3(Mathf.Atan2(transform.up.z, transform.up.y) * Mathf.Rad2Deg + 180, Mathf.Atan2(1, transform.up.x) * Mathf.Rad2Deg + 180, Mathf.Atan2(1, transform.up.x) * Mathf.Rad2Deg + 180));
    }
}