using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10f;
    

    public float lifeTime = 3f;

    private float direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = FindObjectOfType<EnemyMovement>().direction;
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        // multiply by -direction because enemies oriented front side left
        transform.Translate(Vector2.right * -direction * bulletSpeed * Time.deltaTime);
    }
}
