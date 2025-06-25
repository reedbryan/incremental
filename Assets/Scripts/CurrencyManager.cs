using System.Numerics;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    
    // nsures that there is only one instance of CurrencyManager accessible globally via CurrencyManager.Instance
    public static CurrencyManager Instance;

    public BigInteger cookies = BigInteger.Zero;

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

    public void AddCookies(BigInteger amount)
    {
        cookies += amount;
    }

    public void SaveData()
    {
        PlayerPrefs.SetString("cookies", cookies.ToString());
        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        string saved = PlayerPrefs.GetString("cookies", "0");
        cookies = BigInteger.Parse(saved);
    }
}
