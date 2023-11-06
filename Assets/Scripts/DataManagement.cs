using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEditor.PackageManager.Requests;
using UnityEngine.Networking;
using UnityEngine;
using System.Net;
using System.IO;
using UnityEngine.UI;

public class DataManagement : MonoBehaviour
{
    //Buton Management
    public GameObject takingPanel;
    public GameObject sellingPanel;

    //DOLAR ALIS-SATIS
    public Text dolarTakeText;
    public Text dolarSellText;
    string dolarTakeRate;
    string dolarSellRate;

    //EURO ALIS-SATIS
    public Text euroTakeText;
    public Text euroSellText;
    string euroTakeRate;
    string euroSellRate;

    //ALTIN ALIS-SATIS
    public Text goldTakeText;
    public Text goldSellText;
    string goldTakeRate;
    string goldSellRate;

    //MyBalance
    public Text myDolarBalanceText;
    public Text myEuroBalanceText;
    public Text myGoldBalanceText;

    private void Update()
    {
        dolarTakeText.text = dolarTakeRate + "TL";
        dolarSellText.text = dolarSellRate + "TL";

        euroTakeText.text = euroTakeRate + "TL";
        euroSellText.text = euroSellRate + "TL";

        goldTakeText.text = goldTakeRate + "TL";
        goldSellText.text = goldSellRate + "TL";
    }

    public void GetDataValue()
    {
        WebRequest request = WebRequest.Create("https://finans.truncgil.com/v3/today.json");
        request.Credentials = CredentialCache.DefaultCredentials;
        WebResponse response = request.GetResponse();
        Stream dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        string responseFromServer = reader.ReadToEnd();

        //DOLAR ALIS
        string sRateBegin = "\"Buying\":";
        string sRateEnd = "\",\"";
        string sRate = responseFromServer.Substring(responseFromServer.IndexOf(sRateBegin) + sRateBegin.Length + 1);
        sRate = sRate.Substring(0, sRate.IndexOf(sRateEnd));
        dolarTakeRate = sRate;

        //DOLAR SATIS
        string sDsRateBegin = "\"Selling\":";
        string sDsRateEnd = "\",\"";
        string sDsRate = responseFromServer.Substring(responseFromServer.IndexOf(sDsRateBegin) + sDsRateBegin.Length + 1);
        sDsRate = sDsRate.Substring(0, sDsRate.IndexOf(sDsRateEnd));
        dolarSellRate = sDsRate;

        //EURO ALIS
        string sEaRateBegin = "\"Buying\":";
        string sEaRateEnd = "\",\"";
        string sEaRate = responseFromServer.Substring(responseFromServer.IndexOf(sEaRateBegin) + sEaRateBegin.Length + 1);
        sEaRate = sEaRate.Substring(82, sEaRate.IndexOf(sEaRateEnd)); 
        euroTakeRate = sEaRate;

        //EURO SATIS
        string sEsRateBegin = "\"Selling\":";
        string sEsRateEnd = "\",\"";
        string sEsRate = responseFromServer.Substring(responseFromServer.IndexOf(sEsRateBegin) + sEsRateBegin.Length + 1);
        sEsRate = sEsRate.Substring(82, sEsRate.IndexOf(sEsRateEnd)); 
        euroSellRate = sEsRate;

        //GOLD ALIS
        string sGtRateBegin = "\"gram-altin\":";
        string sGtRateEnd = "\",\"";
        string sGtRate = responseFromServer.Substring(responseFromServer.IndexOf(sGtRateBegin) + sGtRateBegin.Length + 11);
        sGtRate = sGtRate.Substring(0, sGtRate.IndexOf(sGtRateEnd));
        goldTakeRate = sGtRate;

        //GOLD SATIS
        string sGsRateBegin = "gram-altin";
        string sGsRateEnd = "\",\"";
        string sGsRate = responseFromServer.Substring(responseFromServer.IndexOf(sGsRateBegin) + sGsRateBegin.Length + 13); 
        sGsRate = sGsRate.Substring(35, sGsRate.IndexOf(sGsRateEnd));
        goldSellRate = sGsRate;


        reader.Close();
        response.Close();

    }

    public void Taking()
    {
        takingPanel.SetActive(true);
        //Guncel alis fiyatina 
    }

    public void Selling()
    {
        sellingPanel.SetActive(true);
    }

    public void OkButton()
    {
        takingPanel.SetActive(false);
        sellingPanel.SetActive(false);
    }

    //[Serializable]
    //public class CurrencyData
    //{
    //    public string Update_Date;
    //    public Currency USD;
    //    public Currency EUR;
    //}

    //[Serializable]
    //public class Currency
    //{
    //    public string Buying;
    //    public string Type;
    //    public string Selling;
    //    public string Change;
    //}

    //public class JSONExample : MonoBehaviour
    //{
    //    private string jsonText = "{\"Update_Date\":\"2023-11-05 23:00:02\",\"USD\":{\"Buying\":\"28,3770\",\"Type\":\"Currency\",\"Selling\":\"28,3832\",\"Change\":\"%0,20\"},\"EUR\":{\"Buying\":\"30,4286\",\"Type\":\"Currency\",\"Selling\":\"30,5348\",\"Change\":\"%1,05\"}}";

    //    void Start()
    //    {
    //        CurrencyData currencyData = JsonUtility.FromJson<CurrencyData>(jsonText);

    //        Debug.Log("Update Date: " + currencyData.Update_Date);
    //        Debug.Log("USD Buying: " + currencyData.USD.Buying);
    //        Debug.Log("EUR Selling: " + currencyData.EUR.Selling);
    //    }
    //}

    //private string url = "https://finans.truncgil.com/v3/today.json";

    //void Start()
    //{
    //    StartCoroutine(DownloadData());
    //}

    //IEnumerator DownloadData()
    //{
    //    UnityWebRequest www = UnityWebRequest.Get(url);
    //    yield return www.SendWebRequest();

    //    if (www.isNetworkError || www.isHttpError)
    //    {
    //        Debug.Log("Error: " + www.error);
    //    }
    //    else
    //    {
    //        string responseFromServer = www.downloadHandler.text;
    //        string sRateBegin = "\"Buying\":";
    //        string sRateEnd = "\",\"";
    //        int startIndex = responseFromServer.IndexOf(sRateBegin);

    //        if (startIndex >= 0)
    //        {
    //            startIndex += sRateBegin.Length;
    //            int endIndex = responseFromServer.IndexOf(sRateEnd, startIndex);

    //            if (endIndex >= 0)
    //            {
    //                string sRate = responseFromServer.Substring(startIndex, endIndex - startIndex);
    //                Debug.Log("sRate: " + sRate);
    //            }
    //            else
    //            {
    //                Debug.Log("sRateEnd not found");
    //            }
    //        }
    //        else
    //        {
    //            Debug.Log("sRateBegin not found");
    //        }
    //    }
    //}
}

