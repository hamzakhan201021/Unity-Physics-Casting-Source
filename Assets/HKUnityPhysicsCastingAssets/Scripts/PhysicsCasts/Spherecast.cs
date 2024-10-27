using UnityEngine;

public class Spherecast : MonoBehaviour
{

    [SerializeField] private float radius = 0.5f;
    [SerializeField] private float maxDistance = 10f;

    [SerializeField] private LayerMask hitLayer;
    [SerializeField] private QueryTriggerInteraction triggerInteraction;

    private void OnDrawGizmos()
    {
        Vector3 direction = -transform.up;

        Physics.SphereCast(transform.position, radius, direction, out RaycastHit hitInfo, maxDistance, hitLayer, triggerInteraction);

        Vector3 spherePosition = transform.position + direction * (hitInfo.distance);

        Gizmos.DrawWireSphere(spherePosition, radius);

        Debug.Log(hitInfo.transform.name);
    }
}
