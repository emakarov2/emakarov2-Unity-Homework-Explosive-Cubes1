using UnityEngine;

public class ClickReader : MonoBehaviour
{
    private const int LeftMouseButtonNumber = 0;

    public event System.Action<CubeInfo> OnCubeClicked;

    void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButtonNumber))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                CubeInfo cube = hit.collider.GetComponent<CubeInfo>();

                if (cube != null)
                {
                    OnCubeClicked?.Invoke(cube);
                }
            }
        }
    }
}
