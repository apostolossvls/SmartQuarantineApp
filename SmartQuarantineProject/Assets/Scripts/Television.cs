using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Television : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject diplay;
    public bool isOn;
    public bool tvIsOn;
    bool tvIsOnLast;

    void Start(){
        tvIsOnLast = tvIsOn;
        SetTV(tvIsOn);
    }


    void Update()
    {
        if (tvIsOn != tvIsOnLast){
            tvIsOnLast = tvIsOn;
            SetTV(tvIsOn);
        }
    }

    //toggle TV
    public void SetTV(){
        isOn = !isOn;
        videoPlayer.gameObject.SetActive(isOn);
        diplay.SetActive(isOn);
    }
    
    //set isOn to opposite of newIsOn so on SetTV isOn = newIsOn
    public void SetTV(bool newIsOn){
        isOn = !newIsOn;
        SetTV();
    }
}
