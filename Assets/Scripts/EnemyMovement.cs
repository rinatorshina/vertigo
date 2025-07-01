using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform endPoint;
    [SerializeField] private float speed = 1.0f;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPoint.position, speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }


}
