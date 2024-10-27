using UnityEngine;

public class CapsuleCastAll : MonoBehaviour
{

    [SerializeField] private float _height = 1f;
    [SerializeField] private float _radius = 0.5f;
    [SerializeField] private float _maxDistance = 10f;

    [SerializeField] private Transform _capsuleVisual;
    [SerializeField] private Vector3 _castOrientation = Vector3.zero;

    [SerializeField] private LayerMask _hitLayer;
    [SerializeField] private QueryTriggerInteraction _triggerInteraction;

    private void OnDrawGizmos()
    {
        Vector3 direction = -transform.up;

        Quaternion rotation = Quaternion.Euler(_castOrientation);

        Vector3 point1 = transform.position + rotation * (-direction * (_height / 2));
        Vector3 point2 = transform.position + rotation * (direction * (_height / 2));

        RaycastHit[] raycastHits = Physics.CapsuleCastAll(point1, point2, _radius, direction, _maxDistance, _hitLayer, _triggerInteraction);

        for (int i = 0; i < raycastHits.Length; i++)
        {
            Gizmos.DrawWireSphere(raycastHits[i].point, 0.2f);
        }
    }
}
