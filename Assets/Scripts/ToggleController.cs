using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    //TakingCurrency
    public Toggle takingDolar;
    public Toggle takingEuro;
    public Toggle takingGold;

    //SellingCurrency
    public Toggle sellingDolar;
    public Toggle sellingEuro;
    public Toggle sellingGold;
    
    //Input
    public InputField takingValue;
    public InputField sellingValue;
    
    //BalanceTexts
    public Text dolarMyBalance;
    public Text euroMyBalance;
    public Text goldMyBalance;
    
    //Panels
    public GameObject takingPanel;
    public GameObject sellingPanel;


    public void ForSaveButtons()
    {
        takingPanel.SetActive(false);
        sellingPanel.SetActive(false);

        takingDolar.isOn = false;
        takingEuro.isOn = false;
        takingGold.isOn = false;

        sellingDolar.isOn = false;
        sellingEuro.isOn = false;
        sellingGold.isOn = false;

        takingValue.text = " ";
    }

    public void DolarTakingCheck()
    {
        if (takingDolar.isOn == true)
        {
            DolarValuePlus();
        }
    }

    public void EuroTakingCheck()
    {
        if (takingEuro.isOn == true)
        {
            EuroValuePlus();
        }
    }

    public void GoldTakingCheck()
    {
        if (takingGold.isOn == true)
        {
            GoldValuePlus();
        }
    }

    public void DolarValuePlus()
    {
        decimal inputValue = decimal.Parse(takingValue.text);
        decimal currentBalance = decimal.Parse(dolarMyBalance.text);
        decimal newBalance = currentBalance + inputValue;
        dolarMyBalance.text = newBalance.ToString(); // $
    }

    public void EuroValuePlus()
    {
        decimal inputValue = decimal.Parse(takingValue.text);
        decimal currentBalance = decimal.Parse(euroMyBalance.text);
        decimal newBalance = currentBalance + inputValue;
        euroMyBalance.text = newBalance.ToString(); // €
    }

    public void GoldValuePlus()
    {
        int inputValue = int.Parse(takingValue.text);
        int currentBalance = int.Parse(goldMyBalance.text);
        int newBalance = currentBalance + inputValue;
        goldMyBalance.text = newBalance.ToString();
    }

    public void DolarSellingCheck()
    {
        if (sellingDolar.isOn == true)
        {
            DolarValueMinus();
        }
    }

    public void EuroSellingCheck()
    {
        if (sellingEuro.isOn == true)
        {
            EuroValueMinus();
        }
    }

    public void GoldSellingCheck()
    {
        if (sellingGold.isOn == true)
        {
            GoldValueMinus();
        }
    }

    public void DolarValueMinus()
    {
        decimal inputValue = decimal.Parse(sellingValue.text);
        decimal currentBalance = decimal.Parse(dolarMyBalance.text);
        decimal newBalance = currentBalance - inputValue;
        dolarMyBalance.text = newBalance.ToString();
    }

    public void EuroValueMinus()
    {
        decimal inputValue = decimal.Parse(sellingValue.text);
        decimal currentBalance = decimal.Parse(euroMyBalance.text);
        decimal newBalance = currentBalance - inputValue;
        euroMyBalance.text = newBalance.ToString();
    }

    public void GoldValueMinus()
    {
        int inputValue = int.Parse(sellingValue.text);
        int currentBalance = int.Parse(goldMyBalance.text);
        int newBalance = currentBalance - inputValue;
        goldMyBalance.text = newBalance.ToString();
    }

}