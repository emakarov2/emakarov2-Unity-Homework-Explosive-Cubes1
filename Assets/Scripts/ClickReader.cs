using UnityEngine;

public class ClickReader : MonoBehaviour
{
    private const int LeftMouseButtonNumber = 0;

    private Raycaster _raycaster = new Raycaster();

    public event System.Action<Cube> CubeClicked;

   private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButtonNumber))
        {
            if (_raycaster.TryGetClickedCube(out Cube result)) 
            { 
            CubeClicked?.Invoke(result);                
            }
        }
    }
}
