using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public Transform[] mainItems;
    public Transform[] coffeeItems;
    public Transform[] timeItems;
    public Transform[] transportItems;
    public Transform[] endItems;
    public GameObject map;
    bool[] activityEnabled;

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

        Toggle2[] toggles  = dayCanvas.GetComponentsInChildren<Toggle2>(true) as Toggle2[];
        foreach (Toggle2 toggle in toggles)
        {
            toggle.Set(false);
        }

        activityEnabled = new bool[7];
        for (int i = 0; i < activityEnabled.Length; i++)
        {
            if (nowDay.isCompleted && nowDay.activities.Count > i) activityEnabled[i] = true;
            else activityEnabled[i] = false;
        }

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

    public void SetTime(int index){
        string sTime = timeItems[index].transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text;
        nowDay.time[index] = sTime;
    }

    public void SetTransport(int index){
        string sTransport = transportItems[index].transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text;
        //to do change language on dropdown
        nowDay.transportGreek[index] = sTransport;
        nowDay.transportEnglish[index] = sTransport;
    }

    public void SetItemsCoffee(){
        int itemIndex = 0;
        for (int i = 0; i < nowDay.coffee.Length; i++)
        {
            GameObject target = coffeeItems[itemIndex].gameObject;
            if (nowDay.activitiesOn[i]) {
                TextLanguage tl = mainItems[i].GetComponentInChildren<TextLanguage>();
                target.GetComponentInChildren<TextLanguage>().SetTo(tl);
                itemIndex++;
                target.SetActive(true);
            }
        }
        //print("itemIndex: "+itemIndex.ToString());
        for (int i = itemIndex; i < 7; i++)
        {
            coffeeItems[i].gameObject.SetActive(false);
        }
    }
    public void SetItemsTime(){
        int itemIndex = 0;
        for (int i = 0; i < 7; i++)
        {
            GameObject target = timeItems[itemIndex].gameObject;
            if (nowDay.activitiesOn[i]) {
                TextLanguage tl = mainItems[i].GetComponentInChildren<TextLanguage>();
                target.GetComponentInChildren<TextLanguage>().SetTo(tl);
                itemIndex++;
                target.SetActive(true);
            }
        }
        //print("itemIndex: "+itemIndex.ToString());
        for (int i = itemIndex; i < 7; i++)
        {
            timeItems[i].gameObject.SetActive(false);
        }
    }
    public void SetItemsTransport(){
        for (int i = 0; i < timeItems.Length; i++)
        {
            string sTime = timeItems[i].transform.GetChild(1 + i%2).GetComponentInChildren<TextMeshProUGUI>().text;
            nowDay.time[i] = sTime;
        }
        int itemIndex = 0;
        for (int i = 0; i < 7; i++)
        {
            GameObject target = transportItems[itemIndex].gameObject;
            if (nowDay.activitiesOn[i]) {
                TextLanguage tl = mainItems[i].GetComponentInChildren<TextLanguage>();
                target.GetComponentInChildren<TextLanguage>().SetTo(tl);
                itemIndex++;
                target.SetActive(true);
            }
        }
        //print("itemIndex: "+itemIndex.ToString());
        for (int i = itemIndex; i < 7; i++)
        {
            transportItems[i].gameObject.SetActive(false);
        }
    }
    public void SetItemsEnd(){
        for (int i = 0; i < transportItems.Length; i++)
        {
            string sTransport = transportItems[i].transform.GetChild(1 + i%2).GetComponentInChildren<TextMeshProUGUI>().text;
            //to do change language on dropdown
            nowDay.transportGreek[i] = sTransport;
            nowDay.transportEnglish[i] = sTransport;
        }
        int itemIndex = 0;
        for (int i = 0; i < 7; i++)
        {
            GameObject target = endItems[itemIndex].gameObject;
            if (nowDay.activitiesOn[i]) {
                string messageGreek = "";
                string messageEnglish = "";
                TextLanguage tl;
                tl = mainItems[i].GetComponentInChildren<TextLanguage>();
                messageGreek += tl.textGreek;
                messageEnglish += tl.textEnglish;
                string withCoffeeGreek = nowDay.coffee[itemIndex] ? " - με καφέ" : "";
                string withCoffeeEngish = nowDay.coffee[itemIndex] ? " - with coffee" : "";
                messageGreek += withCoffeeGreek;
                messageEnglish += withCoffeeEngish;
                messageGreek += " - " + nowDay.time[itemIndex];
                messageEnglish += " - " + nowDay.time[itemIndex];
                messageGreek += " - " + nowDay.transportGreek[itemIndex];
                messageEnglish += " - " + nowDay.transportEnglish[itemIndex];
                TextLanguage targetTL = target.GetComponentInChildren<TextLanguage>();
                targetTL.textGreek = messageGreek;
                targetTL.textEnglish = messageEnglish;
                targetTL.SetLanguage();
                itemIndex++;
                target.SetActive(true);
            }
        }
        //print("itemIndex: "+itemIndex.ToString());
        for (int i = itemIndex; i < 7; i++)
        {
            endItems[i].gameObject.SetActive(false);
        }
    }

    public void OpenPanel(int index){

        if (index == 1){
            SetItemsCoffee();
        }
        else if (index == 2){
            SetItemsTime();
        }
        else if (index == 3){
            SetItemsTransport();
        }
        else if (index == 4){
            SetItemsEnd();
        }
        /*
        GameObject[] items = new GameObject[7];
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = listParents[index].GetChild(i+1);
        }

        for (int i = 0; i < activityEnabled.Length; i++)
        {
            
        }
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
        */
        for (int i = 0; i < panels.Length; i++)
        {
            if (panels[i] != null) panels[i].SetActive(i == index);
        }
        progressBar.SetToStep(index);
    }

    public void Send(){
        nowDay.isCompleted = true;
        nowDay.check.SetActive(true);
        nowDay.GetComponent<Button>().interactable = false;
        CloseDay();
        map.SetActive(true);
    }

    public void CloseMap(){
        map.SetActive(false);
    }
}
