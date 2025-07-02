using System.Numerics;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    
    // nsures that there is only one instance of CurrencyManager accessible globally via CurrencyManager.Instance
    public static CurrencyManager Instance;

    public int cash = 0;

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadData();
        } else {
            Destroy(gameObject);
        }
    }

    public void AddCash(int amount)
    {
        cash += amount;
    }

    public void SaveData()
    {
        PlayerPrefs.SetString("cash", cash.ToString());
        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        string saved = PlayerPrefs.GetString("cash", "0");
        cash = int.Parse(saved);
    }
}
