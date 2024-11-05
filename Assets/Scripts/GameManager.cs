using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int clicks;
    public TMP_Text clicksText;


    public TMP_Text employeeCountText;
    int employeeCount;

    public void BuyEmployee()
    {
        employeeCount++;
        employeeCountText.text = employeeCount.ToString();
    }

    public void AddClick()
    {
        clicks++;
        clicksText.text = clicks.ToString();
    }
}
