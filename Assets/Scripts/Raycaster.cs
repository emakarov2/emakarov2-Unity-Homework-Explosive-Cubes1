using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private ClickReader _clickReader;

    public event System.Action<Cube> CubeSelected;

    private void OnEnable()
    {
        _clickReader.ClickAccepted += TryGetCube;
    }

    private void OnDisable()
    {
        _clickReader.ClickAccepted -= TryGetCube;
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