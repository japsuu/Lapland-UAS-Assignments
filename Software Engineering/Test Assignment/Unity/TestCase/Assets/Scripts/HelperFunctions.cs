using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperFunctions
{
    public float ComputeRange(float v, float angle) 
    {


        return (Mathf.Pow(v, 2) * Mathf.Sin((2 * angle) * Mathf.Deg2Rad)) / (DefaultValues.gravity*-1);
    }

    public float FlyTime(float v, float angle)
    {
        return (2 * v * Mathf.Sin(angle * Mathf.Deg2Rad)) / (DefaultValues.gravity*-1);
    }
}
