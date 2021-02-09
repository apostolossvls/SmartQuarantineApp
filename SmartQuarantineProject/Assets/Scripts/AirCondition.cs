using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AirCondition : MonoBehaviour
{
    Animator animator;
    public bool isOn;
    public bool inspectorOn;
    bool inspectorOnOnLast;

    void Start(){
        animator = GetComponent<Animator>();
        inspectorOnOnLast = inspectorOn;
        SetAirCondition(inspectorOn);
    }


    void Update()
    {
        if (inspectorOn != inspectorOnOnLast){
            inspectorOnOnLast = inspectorOn;
            SetAirCondition(inspectorOn);
        }
    }

    //toggle air conditioner
    public void SetAirCondition(){
        isOn = !isOn;
        animator.SetBool("isOn", isOn);
    }
    //set isOn to opposite of newIsOn so on SetAirCondition isOn = newIsOn
    public void SetAirCondition(bool newIsOn){
        isOn = !newIsOn;
        SetAirCondition();
    }
}
