using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    public static void ExitApplication(){
        print("Exit Application!");
        Application.Quit();
    }
}
