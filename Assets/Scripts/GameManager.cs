using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text employeeCountText;
    int employeeCount;

    public void BuyEmployee()
    {
        employeeCount++;
        employeeCountText.text = employeeCount.ToString();
    }
}
