using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintToolTip : MonoBehaviour
{
    [TextArea(1,3)] public string textGreek;
    [TextArea(1,3)] public string textEnglish;
    public float delay = 3;
    float timer;
    bool sended;

    void Start(){
        sended = false;
        this.enabled = false;
    }

    void Update(){
        if (timer >= delay && !sended){
            timer = 0;
            Show();
            sended = true;
        }
        else{
            timer += Time.deltaTime;
        }
    }

    public void StartHint(){
        this.enabled = true;
        timer = 0;
        sended = false;
    }

    public void StopHint(){
        this.enabled = false;
        timer = 0;
        Tooltip.Hide();
        sended = false;
    }

    void Show(){
        string message = "";
        switch (TextLanguageManager.language)
        {
            case Language.Greek:
                message = textGreek;
                break;
            case Language.English:
                message = textEnglish;
                break;
            default:
                message = textGreek;
                break;
        }
        if (message != "") Tooltip.Show(message);
    }
}
