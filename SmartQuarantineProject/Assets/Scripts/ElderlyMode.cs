using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElderlyMode : MonoBehaviour
{
    public GameObject active;
    public GameObject deactive;
    public bool isOn;
    float timer;
    public float targetTime = 10f;
    public Animator animator;

    void Start()
    {
        timer = 0;
        active.SetActive(isOn);
        deactive.SetActive(!isOn);
        /*
        foreach (GameObject item in active)
        {
            item.SetActive(isOn);
        }
        foreach (GameObject item in deactive)
        {
            item.SetActive(!isOn);
        }
        */
    }

    public void Toggle(){
        isOn = !isOn;
        timer = 0;
        active.SetActive(isOn);
        deactive.SetActive(!isOn);
        /*
        foreach (GameObject item in active)
        {
            item.SetActive(isOn);
        }
        foreach (GameObject item in deactive)
        {
            item.SetActive(!isOn);
        }
        */
    }

    void Update(){
        if (isOn){
            timer += Time.deltaTime;
            if (timer >= targetTime){
                Action1();
                //timer = 0;
                //isOn = false;
                //active[0].SetActive(false);
                //deactive[0].SetActive(true);
                Toggle();
            }
        }
    }

    void Action1(){
        animator.SetBool("Action1", true);
        StopCoroutine("DangerDelay");
        StartCoroutine("DangerDelay");
    }

    public void Action1Deactivate(){
        animator.SetBool("Action1", false);
        StopCoroutine("DangerDelay");
    }

    public void Action2(){
        animator.SetTrigger("Action2");
        StopCoroutine("DangerDelay");
        StopCoroutine("Action2Delay");
        StartCoroutine("Action2Delay");
    }
    IEnumerator Action2Delay(){
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Action1", false);
        yield return null;
    }

    IEnumerator DangerDelay(){
        yield return new WaitForSeconds(15f);
        Action2();
        yield return null;
    }
}
