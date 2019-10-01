using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemySpawner;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 yLock = new Vector3(gameObject.transform.position.x, 0.3f, gameObject.transform.position.z);
        Instantiate(enemySpawner, yLock, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
