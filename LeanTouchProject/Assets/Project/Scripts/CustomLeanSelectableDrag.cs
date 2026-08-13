using Lean.Common;
using Lean.Touch;

public class CustomLeanSelectableDrag : LeanSelectable
{
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
        SelfSelected = true;
    }
    
    public void Deactive(LeanFinger finger)
    {
        SelfSelected = false;
    }
}
