using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CubeFactory _cubeFactory;
    [SerializeField] private float _spawnRadius = 3f;
    [SerializeField] private int _minSpawnCount = 2;
    [SerializeField] private int _maxSpawnCount = 6;

    public List<Rigidbody> SpawnCubes(CubeInfo clickedCube)
    {
        int spawnCount = CalculateSpawnCount();

        List<Rigidbody> targets = new List<Rigidbody>();

        List<Vector3> spawnPositions = GetSpawnPositions(clickedCube, spawnCount);

        for (int i = 0; i < spawnCount; i++) 
        { 
        targets.Add(_cubeFactory.Create(spawnPositions[i], clickedCube));            
        }

        return targets;
    }

    private int CalculateSpawnCount()
    {
        return UnityEngine.Random.Range(_minSpawnCount, _maxSpawnCount + 1);
    }

    private List<Vector3> GetSpawnPositions(CubeInfo clickedCube, int count) 
    {
        List<Vector3> positions = new List<Vector3>();

        for (int i=0; i<count; i++)
        {
            Vector3 newPosition = CalculateSpawnPosition(clickedCube);
            
           positions.Add(newPosition);
        }

        return positions;
    }

    private Vector3 CalculateSpawnPosition(CubeInfo clickedCube)
    {
        Vector3 position = UnityEngine.Random.onUnitSphere * _spawnRadius;

        position.y = Mathf.Abs(position.y);

        return clickedCube.transform.position + position;
    }
}