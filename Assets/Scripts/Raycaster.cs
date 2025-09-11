using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public event System.Action<Cube> CubeSelected;

    private void OnEnable()
    {
        if (FindObjectOfType<ClickReader>() != null)
        {
            FindObjectOfType<ClickReader>().ClickAccepted += TryGetCube;
        }
    }

    private void OnDisable()
    {
        if (FindObjectOfType<ClickReader>() != null)
        {
            FindObjectOfType<ClickReader>().ClickAccepted -= TryGetCube;
        }
    }

    private void TryGetCube(Vector2 position)
    {
        Ray ray = Camera.main.ScreenPointToRay(position);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out Cube cube))
            {
                CubeSelected?.Invoke(cube);
            }
        }
    }
}
