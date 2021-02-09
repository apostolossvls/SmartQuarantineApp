using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextLanguage : MonoBehaviour
{
    [TextArea(1,3)] public string textGreek;
    [TextArea(1,3)] public string textEnglish;

    void OnEnable(){
        SetLanguage();
    }

    public void SetLanguage(Language newLanguage){
        string text = "";
        switch (newLanguage)
        {
            case Language.Greek:
                text = textGreek;
                break;
            case Language.English:
                text = textEnglish;
                break;
            default:
                text = textGreek;
                break;
        }
        GetComponent<TextMeshProUGUI>().text = text;
    }

    public void SetLanguage(){
        SetLanguage(TextLanguageManager.language);
    }
}
