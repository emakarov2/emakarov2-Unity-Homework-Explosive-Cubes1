using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 1000;
    [SerializeField] private float _explosionRadius = 10f;

    public void Explode(Cube explosiveCube, List<Rigidbody> targets)
    {
        foreach (Rigidbody target in targets) 
        {
            target.AddExplosionForce(_explosionForce, explosiveCube.transform.position, _explosionRadius);
        }
    }
}
