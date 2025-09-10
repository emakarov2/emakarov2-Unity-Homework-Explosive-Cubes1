using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    private float _scaleDecrease = 2f;
    private float _spawnChanceDecreace = 2f;

    public Rigidbody Create(Vector3 position, Cube cubeInfo)
    {
        Cube newCube = Object.Instantiate(cubeInfo, position, Quaternion.identity);

        newCube.Initialize(_spawnChanceDecreace, _scaleDecrease, SetColor());

        if (newCube.TryGetComponent(out Rigidbody rigidbody))
        {
            return rigidbody;
        }
        else
        {
            return null;
        }
    }      

    private Color SetColor()
    {
        Color newColor = Random.ColorHSV();

        return newColor;
    }
}
