using UnityEngine;

public class Cannonball : MonoBehaviour
{
    private GameObject enemy;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 displacement = enemy.transform.position - transform.position;
        Vector3 velocity = displacement.normalized * speed * Time.deltaTime;
        transform.Translate(velocity,Space.World);
    }
}
