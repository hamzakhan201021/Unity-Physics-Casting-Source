using UnityEngine;

public class CapsuleCastNonAlloc : MonoBehaviour
{

    [SerializeField] private float _height = 1f;
    [SerializeField] private float _radius = 0.5f;
    [SerializeField] private float _maxDistance = 10f;

    [SerializeField] private Transform _capsuleVisual;
    [SerializeField] private Vector3 _castOrientation = Vector3.zero;

    [SerializeField] private LayerMask _hitLayer;
    [SerializeField] private QueryTriggerInteraction _triggerInteraction;

    private RaycastHit[] raycastHits = new RaycastHit[10];

    private void OnDrawGizmos()
    {
        Vector3 direction = -transform.up;

        Quaternion rotation = Quaternion.Euler(_castOrientation);

        Vector3 point1 = transform.position + rotation * (-direction * (_height / 2));
        Vector3 point2 = transform.position + rotation * (direction * (_height / 2));

        Physics.CapsuleCastNonAlloc(point1, point2, _radius, direction, raycastHits, _maxDistance, _hitLayer, _triggerInteraction);

        for (int i = 0; i < raycastHits.Length; i++)
        {
            Gizmos.DrawWireSphere(raycastHits[i].point, 0.2f);
        }

        if (_capsuleVisual != null)
        {
            _capsuleVisual.position = transform.position + direction * Mathf.Min(raycastHits[raycastHits.Length - 1].distance, _maxDistance);

            _capsuleVisual.rotation = rotation;

            Vector3 scale = Vector3.one;
            scale.x = _radius * 2;
            scale.y = _height;
            scale.z = _radius * 2;

            _capsuleVisual.localScale = scale;
        }
    }
}
