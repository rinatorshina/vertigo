using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public Transform endPoint;
    [SerializeField] private float startSpeed = 1.0f;
    [Tooltip("Increase number to reduce speed up")] [SerializeField] private float minSpeedFactor = 10f;
    [Tooltip("Increase number to reduce speed up")][SerializeField] private float maxSpeedFactor = 20f;

    private float currentSpeed;
    private float speedFactor;

    private void Start()
    {
        currentSpeed = startSpeed;
        speedFactor = Random.Range(minSpeedFactor, maxSpeedFactor);
    }

    private void Update()
    {
        // TODO: increase currentSpeed over time
        // currentSpeed = currentSpeed + Time.deltaTime;
        currentSpeed += Time.deltaTime / speedFactor;

        transform.position = Vector3.MoveTowards(transform.position, endPoint.position, currentSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            SceneManager.LoadScene("DeathScreen", LoadSceneMode.Single);
            ScoreManager.Instance.score = 0;
        }
    }


}
