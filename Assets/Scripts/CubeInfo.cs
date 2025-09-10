using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _spawnChance = 1f;    

    public float SpawnChance => _spawnChance;

    public void SetSpawnChance(float chance)
    {
        _spawnChance = chance;
    }
}
