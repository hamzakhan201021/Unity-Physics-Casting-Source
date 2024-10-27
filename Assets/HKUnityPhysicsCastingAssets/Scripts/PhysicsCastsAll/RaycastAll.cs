using UnityEngine;

public class RaycastAll : MonoBehaviour
{

    [SerializeField] private float _maxDistance;

    [SerializeField] private LayerMask _layerToHit;
    [SerializeField] private QueryTriggerInteraction _triggerInteraction;

    [SerializeField] private Transform _alignObject;

    private void OnDrawGizmos()
    {
        Vector3 direction = -transform.up;

        RaycastHit[] rayhits = Physics.RaycastAll(transform.position, direction, _maxDistance, _layerToHit, _triggerInteraction);

        if (rayhits.Length > 0) Gizmos.DrawLine(transform.position, transform.position + direction * rayhits[rayhits.Length - 1].distance);
        else Gizmos.DrawLine(transform.position, transform.position + direction * _maxDistance);

        if (_alignObject != null)
        {
            _alignObject.position = rayhits[rayhits.Length - 1].point;
            _alignObject.rotation = Quaternion.FromToRotation(-direction, rayhits[rayhits.Length - 1].normal);
        }

        for (int i = 0; i < rayhits.Length; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(rayhits[i].point, 0.2f);
        }
    }
}
