using UnityEngine;

public class BoxCastNonAlloc : MonoBehaviour
{

    [SerializeField] private Vector3 _boxCastSize = new Vector3(0.2f, 0.2f, 0.2f);
    [SerializeField] private float _maxDistance = 10f;

    [SerializeField] private LayerMask _hitLayer;
    [SerializeField] private QueryTriggerInteraction _triggerInteraction;

    private RaycastHit[] raycastHits = new RaycastHit[10];

    private void OnDrawGizmos()
    {
        Vector3 direction = -transform.up;

        Physics.BoxCastNonAlloc(transform.position, _boxCastSize / 2, direction, raycastHits, transform.rotation, _maxDistance, _hitLayer, _triggerInteraction);

        for (int i = 0; i < raycastHits.Length; i++)
        {
            Gizmos.DrawWireSphere(raycastHits[i].point, 0.2f);
        }
    }
}
