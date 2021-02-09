using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEventSend : MonoBehaviour
{
    public Thermometer thermometer;
    public void CalculateTemperatureEnd()
    {
        thermometer.CalculateTemperatureEnd();
    }
}
