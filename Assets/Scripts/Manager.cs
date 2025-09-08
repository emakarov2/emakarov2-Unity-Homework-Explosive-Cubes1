using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private ClickReader _clickReader;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    private void OnEnable()
    {
        _clickReader.OnCubeClicked += HandleCubeClicked;
    }

    private void OnDisable()
    {
        _clickReader.OnCubeClicked -= HandleCubeClicked;
    }

    private void HandleCubeClicked(CubeInfo clickedCube)
    {
        if (IsNewCubesSpawn(clickedCube.SpawnChance))
        {
            _exploder.Explode(clickedCube, _spawner.SpawnCubes(clickedCube));
        }

        Destroy(clickedCube.gameObject);
    }

    private bool IsNewCubesSpawn(float chance)
    {
        return Random.value <= chance;
    }
}
