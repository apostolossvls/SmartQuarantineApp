using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalenderProgressBar : MonoBehaviour
{
    public GameObject[] steps;
    public Slider bar;

    // Update is called once per frame
    public void SetToStep(int value)
    {
        for (int i = 0; i < steps.Length; i++)
        {
            steps[i].SetActive(i == value);
        }
        bar.value = 1 + value * 2;
    }
}
