[System.Serializable]
public class CurrencyData
{
    public string GenusCurrency = "";

    public decimal TakingDolar;

    public decimal SellingDolar;

    public CurrencyData()
    {

    }

    public CurrencyData(string genusCurrency, decimal takingDolar, decimal sellingDolar)
    {
        GenusCurrency = genusCurrency;
        TakingDolar = takingDolar;
        SellingDolar = sellingDolar;
    }
}