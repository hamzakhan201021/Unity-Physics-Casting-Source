using UnityEngine;

public class SphereCastAll : MonoBehaviour
{

    [SerializeField] private float radius = 0.5f;
    [SerializeField] private float maxDistance = 10f;

    [SerializeField] private LayerMask hitLayer;
    [SerializeField] private QueryTriggerInteraction triggerInteraction;

    private void OnDrawGizmos()
    {
        Vector3 direction = -transform.up;

        RaycastHit[] raycastHits = Physics.SphereCastAll(transform.position, radius, direction, maxDistance, hitLayer, triggerInteraction);

        Debug.Log(raycastHits[raycastHits.Length - 1].transform.name);

        Gizmos.color = Color.cyan;

        for (int i = 0; i < raycastHits.Length; i++)
        {
            Gizmos.DrawWireSphere(raycastHits[i].point, 0.3f);
        }
    }
}
