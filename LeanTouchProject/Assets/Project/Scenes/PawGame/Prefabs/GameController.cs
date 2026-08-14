using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Center _centerPrefab;
    [SerializeField] float _centerSize;

    [SerializeField] Dirt _dirtPrefab;
    [SerializeField] int _dirtSpawnNumber;

    void Start()
    {
        Center center = Instantiate(_centerPrefab);
        center.transform.localScale *= _centerSize;

        for (int i = 0; i < _dirtSpawnNumber; ++i)
        {
            Vector3 position = Random.onUnitSphere * _centerSize / 2;
            Instantiate(_dirtPrefab, position, Quaternion.identity);
        }                        
    }
}
