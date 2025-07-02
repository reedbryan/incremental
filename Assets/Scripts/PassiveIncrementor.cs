using UnityEngine;

public class PassiveIncrementor : MonoBehaviour
{
    [SerializeField] private int _rate;
    public int Rate
    {
        get => _rate;
        set {
            _rate = value;
        }
    }
    
    public void Init(int rate)
    {
        Rate = rate;
        InvokeRepeating(nameof(Increment), 1f, 0f);
    }

    public void Increment()
    {
        CurrencyManager.Instance.AddCash(Rate);
    }
}
