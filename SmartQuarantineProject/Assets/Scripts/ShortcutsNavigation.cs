using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortcutsNavigation : MonoBehaviour
{
    public PanelManager panelManager;
    public Calender calender;
    bool activated = true;

    void Start(){
        activated = true;
    }

    void Update()
    {
        if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && (Input.GetKey(KeyCode.M) || Input.GetKey(KeyCode.Alpha1)))
        {
            //main
            ClosePanel(0);
            panelManager.GoTo(0);
        }
        else if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.Alpha2)))
        {
            //calender
            ClosePanel(3);
            panelManager.GoTo(3);
        }
        if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Alpha3)))
        {
            //devices
            ClosePanel(2);
            panelManager.GoTo(2);
        }
        if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.Alpha4)))
        {
            //shop
            ClosePanel(4);
            panelManager.GoTo(4);
        }
        if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && (Input.GetKey(KeyCode.T) || Input.GetKey(KeyCode.Alpha5)))
        {
            //thermometer
            if (panelManager.panelIndex != 0) {
                StopCoroutine("GoToDoorDelay");
                StartCoroutine("GoToDoorDelay");
            }
            else ClosePanel(1);
            panelManager.GoTo(1);
        }
    }

    void ClosePanel(int newIndex){
        int index = panelManager.panelIndex;
        if (index==3){
            calender.CloseDay();
        }
        if (index==1){
            calender.CloseDay();
        }
    }

    IEnumerator GoToDoorDelay(){
        Animator doorAnimator = panelManager.doorAnimator;
        yield return new WaitForSeconds(2f);
        if (doorAnimator) {
            doorAnimator.SetBool("Open", true);
            panelManager.StopCoroutine("CloseDoorDelay");
            panelManager.StartCoroutine("CloseDoorDelay");
        }
        yield return null;
    }
}
