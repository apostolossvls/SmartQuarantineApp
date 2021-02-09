using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagButton : MonoBehaviour
{
    public GameObject greekFlag;
    public GameObject britishFlag;

    public void SetFlag()
    {
        if (TextLanguageManager.language == Language.Greek) {
            greekFlag.SetActive(true);
            britishFlag.SetActive(false);
        }
        else {
            greekFlag.SetActive(false);
            britishFlag.SetActive(true);
        }
    }
}
