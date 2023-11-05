using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManagement : MonoBehaviour
{
    public GameObject takingPanel;
    public GameObject sellingPanel;

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
