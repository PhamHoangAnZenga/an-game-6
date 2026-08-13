using Lean.Common;
using Lean.Touch;
using UnityEngine;

public class CustomLeanRotate : MonoBehaviour
{
    [SerializeField] LeanSelectable _selectable;

    [Header("Config")]
    [SerializeField] float _rotateSpeed = 1.0f;
    [SerializeField] float _rotateTime = 1.0f;

    float _targetAngle;
    float _timer;

    Vector3 _direction;

    void OnEnable()
    {
        LeanTouch.OnFingerSwipe += Rotate;
        LeanTouch.OnFingerDown += StopRotate;
    }
    
    void OnDisable()
    {
        LeanTouch.OnFingerSwipe -= Rotate;
        LeanTouch.OnFingerDown -= StopRotate;
    }
    
    void Update()
    {
        if (_timer > 0.01f)
        {
            float deltaT = Mathf.Min(Time.deltaTime, _timer);
            float deltaAngle = _targetAngle * deltaT;
            _timer -= deltaT;

            transform.Rotate(
                _direction,
                deltaAngle,
                Space.World
            );
        }
    }

    void Rotate(LeanFinger finger)
    {
        if (_selectable.IsSelected)
        {
            float xSwipe = finger.SwipeScaledDelta.x;
            float ySwipe = finger.SwipeScaledDelta.y;
            Debug.Log(finger.SwipeScaledDelta * _rotateSpeed);

            if (Mathf.Abs(xSwipe) > Mathf.Abs(ySwipe))
            {
                _direction = Vector3.up;
                _targetAngle = -xSwipe * _rotateSpeed;

                _timer = _rotateTime;
            }
            else
            {
                _direction = Vector3.left;
                _targetAngle = -ySwipe * _rotateSpeed;

                _timer = _rotateTime;
            }
        }
    }
    
    void StopRotate(LeanFinger finger)
    {
        _timer = 0;
    }
}
