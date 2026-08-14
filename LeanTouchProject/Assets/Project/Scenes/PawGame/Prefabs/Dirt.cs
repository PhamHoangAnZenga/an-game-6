using Lean.Common;
using UnityEngine;

public class Dirt : MonoBehaviour
{
    public System.Action OnClear;

    [SerializeField] Renderer _renderer;
    [SerializeField] LeanSelectable _selectable;
    [SerializeField] float _durability;

    float _startDurability;

    void Awake()
    {
        _durability *= Random.Range(0.8f, 1.2f);
        _startDurability = _durability;
    }

    void OnEnable()
    {
        _selectable.OnSelected.AddListener(Deactive);
    }

    void OnDisable()
    {
        _selectable.OnSelected.RemoveListener(Deactive);
    }
    public void Clean(float value)
    {
        _durability -= value;
        if (_durability <= 0)
        {
            ClearMe();
            return;
        }
        Color color = _renderer.material.color;
        color.a = Mathf.Max(_durability / _startDurability, 0.36f);
        _renderer.material.color = color;
    }

    void Deactive(LeanSelect select)
    {
        ClearMe();
    }

    void ClearMe()
    {
        OnClear.Invoke();
        OnClear = null;
        Destroy(gameObject);        
    }
}
