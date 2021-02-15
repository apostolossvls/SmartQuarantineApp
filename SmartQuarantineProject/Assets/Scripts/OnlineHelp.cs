using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineHelp : MonoBehaviour
{
    public GameObject window;
    public OnlineHelpPanel[] panels;
    public Transform labelPivotBack, labelPiveotFront;
    public Transform[] labels;
    public static int targerID;

    void Start(){
        StartLabelArrange();
    }

    public void Open(int id){
        Open();
        for (int i = 0; i < panels.Length; i++)
        {
            bool found = panels[i].Open(id);
            panels[i].gameObject.SetActive(found);
            if (found){
                LabelArrange(panels[i].label);
            }
        }
    }

    public void Open(){
        window.SetActive(true);
    }

    public void Close(){
        window.SetActive(false);
    }

    public void LabelArrange(Transform thisLabel){
        int front = labelPiveotFront.GetSiblingIndex() + 1;
        int back = labelPivotBack.GetSiblingIndex() + 1;
        for (int i = 0; i < labels.Length; i++)
        {
            labels[i].SetSiblingIndex((labels[i] == thisLabel) ? front : back);
            /*
            if (labels[i] == thisLabel){
                labels[i].SetSiblingIndex(front);
            }
            else{
                labels[i].SetSiblingIndex(back);
            }
            */
        }
    }

    void StartLabelArrange(){
        int front = labelPiveotFront.GetSiblingIndex() + 1;
        int back = labelPivotBack.GetSiblingIndex() + 1;
        for (int i = 0; i < labels.Length; i++)
        {
            labels[i].SetSiblingIndex((i == 0) ? front : back);
        }
    }
}
