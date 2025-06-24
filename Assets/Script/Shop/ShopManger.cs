using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManger : MonoBehaviour
{
    public GameObject shopPanel;

    // 상점 열기
    public void OpenShop()
    {
        shopPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    // 상점 닫기
    public void CloseShop()
    {
        shopPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
