using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Bullet bullet = null;
    [SerializeField] Transform shootPoint = null;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        float direciton = GetComponent<Player>().transform.localScale.x;

        //if (bullet == null)
        //{
            Bullet newBullet = Instantiate(bullet, shootPoint.position, Quaternion.identity) as Bullet;
        //}
        
    }

    
}
