using UnityEngine;
using System.IO;

[System.Serializable]
public class MoneyData
{
    public int money;
}

public class MoneyManager : MonoBehaviour
{
    private static string path => Application.persistentDataPath + "/MoneyData.json";

    public static void AddMoney(int amount)
    {
        int current = LoadMoney();
        current += amount;
        SaveMoney(current);
    }

    public static void SpendMoney(int amount)
    {
        int current = LoadMoney();
        current = Mathf.Max(0, current - amount);
        SaveMoney(current);
    }

    public static int LoadMoney()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<MoneyData>(json).money;
        }
        return 0;
    }

    public static void SaveMoney(int amount)
    {
        MoneyData data = new MoneyData { money = amount };
        File.WriteAllText(path, JsonUtility.ToJson(data, true));
    }
}

