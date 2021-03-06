using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using TMPro;

public class OnlineShopCartItem : MonoBehaviour
{
    //public TextMeshProUGUI titleText;
    public TextMeshProUGUI amountText, priceOneText, priceText;
    public TextLanguage titleTL;
    public float priceOne, price;
    public int amount;
    //public static List<OnlineShopCartItem> Items;
    public bool sample = false;

    public void Setup(TextLanguage cTitleTL, int cAmount, string cPrice){
        sample = false;
        //Items.Add(this);
        titleTL.textGreek = cTitleTL.textGreek;
        titleTL.textEnglish = cTitleTL.textEnglish;
        titleTL.SetLanguage();
        //titleText.text = TextLanguageManager.language;

        amount = cAmount;
        amountText.text = "X"+amount.ToString();
        string[] s1 = cPrice.Split(' ');
        priceOne = 0;
        float.TryParse(s1[1].Substring(0, s1[1].Length - 1), NumberStyles.Float , CultureInfo.InvariantCulture , out priceOne);
        priceOneText.text = priceOne.ToString("F2") + "€";
        price = amount * priceOne;
        priceText.text = price.ToString("F2") + "€";
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
                rt.localPosition = new Vector3(rt.localPosition.x, rt.localPosition.y + 135, rt.localPosition.z);
            }
            if (items[i] == this){
                foundThis = true;
            }
        }
        rt = gameObject.transform.parent.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, rt.sizeDelta.y - 135);

        GetComponentInParent<OnlineShop>().RefreshTotalPrice(this);
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
