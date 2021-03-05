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
    CalenderDay nowDay;
    public CalenderProgressBar progressBar;
    public GameObject[] panels;
    public GameObject map;

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
        nowDay = day;

        OpenPanel(0);

        string newTextEnglish = ((Weekday)day.weekday).ToString() + " " + day.day + " March";
        string newTextGreek = ((WeekdayGreek)day.weekday).ToString() + " " + day.day + " Μαρτίου";

        TextLanguage tl = cw1DayTitleText.GetComponent<TextLanguage>();
        tl.textGreek = newTextGreek;
        tl.textEnglish = newTextEnglish;
        tl.SetLanguage();

        dayCanvas.SetActive(true);
    }

    public void CloseDay(){
        dayCanvas.SetActive(false);
    }

    public void SetDayActivityOn(int index){
        nowDay.activitiesOn[index] = !nowDay.activitiesOn[index];
    }

    public void SetCoffee(int index){
        nowDay.coffee[index] = !nowDay.coffee[index];
    }

    public void OpenPanel(int index){
        int counter = 0;
        for (int i = 0; i < 7; i++)
        {
            if (nowDay.activitiesOn[i]) {
                counter++;
                //CalenderActivity c = new CalenderActivity();
                //c.SetType
                //nowDay.activities.Add(c);
            }
        }
        if (panels[0].activeInHierarchy && index == 1){


            bool[] b = new bool[7];
            for (int k = 0; k < b.Length; k++)
            {
                b[k] = nowDay.activitiesOn[k];
            }
            for (int i = 1; i < 2; i++)
            {
                int tempCounter = counter;
                Transform parent = panels[i].transform.GetChild(1);
                for (int j = 1; j < 8; j++)
                {
                    GameObject target = parent.GetChild(j).gameObject;
                    if (tempCounter > 0){
                        int tempIndex = 1;
                        for (int k = 0; k < b.Length; k++)
                        {
                            if (b[k]){
                                b[k] = false;
                                tempIndex = k;
                                break;
                            }
                        }
                        target.GetComponentInChildren<TextLanguage>().SetTo(panels[0].transform.GetChild(1).GetChild(tempIndex+1).GetComponentInChildren<TextLanguage>());
                        target.SetActive(true);
                    }
                    else target.SetActive(false);
                    tempCounter--;
                }
            }
        }
        for (int i = 0; i < panels.Length; i++)
        {
            if (panels[i] != null) panels[i].SetActive(i == index);
        }
        progressBar.SetToStep(index);
    }

    public void Send(){
        nowDay.check.SetActive(true);
        CloseDay();
        map.SetActive(true);
    }

    public void CloseMap(){
        map.SetActive(false);
    }
}
