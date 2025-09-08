using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    private float _scaleDecrease = 2f;
    private float _spawnChanceDecreace = 2f;

    public Rigidbody Create(Vector3 position, CubeInfo cubeInfo)
    {
        CubeInfo newCubeInfo = Object.Instantiate(cubeInfo, position, Quaternion.identity);

        SetColor(newCubeInfo);
        
        newCubeInfo.SetSpawnChance(CalculateSpawnChance(newCubeInfo.SpawnChance));

        newCubeInfo.transform.localScale /= _scaleDecrease;

        return newCubeInfo.GetComponent<Rigidbody>();
    }

    private void SetColor(CubeInfo cubeInfo)
    {
        Color newColor = Random.ColorHSV();

        cubeInfo.GetComponent<Renderer>().material.color = newColor;
    }

    private float CalculateSpawnChance(float chance)
    {
        return chance / _spawnChanceDecreace;
    }
}
