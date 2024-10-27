using UnityEngine;

public class Capsulecast : MonoBehaviour
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

        Physics.CapsuleCast(point1, point2, _radius, direction, out RaycastHit hitInfo, _maxDistance, _hitLayer, _triggerInteraction);

        if (_capsuleVisual != null)
        {
            _capsuleVisual.position = transform.position + direction * Mathf.Min(hitInfo.distance, _maxDistance);

            _capsuleVisual.rotation = rotation;

            Vector3 scale = Vector3.one;
            scale.x = _radius * 2;
            scale.y = _height;
            scale.z = _radius * 2;

            _capsuleVisual.localScale = scale;
        }
    }
}
