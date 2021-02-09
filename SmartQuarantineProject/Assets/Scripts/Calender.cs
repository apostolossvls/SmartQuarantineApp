using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum Weekday {Sunday = 0, Monday = 1, Tuesday = 2, Wednesday = 3, Thursday = 4, Friday = 5, Saturday = 6};
public enum WeekdayGreek {Κυριακή = 0, Δευτέρα = 1, Τρίτη = 2, Τετάρτη = 3, Πέμπτη = 4, Παρασκευή = 5, Σάββατο = 6};

public class Calender : MonoBehaviour
{
    public GameObject diplay;
    public GameObject titleDisplay;
    public GameObject uiDisplay;
    public bool isOn;
    public GameObject dayCanvas;
    [Header("Day Canvas UI")]
    public TextMeshProUGUI cw1DayTitleText;
    [Header("Days")]
    public CalenderDay[] days;

    void Start(){
        SetCalender(!isOn);
    }

    //toggle calender
    public void SetCalender(){
        isOn = !isOn;
        diplay.SetActive(isOn);
        titleDisplay.SetActive(isOn);
        uiDisplay.SetActive(isOn);
    }
    
    //set isOn to opposite of newIsOn so on SetCalender isOn = newIsOn
    public void SetCalender(bool newIsOn){
        isOn = !newIsOn;
        SetCalender();
    }

    public void OpenDay(CalenderDay day){
        string newTextEnglish = ((Weekday)day.weekday).ToString() + " " + day.day + " February";
        string newTextGreek = ((WeekdayGreek)day.weekday).ToString() + " " + day.day + " Φεβρουαρίου";

        TextLanguage tl = cw1DayTitleText.GetComponent<TextLanguage>();
        tl.textGreek = newTextGreek;
        tl.textEnglish = newTextEnglish;
        tl.SetLanguage();

        dayCanvas.SetActive(true);
    }

    public void CloseDay(){
        dayCanvas.SetActive(false);
    }
}
