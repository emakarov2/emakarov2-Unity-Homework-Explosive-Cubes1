using System.Collections.Generic;
using UnityEngine;

public class CubeHitHandler : MonoBehaviour
{
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _raycaster.CubeSelected += HandleCubeClicked;
    }

    private void OnDisable()
    {
        _raycaster.CubeSelected -= HandleCubeClicked;
    }

    private void HandleCubeClicked(Cube clickedCube)
    {
        if (CanSpawnCubes(clickedCube.SpawnChance))
        {
            _exploder.Explode(clickedCube, GetTargets(_spawner.SpawnCubes(clickedCube)));
        }
        else
        {
            _exploder.Explode(clickedCube);
        }

        Destroy(clickedCube.gameObject);
    }

    private List<Rigidbody> GetTargets(List<Cube> cubes)
    {
        List<Rigidbody> targets = new List<Rigidbody>();

        for (int i = 0; i < cubes.Count; i++)
        {
            targets.Add(cubes[i].Rigidbody);
        }

        return targets;
    }

    private bool CanSpawnCubes(float chance)
    {
        return Random.value <= chance;
    }
}
