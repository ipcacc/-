using UnityEngine;
using System.IO;

[System.Serializable]
public class ScoreData
{
    public int score;
}

public class ScoreManager : MonoBehaviour
{
    public static string savePath => Application.persistentDataPath + "/ScoreData.json";

    public static void SaveScore(int score)
    {
        ScoreData data = new ScoreData { score = score };
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
    }

    public static int LoadScore()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            ScoreData data = JsonUtility.FromJson<ScoreData>(json);
            return data.score;
        }
        else
        {
            return 0;
        }
    }

    // 점수 소비 부분
    public static void SpendScore(int amount)
    {
        int current = LoadScore();
        current -= amount;
        current = Mathf.Max(0, current);
        SaveScore(current);
    }

    // 점수 추가 부분
    public static void AddScore(int amount)
    {
        int current = LoadScore();
        current += amount;
        SaveScore(current);
    }
}
