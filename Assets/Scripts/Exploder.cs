using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 1000f;
    [SerializeField] private float _explosionRadius = 15f;

    public void Explode(CubeInfo explosiveCube, List<Rigidbody> targets)
    {
        foreach (Rigidbody target in targets) 
        {
            target.AddExplosionForce(_explosionForce, explosiveCube.transform.position, _explosionRadius);
        }
    }
}
