using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    public Toggle choiceDolar;
    public Toggle choiceEuro;
    public Toggle choiceGold;

    public InputField currencyValue;

    public Text dolarMyBalance;
    public Text euroMyBalance;
    public Text goldMyBalance;

    public GameObject takingPanel;
    public GameObject sellingPanel;

    public void ForSaveButtons()
    {
        takingPanel.SetActive(false);
        sellingPanel.SetActive(false);

        choiceDolar.isOn = false;
        choiceEuro.isOn = false;
        choiceGold.isOn = false;

        currencyValue.text = " ";
    }

    public void DolarCheck()
    {
        if(choiceDolar.isOn == true)
        {
            DolarValue();
            
        }
        else
        {
            Debug.Log("OFFFFd");
        }
    }

    public void EuroCheck()
    {
        if (choiceEuro.isOn == true)
        {
            EuroValue();
        }
        else
        {
            Debug.Log("OFFFFe");
        }
    }

    public void GoldCheck()
    {
        if (choiceGold.isOn == true)
        {
            GoldValue();
        }
        else
        {
            Debug.Log("OFFFFg");
        }
    }

    public void DolarValue()
    {
        //dolarMyBalance.text = (dolarMyBalance.text + currencyValue.text) + "$";
        decimal inputValue = decimal.Parse(currencyValue.text);
        decimal currentBalance = decimal.Parse(dolarMyBalance.text);
        decimal newBalance = currentBalance + inputValue;
        dolarMyBalance.text = newBalance.ToString();
    }

    public void EuroValue()
    {
        decimal inputValue = decimal.Parse(currencyValue.text);
        decimal currentBalance = decimal.Parse(euroMyBalance.text);
        decimal newBalance = currentBalance + inputValue;
        euroMyBalance.text = newBalance.ToString(); // + "€"
    }

    public void GoldValue()
    {
        int inputValue = int.Parse(currencyValue.text);
        int currentBalance = int.Parse(goldMyBalance.text);
        int newBalance = currentBalance + inputValue;
        goldMyBalance.text = newBalance.ToString();
    }
}
