using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManger : MonoBehaviour
{
    public GameObject shopPanel;

    // ���� ����
    public void OpenShop()
    {
        shopPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    // ���� �ݱ�
    public void CloseShop()
    {
        shopPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
