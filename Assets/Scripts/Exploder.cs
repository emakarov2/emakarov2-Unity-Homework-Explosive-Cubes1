using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 500;
    [SerializeField] private float _explosionRadius = 10f;

    public void Explode(Cube explosiveCube, List<Rigidbody> targets)
    {
        AddExplosionForceToGroup(_explosionForce, explosiveCube.transform.position, _explosionRadius, targets);
    }

    public void Explode(Cube explosiveCube) 
    {
        float radius = _explosionRadius * explosiveCube.ExplodeModifer;
        float force = _explosionForce * explosiveCube.ExplodeModifer;

        List<Rigidbody> targets = GetTargets(explosiveCube.transform.position, radius);

        AddExplosionForceToGroup(force, explosiveCube.transform.position, radius, targets);
    }

    private void AddExplosionForceToGroup(float force, Vector3 center, float radius, List<Rigidbody> targets)
    {
        foreach (Rigidbody target in targets)
        {
            target.AddExplosionForce(force, center, radius);
        }
    }

    private List<Rigidbody> GetTargets(Vector3 center, float radius)
    {
        Collider[] targetColliders = Physics.OverlapSphere(center, radius);

        List<Rigidbody> targetRigidbodies = new();

        foreach (Collider collider in targetColliders)
        {
            if (collider.attachedRigidbody != null)
            {
                targetRigidbodies.Add(collider.attachedRigidbody);
            }
        }

        return targetRigidbodies;
    }
}
