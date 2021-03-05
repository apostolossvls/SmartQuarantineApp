using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotkeyEndApplication : MonoBehaviour
{
    public KeyCode key1_1 = KeyCode.RightControl, key1_2 = KeyCode.LeftControl;
    public KeyCode key2_1 = KeyCode.RightShift, key2_2 = KeyCode.LeftShift;
    public KeyCode key3_1 = KeyCode.Escape, key3_2 = KeyCode.Delete;

    void Update()
    {
        //if ((Input.GetKey(key1_1) || Input.GetKeyUp(key1_2)) && (Input.GetKey(key2_1) || Input.GetKeyUp(key2_2)) && (Input.GetKey(key2_1) || Input.GetKeyUp(key3_2)))
        if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.Space)) && Input.GetKeyUp(KeyCode.Escape))
        {
            ApplicationManager.ExitApplication();
        }
    }
}
