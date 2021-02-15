using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject[] panels;
    public Animator cameraAnimator;
    public Animator panelAnimator;
    public Animator doorAnimator;
    public Thermometer thermometer;
    public int panelIndex;

    void Start(){
        panelIndex = 0;
    }

    public void GoTo(int index){
        //DisplayPanel(panelIndex, false);

        if (cameraAnimator) cameraAnimator.SetInteger("PanelIndex", index);
        
        if (panelAnimator) panelAnimator.SetInteger("PanelIndex", index);

        if ((panelIndex == 0 && index == 1) || (panelIndex == 1 && index == 0)){
            if ((panelIndex == 0 && index == 1) && thermometer != null) thermometer.OpenPanel(0);
            if (doorAnimator) {
                doorAnimator.SetBool("Open", true);
                StopCoroutine("CloseDoorDelay");
                StartCoroutine("CloseDoorDelay");
            }
        }

        if (index == 2){
            OnlineHelp.targerID = 30;
        } 

        panelIndex = index;
    }
    /*

    //activate/deactivate panel with given index
    public void DisplayPanel(int index, bool activate){
        if (panels[index]) panels[index].SetActive(activate);
    }

    //called when a panel transition animation has ended
    public void DisplayNowPanelTrue(){
        DisplayPanel(panelIndex, true);
    }
    */

    IEnumerator CloseDoorDelay(){
        yield return new WaitForSeconds(1.5f);
        if (doorAnimator) doorAnimator.SetBool("Open", false);
        yield return null;
    }
}
