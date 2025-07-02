using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class ClickIncrementor : MonoBehaviour
{
    [SerializeField] private int _rate;

    public int Rate
    {
        get => _rate;
        set {
            _rate = value;
            _button.GetComponentInChildren<TMP_Text>().text = "+" + _rate.ToString();
        }
    }

    private CurrencyManager _currencyManager;
    private Button _button;

    void Awake()
    {   
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    void Start()
    {
        Rate = _rate;
    }

    void OnDestroy()
    {
        // Clean up the listener to avoid memory leaks
        if (_button != null)
            _button.onClick.RemoveListener(OnClick);
    }

    public void OnClick()
    {
        // Your button click logic here
       CurrencyManager.Instance.AddCash(_rate);
    }
}
