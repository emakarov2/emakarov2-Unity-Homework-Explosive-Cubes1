using UnityEngine;

public class ClickReader : MonoBehaviour
{
    private const int CkickNumber = 0;

    public event System.Action<Vector2> ClickAccepted;

    private void Update()
    {
        if (Input.GetMouseButtonDown(CkickNumber))
        {
            Vector2 clickPosition = Input.mousePosition;

            ClickAccepted?.Invoke(clickPosition);
        }
    }
}