using UnityEngine;
using System.IO;

[System.Serializable]
public class InitialMoneyData
{
    public int initialMoney;
}

public static class InitialMoneyManager
{
    private static string path => Application.persistentDataPath + "/InitialMoney.json";

    public static int LoadInitialMoney()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<InitialMoneyData>(json).initialMoney;
        }
        return 1000; // ±âº»°ª
    }

    public static void SaveInitialMoney(int amount)
    {
        File.WriteAllText(path, JsonUtility.ToJson(new InitialMoneyData { initialMoney = amount }, true));
    }

    public static void UpgradeInitialMoney(int amount)
    {
        SaveInitialMoney(LoadInitialMoney() + amount);
    }
}
