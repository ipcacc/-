using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSpend : MonoBehaviour
{
    public int scoreCost = 2000;
    public int upgradeAmount = 500;

    public void TryUpgrade()
    {
        int currentScore = ScoreManager.LoadScore();
        if (currentScore >= scoreCost)
        {
            ScoreManager.SpendScore(scoreCost);
            InitialMoneyManager.UpgradeInitialMoney(upgradeAmount);
            Debug.Log("�ʱ� �ڱ� ���׷��̵� �Ϸ�!");
        }
        else
        {
            Debug.Log("������ �����մϴ�.");
        }
    }
}
