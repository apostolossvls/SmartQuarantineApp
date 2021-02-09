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

    void Start(){
        calender = GetComponentInParent<Calender>();

        if (dayText) dayText.text = day.ToString();
        if (descriptionText) descriptionText.text = "";
    }

    public void OnClick(){
        print("click: "+name);
        calender.OpenDay(this);
    }
}
