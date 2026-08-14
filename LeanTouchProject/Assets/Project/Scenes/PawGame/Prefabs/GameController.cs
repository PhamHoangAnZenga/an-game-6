using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] LayerMask _dirtMask;
    [SerializeField] LayerMask _groundMask;
    [SerializeField] Dirt _dirtPrefab;
    [SerializeField] ParticleSystem _particle;
    [SerializeField] GameObject _winNotice; 

    [Header("Config")]
    [SerializeField] float _spawnRadius;
    [SerializeField] int _dirtSpawnNumber;

    bool _isPressed = false;
    int _dirtLast;

    void Start()
    {
        for (int i = 0; i < _dirtSpawnNumber; ++i)
        {
            Vector2 position = Random.onUnitCircle * Random.Range(0, _spawnRadius);
            Dirt dirt = Instantiate(_dirtPrefab, new Vector3(position.x, 0.1f, position.y), Quaternion.identity);
            dirt.OnClear += Clear;
        }
        _dirtLast = _dirtSpawnNumber;

        var emission = _particle.emission;
        emission.enabled = _isPressed;
    }

    void Update()
    {        
        if (_isPressed)
        {
            Vector2 inputPosition = Vector2.zero;

            // #if UNITY_EDITOR 
            // if (Mouse.current != null)
            // {
            //     inputPosition = Mouse.current.position.ReadValue();
            // }
            // #else
            if (Touchscreen.current != null)
            {
                inputPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            }
            // #endif
            
            Ray ray = _camera.ScreenPointToRay(inputPosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _dirtMask))
            {
                Dirt dirt = hit.collider.gameObject.GetComponent<Dirt>();
                dirt.Clean(Time.deltaTime);
            }

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _groundMask))
            {
                Vector3 pos = hit.point;
                pos.y = 0.36f;
                _particle.transform.position = pos;
            }
        }
    }

    public void Active()
    {
        _isPressed = true;
        var emission = _particle.emission;
        emission.enabled = _isPressed;
    }

    public void Deactive()
    {
        _isPressed = false;
        var emission = _particle.emission;
        emission.enabled = _isPressed;
    }

    void Clear()
    {
        _dirtLast -= 1;
        if (_dirtLast <= 0)
        {
            Win();
        }
    }
    
    void Win()
    {
        _winNotice.SetActive(true);
    }
}
