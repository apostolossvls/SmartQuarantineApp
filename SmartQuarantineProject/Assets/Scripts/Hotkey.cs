using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hotkey : MonoBehaviour
{
    public KeyCode key2_1 = KeyCode.RightControl, key2_2 = KeyCode.LeftControl, key1 = KeyCode.F;
    public bool singleKey = false;
    public Selectable[] selectables = new Selectable[1];
    public KeyCode keyHelp = KeyCode.F1;
    public Button onlineHelpButton;
    public static bool isHelpOnlineOpen = false;

    void Update()
    {
        if (key1 == KeyCode.None) Destroy(this);
        if (Input.GetKey(key2_1) && Input.GetKeyUp(key1))
        {
            SelectSelectable();
        }
        if (Input.GetKey(key2_2) && Input.GetKeyUp(key1))
        {
            SelectSelectable();
        }

        if (Input.GetKeyUp(keyHelp))
        {
            OpenOnlineHelp();
        }
    }

    void SelectSelectable(){
        if (isHelpOnlineOpen) return;
        for (int i = 0; i < selectables.Length; i++)
        {
            if (selectables[i].gameObject.activeInHierarchy){
                selectables[i].Select();
                return;
            }
        }
    }

    void OpenOnlineHelp(){
        if (onlineHelpButton == null) return;
        isHelpOnlineOpen = true;
        onlineHelpButton.onClick.Invoke();
    }
}
