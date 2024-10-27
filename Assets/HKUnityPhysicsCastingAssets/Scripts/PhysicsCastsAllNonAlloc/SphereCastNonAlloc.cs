using UnityEngine;

public class SphereCastNonAlloc : MonoBehaviour
{

    [SerializeField] private float radius = 0.5f;
    [SerializeField] private float maxDistance = 10f;

    [SerializeField] private LayerMask hitLayer;
    [SerializeField] private QueryTriggerInteraction triggerInteraction;

    private RaycastHit[] raycastHits = new RaycastHit[10];

    private void OnDrawGizmos()
    {
        Vector3 direction = -transform.up;

        Physics.SphereCastNonAlloc(transform.position, radius, direction, raycastHits, maxDistance, hitLayer, triggerInteraction);

        Gizmos.color = Color.cyan;

        for (int i = 0; i < raycastHits.Length; i++)
        {
            Gizmos.DrawWireSphere(raycastHits[i].point, 0.3f);
        }
    }
}
