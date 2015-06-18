using UnityEngine;
using System;

public class DeviceTime : MonoBehaviour
{
    public TOD_Sky sky;

    protected void OnEnable()
    {
        if (!sky)
        {
            Debug.LogError("Sky instance reference not set. Disabling script.");
            this.enabled = false;
        }
        else
        {
            DateTime now = DateTime.Now;
            sky.Cycle.Year  = now.Year;
            sky.Cycle.Month = now.Month;
            sky.Cycle.Day   = now.Day;
            sky.Cycle.Hour  = now.Hour + now.Minute/60f;
        }
    }
}
