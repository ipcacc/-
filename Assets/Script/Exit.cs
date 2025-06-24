using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    // Update is called once per frame
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("게임 종료");
    }
}
