using UnityEngine;

public class BoxcastAll : MonoBehaviour
{

    [SerializeField] private Vector3 _boxCastSize = new Vector3(0.2f, 0.2f, 0.2f);
    [SerializeField] private float _maxDistance = 10f;

    [SerializeField] private LayerMask _hitLayer;
    [SerializeField] private QueryTriggerInteraction _triggerInteraction;

    private void OnDrawGizmos()
    {
        Vector3 direction = -transform.up;

        RaycastHit[] raycastHits = Physics.BoxCastAll(transform.position, _boxCastSize / 2, direction, transform.rotation, _maxDistance, _hitLayer, _triggerInteraction);

        for (int i = 0; i < raycastHits.Length; i++)
        {
            Gizmos.DrawWireSphere(raycastHits[i].point, 0.2f);
        }

        Gizmos.matrix = Matrix4x4.TRS(transform.position + direction * raycastHits[raycastHits.Length - 1].distance, transform.rotation, Vector3.one);

        Gizmos.DrawWireCube(Vector3.zero, _boxCastSize);
    }
}
