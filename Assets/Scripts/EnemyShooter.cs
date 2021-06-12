using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] float range = 3f;
    [SerializeField] EnemyBullet bullet = null;
    [SerializeField] Transform shootPoint = null;

    private float epsilon = 0.1f;
    
    private Player target;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Player>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AimAtTarget();
    }

    private float GetHorizontalDistanceToTarget()
    {
        return Mathf.Abs(transform.position.x - target.transform.position.x);
    }

    private float GetVerticalDistanceToTarget()
    {
        return Mathf.Abs(transform.position.y - target.transform.position.y);
    }

    private bool InRange()
    {
        if (GetHorizontalDistanceToTarget() <= range && GetVerticalDistanceToTarget() <= epsilon) { return true; }

        else{ return false; }
    }

    private bool FacingTarget()
    {
        // P--> <--E
        if (target.transform.localScale.x == 1 &&
            transform.localScale.x == 1 &&
            target.transform.position.x < transform.position.x) { return true; }

        // <--P <--E
        else if (target.transform.localScale.x == -1 &&
                 transform.localScale.x == 1 &&
                 target.transform.position.x < transform.position.x) { return true; }

        // E--> P-->
        else if (target.transform.localScale.x == 1 &&
                 transform.localScale.x == -1 &&
                 target.transform.position.x > transform.position.x) { return true; }

        // E--> <--P
        else if (target.transform.localScale.x == -1 &&
                 transform.localScale.x == -1 &&
                 target.transform.position.x > transform.position.x) { return true; }

        else { return false; }
    }

    private void AimAtTarget()
    {
        if (InRange() && FacingTarget())
        {
            animator.SetBool("shooting", true);

        }

        else
        {
            animator.SetBool("shooting", false);
        }
    }

    public void FireAtTarget()
    {
        EnemyBullet newBullet = Instantiate(bullet, shootPoint.position, Quaternion.identity) as EnemyBullet;
    }
}
