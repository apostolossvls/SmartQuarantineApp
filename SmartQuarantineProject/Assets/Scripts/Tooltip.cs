using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    static Tooltip instance;
    Text tooltipText;
    public Camera uiCamera;
    RectTransform backgroundRectTransform;

    void Awake(){
        tooltipText = GetComponentInChildren<Text>();
        backgroundRectTransform = transform.GetChild(0).transform.GetComponentInChildren<RectTransform>();
        //ShowTooltip("Hello World!");
        instance = this;
        gameObject.SetActive(false);
    }

    void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, uiCamera, out localPoint);
        transform.localPosition = localPoint;
    }

    void ShowTooltip(string message){
        tooltipText.text = message;
        float padding = 4f;
        Vector2 size = new Vector2(tooltipText.preferredWidth + padding * 2, tooltipText.preferredHeight + padding * 2);
        backgroundRectTransform.sizeDelta = size;

        gameObject.SetActive(true);
    }

    void HideTooltip(){
        gameObject.SetActive(false);
    }

    public static void Show(string message){
        instance.ShowTooltip(message);
    }

    public static void Hide(){
        instance.HideTooltip();
    }
}
