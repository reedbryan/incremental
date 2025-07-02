using UnityEngine;
using TMPro;

public class DisplayCounter : MonoBehaviour
{
    [SerializeField] private string _prefix;
    [SerializeField] private string _suffix;
    
    TMP_Text _text;

    void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    public void UpdateDisplay(int value)
    {
        _text.text = _prefix + value.ToString() + _suffix;
    }
}
