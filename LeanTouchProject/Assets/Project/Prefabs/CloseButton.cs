using UnityEngine;

public class CloseButton : MonoBehaviour
{
    [SerializeField] GameObject _target;

    public void OpenGuide()
    {
        _target.SetActive(false);
    }
}
