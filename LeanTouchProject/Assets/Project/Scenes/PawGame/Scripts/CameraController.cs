using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float _zoomSpeed;

    LeanTwistRotate lean;

    void OnEnable()
    {
        LeanTouch.OnGesture += OnGesture;
    }

    void OnDisable()
    {
        LeanTouch.OnGesture -= OnGesture;
    }

    void OnGesture(List<LeanFinger> fingers)
    {
        if (fingers.Count != 2) return;

        

    }

    void Zoom(float distance)
    {
        //transform.position += ;
    }
}
