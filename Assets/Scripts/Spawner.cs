using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{ 
    [SerializeField] private CubeFactory _cubeFactory;
    [SerializeField] private float _spawnRadius = 3f;
    [SerializeField] private int _minSpawnCount = 2;
    [SerializeField] private int _maxSpawnCount = 6;
    
    public List<Cube> SpawnCubes(Cube clickedCube)
    {
        int spawnCount = CalculateSpawnCount();

        List<Cube> newCubes = new List<Cube>();

        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 newPosition = CalculateSpawnPosition(clickedCube);

            newCubes.Add(_cubeFactory.Create(newPosition, clickedCube));
        }

        return newCubes;
    }

    private int CalculateSpawnCount()
    {
        return UnityEngine.Random.Range(_minSpawnCount, _maxSpawnCount + 1);
    }

    private Vector3 CalculateSpawnPosition(Cube clickedCube)
    {
        Vector3 position = UnityEngine.Random.onUnitSphere * _spawnRadius;

        position.y = Mathf.Abs(position.y);

        return clickedCube.transform.position + position;
    }
}