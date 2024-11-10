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

    public float clickTimer;
    public float autoSaveTimer;

    void Start()
    {
        Load();
    }

    void Update()
    {
        clicksText.text = clicks.ToString();
        employeeCountText.text = employeeCount.ToString();
        employeePriceText.text = employeePrice.ToString();

        clickTimer += Time.deltaTime;
        autoSaveTimer += Time.deltaTime;

        if (clickTimer >= 1)
        {
            AddClick();
            clickTimer = 0;
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
        employeePrice = PlayerPrefs.GetInt("employeePrice");
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
}
