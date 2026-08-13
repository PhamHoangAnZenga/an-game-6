using UnityEngine;

public class CloseButton : MonoBehaviour
{
    [SerializeField] GameObject _target;

    public void Close()
    {
        _target.SetActive(false);
    }
}
