using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    private float _scaleDecrease = 2f;
    private float _spawnChanceDecreace = 2f;

    public Cube Create(Vector3 position, Cube cubeInfo)
    {
        Cube newCube = Object.Instantiate(cubeInfo, position, Quaternion.identity);

        newCube.Initialize(_spawnChanceDecreace, _scaleDecrease, GetColor());

        return newCube;
    }      

    private Color GetColor()
    {
        Color newColor = Random.ColorHSV();

        return newColor;
    }
}
