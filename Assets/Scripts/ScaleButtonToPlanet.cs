using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(RectTransform), typeof(Button))]
public class ScaleButtonToPlanet : MonoBehaviour
{
    public PlanetID planetID;

    private float _worldToScreenSizeRatio = 27f; // At orthorgraphic size of 5
    private float _baseCameraSize = 5f;
    private float _baseFontSize = 5f;

    private RectTransform _rectTransform;
    private Camera _mainCamera;
    private TMP_Text _text;

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _text = GetComponentInChildren<TMP_Text>();
        _mainCamera = Camera.main;

        InvokeRepeating(nameof(UpdateButtonValues), 0f, 0.1f);
    }

    private void UpdateButtonValues()
    {
        // position
        _rectTransform.position = _mainCamera.WorldToScreenPoint(planetID.transform.position);
        
        // scale
        float size = (_baseCameraSize / _mainCamera.orthographicSize) * _worldToScreenSizeRatio * planetID.radius * 2f;
        _rectTransform.sizeDelta = new Vector2(size, size);

        // font
        _text.fontSize = _baseFontSize * size / _worldToScreenSizeRatio;
    }
}
