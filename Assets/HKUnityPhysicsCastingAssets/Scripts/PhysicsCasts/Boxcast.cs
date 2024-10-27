using UnityEngine;

public class Boxcast : MonoBehaviour
{

    [SerializeField] private Vector3 _boxCastSize = new Vector3(0.2f, 0.2f, 0.2f);
    [SerializeField] private float _maxDistance = 10f;

    [SerializeField] private LayerMask _hitLayer;
    [SerializeField] private QueryTriggerInteraction _triggerInteraction;

    private void OnDrawGizmos()
    {
        Vector3 direction = -transform.up;

        bool didHit = Physics.BoxCast(transform.position, _boxCastSize / 2, direction, out RaycastHit hitInfo, transform.rotation, _maxDistance, _hitLayer, _triggerInteraction);

        Gizmos.matrix = Matrix4x4.TRS(transform.position + direction * hitInfo.distance, transform.rotation, Vector3.one);

        Gizmos.DrawWireCube(Vector3.zero, _boxCastSize);
    }
}
