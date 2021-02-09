using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggle1 : MonoBehaviour
{
    Animator animator;
    public bool isOn;
    public GameObject[] activateWhenOn;
    public GameObject[] activateWhenOff;

    void Start()
    {
        animator = GetComponent<Animator>();
        //reverse isOn to get reversed again from OnClick
        animator.SetBool("isOn", isOn);
        isOn = !isOn;
        OnClick();
    }

    //on click start
    public void OnClickDown(){
        //isOn = !isOn;
        //StopAllCoroutines();
        //StartCoroutine("OnClickEnumerator");
        animator.SetBool("isOn", !isOn);

        /*
        foreach (GameObject item in activateWhenOn)
        {
            item.SetActive(true);
        }
        foreach (GameObject item in activateWhenOff)
        {
            item.SetActive(true);
        }
        */
    }

    //on click (end)
    public void OnClick(){
        isOn = !isOn;
        /*
        foreach (GameObject item in activateWhenOn)
        {
            item.SetActive(isOn);
        }
        foreach (GameObject item in activateWhenOff)
        {
            item.SetActive(!isOn);
        }
        */
    }

    //when user clicks away from button and he wants to cancel
    public void EndDragCancelClick(){
        /*
        foreach (GameObject item in activateWhenOn)
        {
            item.SetActive(isOn);
        }
        foreach (GameObject item in activateWhenOff)
        {
            item.SetActive(!isOn);
        }
        */
    }
}
