using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Vendor : MonoBehaviour
{
    [SerializeField] private int rate;
    
    [SerializeField] private GameObject _passiveIncrementorPrefab;
    
    private Button _button;

    void Awake()
    {   
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    void OnDestroy()
    {
        // Clean up the listener to avoid memory leaks
        if (_button != null)
            _button.onClick.RemoveListener(OnClick);
    }

    public void OnClick()
    {
        CreatePassiveIncrementor(rate);
    }

    void CreatePassiveIncrementor(int rate)
    {
        GameObject passiveIncrementor = Instantiate(_passiveIncrementorPrefab);
        passiveIncrementor.GetComponent<PassiveIncrementor>().Init(rate);
    }
}
