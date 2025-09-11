using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(Renderer))]

public class Cube : MonoBehaviour
{
    [SerializeField] private float _spawnChance = 1f;
    [SerializeField] private float _explodeModifer = 1f;
            
    public float SpawnChance => _spawnChance;
    public float ExplodeModifer => _explodeModifer;
    
    public void Initialize(float chanceDecreace, float scaleDecrease, Color newColor)
    {
        SetColor(newColor);
        SpawnChanceDecrease(chanceDecreace);
        DecreaseScale(scaleDecrease);
        IncreaseExplosion(scaleDecrease);
    }
    
    private void SpawnChanceDecrease(float decrease)
    {
        _spawnChance /= decrease;
    }

    private void SetColor(Color color)
    {
        if (TryGetComponent(out Renderer renderer))
        {
            renderer.material.color = color;
        }    
    }

    private void DecreaseScale(float decrease)
    {
        transform.localScale /= decrease;
    }

    private void IncreaseExplosion(float increace)
    {
        _explodeModifer *=  increace;
    }
}
