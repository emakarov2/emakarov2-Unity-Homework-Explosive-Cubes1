using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{    
    [SerializeField] private Exploder _exploder;
    [SerializeField] private CubeFactory _cubeFactory;
    [SerializeField] private float _spawnRadius = 3f;
    [SerializeField] private int _minSpawnCount = 2;
    [SerializeField] private int _maxSpawnCount = 6;

    private void OnEnable()
    {
        if (FindObjectOfType<Raycaster>() != null)
        {
            FindObjectOfType<Raycaster>().CubeSelected += HandleCubeClicked;
        }
    }

    private void OnDisable()
    {
        if (FindObjectOfType<Raycaster>() != null)
        {
            FindObjectOfType<Raycaster>().CubeSelected -= HandleCubeClicked;
        }
    }

    private void HandleCubeClicked(Cube clickedCube)
    {
        if (CanSpawnCubes(clickedCube.SpawnChance))
        {
            _exploder.Explode(clickedCube, SpawnCubes(clickedCube));
        }
        else
        {
            _exploder.Explode(clickedCube);
        }

            Destroy(clickedCube.gameObject);
    }

    private List<Rigidbody> SpawnCubes(Cube clickedCube)
    {
        int spawnCount = CalculateSpawnCount();

        List<Rigidbody> targets = new List<Rigidbody>();

        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 newPosition = CalculateSpawnPosition(clickedCube);

            targets.Add(_cubeFactory.Create(newPosition, clickedCube));
        }

        return targets;
    }

    private bool CanSpawnCubes(float chance)
    {
        return Random.value <= chance;
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