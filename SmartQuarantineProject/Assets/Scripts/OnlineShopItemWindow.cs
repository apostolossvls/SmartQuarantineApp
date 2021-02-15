using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnlineShopItemWindow : MonoBehaviour
{
    public TextMeshProUGUI titleText, amountText;
    public int amount;
    public string title, price;
    public GameObject background, window;
    public GameObject sampleCartItem;

    public void Open(GameObject item){
        
        TextMeshProUGUI[] texts = item.GetComponentsInChildren<TextMeshProUGUI>();
        title = texts[0].text;
        titleText.text = texts[0].text;
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
        rt.localPosition = new Vector3(rt.localPosition.x, rt.localPosition.y - ((sampleCartItem.transform.parent.childCount-3) * 155), rt.localPosition.z);
        rt = item.transform.parent.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, 200 + (rt.transform.childCount-3) * 155);
        
        item.GetComponent<OnlineShopCartItem>().Setup(title, amount, price);
        background.SetActive(false);
        window.SetActive(false);
    }
}
