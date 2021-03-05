using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CalenderDay : MonoBehaviour
{
    public TextMeshProUGUI dayText;
    public TextMeshProUGUI descriptionText;
    Calender calender;
    public int day;
    public int weekday;
    public List<CalenderActivity> activities;
    public bool[] activitiesOn;
    public bool[] coffee;
    public string[] time;
    public string[] transportGreek;
    public string[] transportEnglish;
    public GameObject check;
    public bool isCompleted;

    void Start(){
        calender = GetComponentInParent<Calender>();
        
        isCompleted = false;
        activitiesOn = new bool[7];
        coffee = new bool[7];
        time = new string[7];
        transportGreek = new string[7];
        transportEnglish = new string[7];
        for (int i = 0; i < activitiesOn.Length; i++)
        {
            activitiesOn[i] = false;
        }

        if (dayText) dayText.text = day.ToString();
        if (descriptionText) descriptionText.text = "";
    }

    public void OnClick(){
        //print("click: "+name);
        calender.OpenDay(this);
    }
}
