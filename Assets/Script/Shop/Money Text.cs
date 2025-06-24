using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyText : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    private int lastMoney = -1;

    void Update()
    {
        int current = MoneyManager.LoadMoney();
        if (current != lastMoney)
        {
            moneyText.text = $"Money :  {current}";
            lastMoney = current;
        }
    }
}
