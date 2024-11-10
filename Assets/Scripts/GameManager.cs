using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text clicksText;
    public TMP_Text employeeCountText;
    public TMP_Text employeePriceText;
    public TMP_Text cpsText;
    int employeeCount;
    int clicks;
    public int employeePrice;

    public float clickTimer;
    public float autoSaveTimer;
    float cps;

    void Start()
    {
        Load();
    }

    void Update()
    {
        
        clicksText.text = clicks.ToString("N0");               //       Formatting of 1054.32179:
        employeeCountText.text = employeeCount.ToString();     //          N:                     1,054.32
        employeePriceText.text = $"Price: {employeePrice}";    //          N0:                    1,054 
                                                               //          N1:                    1,054.3
        clickTimer += Time.deltaTime;                          //          N2:                    1,054.32
        autoSaveTimer += Time.deltaTime;                       //          N3:                    1,054.322

        UpdateCPS();

        if (clickTimer >= 1)
        {
            clickTimer = 0;
            clicks += Convert.ToInt32(cps);
        }
        if (autoSaveTimer >= 10)
        {
            Save();
            autoSaveTimer = 0;
        }
    }

    void Save()
    {
        PlayerPrefs.SetInt("clicks", clicks);
        PlayerPrefs.SetInt("employee", employeeCount);
        PlayerPrefs.SetInt("employeePrice", employeePrice);
    }

    void Load()
    {
        clicks = PlayerPrefs.GetInt("clicks");
        employeeCount = PlayerPrefs.GetInt("employee");
        employeePrice = PlayerPrefs.GetInt("employeePrice", employeePrice);
    }

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
    }

    void OnApplicationQuit()
    {
        Save();
    }

    void UpdateCPS() // used to calculate cps from all purchased upgrades
    {
        cps = employeeCount;
        cpsText.text = $"{cps} cps";
    }
}
