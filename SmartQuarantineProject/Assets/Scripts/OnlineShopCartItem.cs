using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnlineShopCartItem : MonoBehaviour
{
    public TextMeshProUGUI titleText, amountText, priceOneText, priceText;
    public string title;
    public float priceOne, price;
    public int amount;
    //public static List<OnlineShopCartItem> Items;
    public bool sample = false;

    public void Setup(string cTitle, int cAmount, string cPrice){
        sample = false;
        //Items.Add(this);
        title = cTitle;
        titleText.text = title;
        amount = cAmount;
        amountText.text = "X"+amount.ToString();
        string[] s1 = cPrice.Split(' ');
        priceOne = float.Parse(s1[1].Substring(0, s1[1].Length - 1));
        priceOneText.text = priceOne.ToString() + "€";
        price = amount * priceOne;
        priceText.text = price.ToString() + "€";
        gameObject.SetActive(true);
    }

    public void Delete(){
        bool foundThis = false;
        RectTransform rt;
        OnlineShopCartItem[] items = transform.parent.GetComponentsInChildren<OnlineShopCartItem>() as OnlineShopCartItem[];
        for (int i = 0; i < items.Length; i++)
        {
            if (foundThis){
                rt = items[i].GetComponent<RectTransform>();
                rt.localPosition = new Vector3(rt.localPosition.x, rt.localPosition.y + 155, rt.localPosition.z);
            }
            if (items[i] == this){
                foundThis = true;
            }
        }
        rt = gameObject.transform.parent.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, rt.sizeDelta.y - 155);
        /*
        foreach (OnlineShopCartItem item in GameObject.FindObjectsOfType(typeof(OnlineShopCartItem)) as OnlineShopCartItem[])
        {
            if (!item.sample && counter >= index){
                RectTransform rt = item.GetComponent<RectTransform>();
                rt.localPosition = new Vector3(rt.localPosition.x, rt.localPosition.y + 155, rt.localPosition.z);

                counter++;
            }
        }
        print(counter);
        */
        Destroy(gameObject);
    }
}
