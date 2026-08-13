using UnityEngine;

public class GuideButton : MonoBehaviour
{
    [SerializeField] GameObject _guide;

    public void OpenGuide()
    {
        _guide.SetActive(true);
    }
}
