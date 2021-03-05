using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle2 : MonoBehaviour
{

    public Animator animator;
    public bool isOn;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        isOn = !isOn;
        OnClickUp();
    }

    void OnEnable(){
        if (animator != null) animator.SetBool("isOn", isOn);
    }

    public void OnClickUp(){
        isOn = !isOn;
        animator.SetBool("isOn", isOn);
    }

    public void Set(bool value){
        isOn = value;
        animator.SetBool("isOn", isOn);
    }

}
