using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Thermometer : MonoBehaviour
{
    public enum ThermoUserType {Resident = 0, Guest = 1, Distributor = 2, Other = 3};

    public GameObject diplay;
    public GameObject[] panels;
    public GameObject[] conditionPanels;
    public GameObject[] residentOptions;
    public GameObject[] questOptions;
    public GameObject[] distributorOptions;
    public GameObject[] notifyOptions;
    public Animator cameraAnimator, thermoAnimator, deliveryBoxAnimator;
    public Image temperatureLine;
    public TextMeshProUGUI temperatureText;
    public GameObject restartFromStartButton;
    public GameObject raycastBlockScreen;
    public AudioSource bell;
    public ThermoUserType userType;
    float temperature;
    public float temperatureSpeed = 1f;
    bool notifyOnce;
    public bool isOn;

    void Start(){
        temperature = 36.7f;
        isOn = !isOn;
        SetDisplay();
    }

    //toggle Thermometer on/off
    public void SetDisplay(){
        isOn = !isOn;

        if (isOn) {
            OpenPanel(0);
        }

        diplay.SetActive(isOn);
    }
    
    //set Thermometer on//off
    public void SetDisplay(bool newIsOn){
        isOn = !newIsOn;
        SetDisplay();
    }

    //show panel with index and disable the rest
    public void OpenPanel(int index){
        for (int i = 0; i < panels.Length; i++)
        {
            if (panels[i] != null) panels[i].SetActive(i == index);
        }
        if (index == 0 || index == 1){
            notifyOnce = false;
        }
        restartFromStartButton.SetActive(index != 0 && index != 1);
        if (index == 2){
            CalculateTemperature();
        }
    }

    public void SetUserType(int index){
        userType = (ThermoUserType) index;
        OpenPanel(2);
    }

    void CalculateTemperature(){
        raycastBlockScreen.SetActive(true);
        cameraAnimator.SetTrigger("Thermo");
        thermoAnimator.SetTrigger("Thermo");
    }
    public void CalculateTemperatureEnd(){
        foreach (GameObject item in conditionPanels)
        {
            item.SetActive(false);
        }
        OpenPanel(3);

        raycastBlockScreen.SetActive(false);

        StopCoroutine("AnimateTemperature");
        StartCoroutine("AnimateTemperature");
    }

    void OpenTypeOptions(float targetTemperature){
        for (int i = 0; i < residentOptions.Length; i++)
        {
            residentOptions[i].SetActive(false);
        }
        for (int i = 0; i < questOptions.Length; i++)
        {
            questOptions[i].SetActive(false);
        }
        for (int i = 0; i < distributorOptions.Length; i++)
        {
            distributorOptions[i].SetActive(false);
        }
        for (int i = 0; i < notifyOptions.Length; i++)
        {
            notifyOptions[i].SetActive(false);
        }

        if (notifyOnce != true && (targetTemperature < 36 || targetTemperature > 37.2)){
            for (int i = 0; i < notifyOptions.Length; i++)
            {
                notifyOptions[i].SetActive(true);
            }
            notifyOnce = true;
            return;
        }

        notifyOnce = true;

        switch (userType)
        {
            case ThermoUserType.Resident:
                for (int i = 0; i < residentOptions.Length; i++)
                {
                    residentOptions[i].SetActive(true);
                }
                break;
             case ThermoUserType.Distributor:
                for (int i = 0; i < distributorOptions.Length; i++)
                {
                    distributorOptions[i].SetActive(true);
                }
                break;
            case ThermoUserType.Other:
            case ThermoUserType.Guest:
            default:
                for (int i = 0; i < questOptions.Length; i++)
                {
                    questOptions[i].SetActive(true);
                }
                break;
        }
    }

    //get a random temperature and show it gradualy
    IEnumerator AnimateTemperature(){
        temperature = 35f;
        temperatureLine.fillAmount = 0;
        temperatureText.text = "35.0";

        float target = 36.6f;
        float random01  = Random.Range(0f, 1f);
        if (random01 < 0.5f){
            target = Random.Range(36f, 37.21f);
        }
        else if (random01 < 0.7f){
            target = Random.Range(35f, 36f);
        }
        else if (random01 < 0.9f){
            target = Random.Range(37.2f, 38.5f);
        }
        else target = Random.Range(38.5f, 41.5f);
        target = Mathf.Round(target * 10f) / 10f;

        OpenTypeOptions(target);

        while (temperature < target){
            temperature += Time.deltaTime * temperatureSpeed;

            temperatureText.text = (Mathf.Round(temperature * 10f) / 10f).ToString();
            temperatureLine.fillAmount = Mathf.Clamp01((temperature - 35f) / (42f - 35f));

            yield return new WaitForEndOfFrame();
        }

        temperature = target;
        temperatureText.text = (Mathf.Round(temperature * 10f) / 10f).ToString();
        temperatureLine.fillAmount = Mathf.Clamp01((temperature - 35f) / (42f - 35f));

        if (temperature < 36){
            conditionPanels[0].SetActive(true);
        }
        else if (temperature <= 37.2){
            conditionPanels[1].SetActive(true);
        }
        else if (temperature < 38){
            conditionPanels[2].SetActive(true);
        }
        else {
            conditionPanels[3].SetActive(true);
        }

        yield return null;
    }

    public void RingBell(){
        OpenPanel(4);
        bell.Play();
        StopCoroutine("RingBellAction");
        StartCoroutine("RingBellAction");
    }
    IEnumerator RingBellAction(){
        yield return new WaitForSeconds(3f);
        OpenPanel(0);
        FindObjectOfType<PanelManager>().GoTo(0);
    }

    public void DeliveryUse(){
        StopCoroutine("DeliveryUseAction");
        StartCoroutine("DeliveryUseAction");
    }
    IEnumerator DeliveryUseAction(){
        OpenPanel(5);
        cameraAnimator.SetTrigger("DeliveryUse1");
        raycastBlockScreen.SetActive(true);
        yield return new WaitForSeconds(4f);

        deliveryBoxAnimator.SetTrigger("DeliveryUse1");
        yield return new WaitForSeconds(2f);

        OpenPanel(0);
        yield return new WaitForSeconds(2f);
        raycastBlockScreen.SetActive(false);
    }
}
