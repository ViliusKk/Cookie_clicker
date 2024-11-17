using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int clickPower = 1;
    public float clicks;
    float cps;

    public TMP_Text clicksText;
    public TMP_Text cpsText;

    public Button employeeButton;
    public TMP_Text employeeCountText;
    public TMP_Text employeePriceText;
    public int employeePrice;
    int employeeCount;

    public Button cursorButton;
    public TMP_Text cursorCountText;
    public TMP_Text cursorPriceText;
    public int cursorPrice;
    int cursorCount;

    public Button upgradeButton;

    public float clickTimer;
    public float autoSaveTimer;

    void Start()
    {
        Load();
    }

    void Update()
    {
        
        clicksText.text = clicks.ToString("N0");               //       Formatting of 1054.32179:
        employeeCountText.text = employeeCount.ToString();     //          N:                     1,054.32
        employeePriceText.text = $"Price: {employeePrice}";    //          N0:                    1,054
        cursorCountText.text = cursorCount.ToString();         //          N1:                    1,054.3
        cursorPriceText.text = $"Price: {cursorPrice}";
        clickTimer += Time.deltaTime;                          //          N2:                    1,054.32
        autoSaveTimer += Time.deltaTime;                       //          N3:                    1,054.322


        if (clickTimer >= 1)
        {
            clickTimer = 0;
            UpdateCPS();
            clicks += cps;
        }
        if (autoSaveTimer >= 10)
        {
            Save();
            autoSaveTimer = 0;
        }


        // hiding or showing buttons, depends if they can be bought
        employeeButton.interactable = clicks >= employeePrice;
        cursorButton.interactable = clicks >= cursorPrice;
        upgradeButton.interactable = clicks >= 100;

    }

    void Save()
    {
        PlayerPrefs.SetFloat("clicks", clicks);
        PlayerPrefs.SetInt("employee", employeeCount);
        PlayerPrefs.SetInt("employeePrice", employeePrice);
        PlayerPrefs.SetFloat("cps", cps);
        PlayerPrefs.SetInt("cursor", cursorCount);
        PlayerPrefs.SetInt("cursorPrice", cursorPrice);
        PlayerPrefs.SetInt("clickPower", clickPower);
    }

    void Load()
    {
        clicks = PlayerPrefs.GetFloat("clicks");
        employeeCount = PlayerPrefs.GetInt("employee");
        employeePrice = PlayerPrefs.GetInt("employeePrice", employeePrice);
        cps = PlayerPrefs.GetFloat("cps", cps);
        cursorCount = PlayerPrefs.GetInt("cursor", cursorCount);
        cursorPrice = PlayerPrefs.GetInt("cursorPrice", cursorPrice);
        clickPower = PlayerPrefs.GetInt("clickPower", clickPower);
    }

    public void BuyEmployee()
    {
        if (clicks >= employeePrice)
        {
            employeeCount++;
            employeeCountText.text = employeeCount.ToString();

            clicks -= employeePrice;
            clicksText.text = clicks.ToString("N0");

            employeePrice += employeePrice / 10;
            employeePriceText.text = $"Price: {employeePrice}";

            cps++;
        }
    }

    public void BuyCursor()
    {
        if (clicks >= cursorPrice)
        {
            cursorCount++;
            cursorCountText.text = cursorCount.ToString();

            clicks -= cursorPrice;
            clicksText.text = clicks.ToString("N0");

            cursorPrice += cursorPrice / 10;
            cursorPriceText.text = $"Price: {cursorPrice}";

            cps += 0.1f;
        }
    }

    public void AddClick()
    {
        clicks += clickPower;
    }

    void OnApplicationQuit()
    {
        Save();
    }

    void UpdateCPS() // used to calculate cps from all purchased upgrades
    {
        //cps = employeeCount;
        cpsText.text = $"{cps.ToString("N1")} cps";
    }

    public void BuyClickUpgrade()
    {
        clickPower *= 2;
        clicks -= 100;
    }
}
