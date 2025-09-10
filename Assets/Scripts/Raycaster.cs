using UnityEngine;

public class Raycaster
{
    public bool TryGetClickedCube(out Cube result)
    {
        result = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out Cube cube))
            {
                result = cube;

                return true;
            }
        }

        return false;
    }
}
