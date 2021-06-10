using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10f;

    public float lifeTime = 3f;

    private float direction;
    

    // Start is called before the first frame update
    void Start()
    {
        // match bullet orientation with direciton player is facing
        direction = FindObjectOfType<Player>().transform.localScale.x;
        transform.localScale = new Vector2(Mathf.Sign(direction), 1f);

        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * direction * bulletSpeed * Time.deltaTime);
    }
}
