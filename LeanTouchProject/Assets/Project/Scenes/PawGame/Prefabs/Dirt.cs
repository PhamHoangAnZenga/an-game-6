using Lean.Common;
using UnityEngine;

public class Dirt : MonoBehaviour
{
    [SerializeField] LeanSelectable _selectable;

    void OnEnable()
    {
        _selectable.OnSelected.AddListener(Deactive);
    }

    void OnDisable()
    {
        _selectable.OnSelected.RemoveListener(Deactive);
    }
    
    void Deactive(LeanSelect select)
    {
        Destroy(gameObject);
    }
}
