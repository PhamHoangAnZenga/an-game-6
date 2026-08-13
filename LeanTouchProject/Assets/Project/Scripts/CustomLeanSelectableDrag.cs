using Lean.Common;
using Lean.Touch;
using UnityEngine;

public class CustomLeanSelectableDrag : LeanSelectable
{
    [SerializeField]LeanSelectable _selectable;

    protected override void OnEnable()
    {
        base.OnEnable();

        LeanTouch.OnFingerOld += Active;
        LeanTouch.OnFingerUp += Deactive;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        LeanTouch.OnFingerOld -= Active;
        LeanTouch.OnFingerUp -= Deactive;
    }
    
    public void Active(LeanFinger finger)
    {
        if (!_selectable.IsSelected) return;
        SelfSelected = true;
    }
    
    public void Deactive(LeanFinger finger)
    {
        SelfSelected = false;
    }
}
