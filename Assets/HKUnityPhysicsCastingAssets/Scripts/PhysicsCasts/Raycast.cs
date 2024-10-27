using UnityEngine;

public class Raycast : MonoBehaviour
{

    [SerializeField] private float _maxDistance;

    [SerializeField] private LayerMask _layerToHit;
    [SerializeField] private QueryTriggerInteraction _triggerInteraction;

    [SerializeField] private Transform _alignObject;
    
    private void OnDrawGizmos()
    {
        Vector3 direction = -transform.up;

        bool didHit = Physics.Raycast(transform.position, direction, out RaycastHit hitInfo, _maxDistance, _layerToHit, _triggerInteraction);

        if (didHit) Gizmos.DrawLine(transform.position, transform.position + direction * hitInfo.distance);
        else Gizmos.DrawLine(transform.position, transform.position + direction * _maxDistance);

        if (_alignObject != null)
        {
            _alignObject.position = hitInfo.point;
            _alignObject.rotation = Quaternion.FromToRotation(-direction, hitInfo.normal);
        }
    }
}
