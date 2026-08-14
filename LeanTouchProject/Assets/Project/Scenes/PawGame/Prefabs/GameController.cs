using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] float _spawnRadius;

    [SerializeField] Dirt _dirtPrefab;
    [SerializeField] int _dirtSpawnNumber;

    void Start()
    {

        for (int i = 0; i < _dirtSpawnNumber; ++i)
        {
            Vector2 position = Random.onUnitCircle * Random.Range(0, _spawnRadius);
            Instantiate(_dirtPrefab, new Vector3(position.x, 0.1f, position.y), Quaternion.identity);
        }                        
    }
}
