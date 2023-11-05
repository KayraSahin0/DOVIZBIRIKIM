using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEditor.PackageManager.Requests;
using UnityEngine.Networking;
using UnityEngine;
using System.Net;
using System.IO;
using UnityEditor.UI;
using UnityEngine.UI;

public class DataManagement : MonoBehaviour
{
    public GameObject dolarText;

    void Start()
    {
        
    }

    public void GetDataValue()
    {
        WebRequest request = WebRequest.Create("https://finans.truncgil.com/v3/today.json");
        request.Credentials = CredentialCache.DefaultCredentials;
        WebResponse response = request.GetResponse();
        Stream dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        string responseFromServer = reader.ReadToEnd();
        string sRateBegin = "\"Buying\":";
        string sRateEnd = "\",\"";
        string sRate = responseFromServer.Substring(responseFromServer.IndexOf(sRateBegin) + sRateBegin.Length);
        sRate = sRate.Substring(0, sRate.IndexOf(sRateEnd));
        //dolarText.text = sRate;
        Debug.Log(sRate);
        reader.Close();
        response.Close();

        
    }

}

