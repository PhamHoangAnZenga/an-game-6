using Lean.Common;
using UnityEngine;

public class CustomLeanColorChange : MonoBehaviour
{
    [SerializeField] Renderer _renderer;
    [SerializeField] LeanSelectable _selectable;
    
    [Header("Config")]
    [SerializeField] Color _defaultColor;
    [SerializeField] Color _activeColor;

    void Awake()
    {
        SetColor(_defaultColor);
    }
    
    void OnEnable()
    {
        _selectable.OnSelected.AddListener(OnSelected);
        _selectable.OnDeselected.AddListener(OnDeselected);
    }

    void OnDisable()
    {
        _selectable.OnSelected.RemoveListener(OnSelected);
        _selectable.OnDeselected.RemoveListener(OnDeselected);
    }

    void OnSelected(LeanSelect select)
    {
        SetColor(_activeColor);
    }

    void OnDeselected(LeanSelect select)
    {
        SetColor(_defaultColor);
    }

    void SetColor(Color color)
    {
        _renderer.material.color = color;
    }
}
