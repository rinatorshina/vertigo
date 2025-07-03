using UnityEngine;

public class EnemyRandomiser : MonoBehaviour
{
    [SerializeField] private GameObject[] EnemyModels; 


    void Start()
    {
        foreach (GameObject model in EnemyModels)
        { 
            model.SetActive(false);
        }

        int enemyRandom = Random.Range(0, EnemyModels.Length);
        EnemyModels[enemyRandom].SetActive(true);

    }

    
}
