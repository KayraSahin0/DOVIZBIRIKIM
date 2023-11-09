using System;
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

    //Date Time
    public Text dateTimeText;

    //Convert Currency
    public Text dolarValueText;
    public Text tlValueText;
    public Text genusText;

    //Data Save From Json
    public CurrencyData _CurrencyData;

    //Content Prefabs
    public GameObject dolarSavePrefabs;
    public GameObject euroSavePrefabs;
    public GameObject goldSavePrefabs;
    public Transform saveDolarPrefabsTransform;

    private void Update()
    {
        dolarTakeText.text = dolarTakeRate + "TL";
        dolarSellText.text = dolarSellRate + "TL";

        euroTakeText.text = euroTakeRate + "TL";
        euroSellText.text = euroSellRate + "TL";

        goldTakeText.text = goldTakeRate + "TL";
        goldSellText.text = goldSellRate + "TL";
    }

    //Save&Trade
    [ContextMenu("Save")]
    public void SaveButtonTrade()
    {
        //DataTime
        string time = System.DateTime.UtcNow.ToLocalTime().ToString("HH:mm dd.MM.yy");
        dateTimeText.text = time;

        //TradeCalculation
        genusText.text = "DOLAR";
        dolarValueText.text = myDolarBalanceText.text;
        decimal convertCurrencyValue = decimal.Parse(dolarTakeRate);
        decimal dolarCurrencyValue = decimal.Parse(dolarValueText.text);
        decimal newOutput = convertCurrencyValue * dolarCurrencyValue;
        tlValueText.text = newOutput.ToString();

        SpawnPrefabs();

        //DolarSave
        string jsonSave = JsonUtility.ToJson(_CurrencyData, true);
        File.WriteAllText(Application.persistentDataPath + "/CurrencyData.json", jsonSave);

        //LOAD
        //string JsonSave = File.ReadAllText(Application.persistentDataPath + "/CurrencyData.json");
        //_CurrencyData = JsonUtility.FromJson<CurrencyData>(JsonSave);
    }

    public void SpawnPrefabs()
    {
        Instantiate(dolarSavePrefabs, saveDolarPrefabsTransform.position, dolarSavePrefabs.transform.rotation);
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
}

