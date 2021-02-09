using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

//availiable languages
public enum Language {Greek = 0, English = 1};

public class TextLanguageManager : MonoBehaviour
{
    //using language
    public static TextLanguageManager instance;
    public static Language language;
    public FlagButton[] flagButtons;
    public bool inspectorGreek;
    public bool inspectorEnglish;
    bool inspectorGreekLast;
    bool inspectorEnglishLast;

    void Awake(){
        if (instance != null){
            Destroy(this);
            return;
        }
        instance = this;
    }

    void Start()
    {
        //AddTextLanguageToTMPUGUI();

        //set to greek
        inspectorGreek = true;
        inspectorGreekLast = true;
        SetLanguage(Language.Greek);
    }


    //add text language component to every gameobject with TextMeshProUGUI component
    /*
    void AddTextLanguageToTMPUGUI(){
        TextMeshProUGUI[] textLabels = FindObjectsOfType<TextMeshProUGUI>();
        foreach (TextMeshProUGUI textLabel in textLabels)
        {
            TextLanguage tl = textLabel.gameObject.AddComponent(typeof(TextLanguage)) as TextLanguage;
        }
    }
    */

    //set all texts to language if language was found
    void SetLanguage(Language newLanguage){
        language = newLanguage;

        for (int i = 0; i < flagButtons.Length; i++)
        {
            flagButtons[i].SetFlag();
        }
        /*
        TextLanguage[] texts = FindObjectsOfTypeAll<TextLanguage>();
        foreach (TextLanguage textLanguage in texts)
        {
            textLanguage.SetLanguage(newLanguage);
        }
        */

        /*
        foreach (TextLanguage tl in Resources.FindObjectsOfTypeAll(typeof(TextLanguage)) as TextLanguage[])
        {
            if (!EditorUtility.IsPersistent(tl.transform.root.gameObject) && !(tl.hideFlags == HideFlags.NotEditable || tl.hideFlags == HideFlags.HideAndDontSave)){
                tl.SetLanguage(newLanguage);
            }
        }
        
        foreach(TextLanguage tl in UnityEngine.Object.FindObjectsOfTypeAll<TextLanguage>() as TextLanguage[]){
            tl.SetLanguage(newLanguage);
        }
        */
        foreach (TextLanguage tl in GameObject.FindObjectsOfType(typeof(TextLanguage)) as TextLanguage[])
        {
            tl.SetLanguage(newLanguage);
        }
    }

    public void ToggleLanguage(){
        if (language == Language.Greek){
            SetLanguage(Language.English);
        }
        else {
            SetLanguage(Language.Greek);
        }
    }

    void Updates(){
        if (!inspectorGreek && !inspectorEnglish){
            inspectorGreek = true;
            inspectorGreekLast = true;
            inspectorEnglish = false;
            inspectorEnglishLast = false;
            if (language == Language.Greek) return;
            SetLanguage(Language.Greek);
        }
        else if (inspectorGreek && !inspectorGreekLast){
            inspectorGreekLast = true;
            inspectorEnglish = false;
            inspectorEnglishLast = false;
            SetLanguage(Language.Greek);
        }
        else if (inspectorEnglish && !inspectorEnglishLast){
            inspectorEnglishLast = true;
            inspectorGreek = false;
            inspectorGreekLast = false;
            SetLanguage(Language.English);
        }
    }
}
