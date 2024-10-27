using UnityEngine;

public class RayCastNonAlloc : MonoBehaviour
{

    [SerializeField] private float _maxDistance;

    [SerializeField] private LayerMask _layerToHit;
    [SerializeField] private QueryTriggerInteraction _triggerInteraction;

    [SerializeField] private Transform _alignObject;

    private RaycastHit[] raycastHits = new RaycastHit[10];

    private void OnDrawGizmos()
    {
        Vector3 direction = -transform.up;

        Physics.RaycastNonAlloc(transform.position, direction, raycastHits, _maxDistance, _layerToHit, _triggerInteraction);

        if (raycastHits.Length > 0) Gizmos.DrawLine(transform.position, transform.position + direction * raycastHits[raycastHits.Length - 1].distance);
        else Gizmos.DrawLine(transform.position, transform.position + direction * _maxDistance);

        if (_alignObject != null)
        {
            _alignObject.position = raycastHits[raycastHits.Length - 1].point;
            _alignObject.rotation = Quaternion.FromToRotation(-direction, raycastHits[raycastHits.Length - 1].normal);
        }

        for (int i = 0; i < raycastHits.Length; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(raycastHits[i].point, 0.2f);
        }
    }
}
