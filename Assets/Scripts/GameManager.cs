using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text clicksText;
    public TMP_Text employeeCountText;
    public TMP_Text employeePriceText;
    int employeeCount;
    int clicks;
    int employeePrice = 100;

    public void BuyEmployee()
    {
        if (clicks >= employeePrice)
        {
            employeeCount++;
            employeeCountText.text = employeeCount.ToString();

            clicks -= employeePrice;
            clicksText.text = clicks.ToString();

            employeePrice += employeePrice / 10;
            employeePriceText.text = $"Price: {employeePrice}";
        }
    }

    public void AddClick()
    {
        clicks++;
        clicksText.text = clicks.ToString();
    }
}
