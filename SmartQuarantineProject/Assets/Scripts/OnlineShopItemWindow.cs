using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnlineShopItemWindow : MonoBehaviour
{
    public TextMeshProUGUI amountText;
    public TextLanguage titleTL;
    public int amount;
    public string price;
    public GameObject background, window;
    public GameObject sampleCartItem;

    public void Open(GameObject item){
        
        TextMeshProUGUI[] texts = item.GetComponentsInChildren<TextMeshProUGUI>();
        TextLanguage[] textsTL = item.GetComponentsInChildren<TextLanguage>();
        titleTL.textGreek = textsTL[0].textGreek;
        titleTL.textEnglish = textsTL[0].textEnglish;
        titleTL.SetLanguage();
        //title = texts[0].text;
        //titleText.text = texts[0].text;
        price = texts[1].text;
        amountText.text = "1";
        
        amount = 1;

        background.SetActive(true);
        window.SetActive(true);
    }

    public void Cancel(){
        background.SetActive(false);
        window.SetActive(false);
    }

    public void ChangeAmount(int value){
        amount += value;
        if (amount <= 0) amount = 1;
        amountText.text = amount.ToString();
    }

    public void Confirm(){
        print("add");
        GameObject item = GameObject.Instantiate(sampleCartItem, sampleCartItem.transform.parent);
        if (item == null) print("Null");
        RectTransform rt = item.GetComponent<RectTransform>();
        rt.localPosition = new Vector3(rt.localPosition.x, rt.localPosition.y - ((sampleCartItem.transform.parent.childCount-3) * 135), rt.localPosition.z);
        rt = item.transform.parent.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, 200 + (rt.transform.childCount-3) * 135);
        
        item.GetComponent<OnlineShopCartItem>().Setup(titleTL, amount, price);
        background.SetActive(false);
        window.SetActive(false);
    }
}
