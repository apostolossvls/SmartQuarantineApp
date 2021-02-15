using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnlineShop : MonoBehaviour
{
    public GameObject diplay;
    public bool isOn;
    public GameObject[] panels;
    public OnlineShopItemWindow itemPopUp;
    public GameObject cartButton;
    public GameObject signInW;
    public GameObject signUpW;
    public GameObject ckeckoutMessagePre, ckeckoutMessage, ckeckoutMessageError;
    Animator warning;

    void Start(){
        isOn = !isOn;
        SetDisplay();
    }
    
    public void SetDisplay(){
        isOn = !isOn;
        if (isOn) {
            OpenPanel(0);
            OpenSignIn();
        }
        diplay.SetActive(isOn);
    }

    public void SetDisplay(bool newIsOn){
        isOn = !newIsOn;
        SetDisplay();
    }

    public void OpenPanel(int index){
        for (int i = 0; i < panels.Length; i++)
        {
            if (panels[i] != null) panels[i].SetActive(i == index);
        }
        cartButton.SetActive(index != 0 && index != 5);
        itemPopUp.Cancel();
    }

    public void OpenSignIn(){
        signInW.SetActive(true);
        signUpW.SetActive(false);
    }

    public void OpenSignUp(){
        signInW.SetActive(false);
        signUpW.SetActive(true);
    }

    public void SignIn(){
        OpenPanel(1);
    }
    
    public void SignUp(){
        OpenPanel(1);
    }

    void Warning(string message){
        warning.GetComponentInChildren<TextMeshProUGUI>().text = message;
        warning.SetTrigger("PopUp");
    }

    public void CheckOutPre(){
        ckeckoutMessagePre.SetActive(true);
    }

    public void CheckOut(){
        ckeckoutMessagePre.SetActive(false);
        OnlineShopCartItem[] items = GetComponentsInChildren<OnlineShopCartItem>() as OnlineShopCartItem[];
        if (items.Length > 0){
            ckeckoutMessage.GetComponent<Animator>().SetTrigger("Activate");
            foreach (OnlineShopCartItem item in items)
            {
                if (!item.sample){
                    Destroy(item.gameObject);
                }
            }
            OpenPanel(0);
        }
        else {
            ckeckoutMessageError.GetComponent<Animator>().SetTrigger("Activate");
        }
    }

    public void CheckoutCancel(){
        ckeckoutMessagePre.SetActive(false);
    }
    /*
    IEnumerator CheckOutCo(){
        for (int i = 1; i < items.Length; i++)
            {
                
            }
        ckeckoutMessage.SetActive(true);
        
    }
    */
}
