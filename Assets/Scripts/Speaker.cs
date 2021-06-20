using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour
{
    [SerializeField] Canvas dialogueCanvas = null;
    [SerializeField] Player target = null;
    [SerializeField] float talkingRange = 3.0f;

    private float distanceToTarget;

    void Start()
    {
        dialogueCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistanceToTarget();
    }

    private void CheckDistanceToTarget()
    {
        distanceToTarget = Mathf.Abs(target.transform.position.x - transform.position.x);

        if (distanceToTarget <= talkingRange)
        {
            target.SetDialogueMode(true);
            dialogueCanvas.gameObject.SetActive(true);
        }
    }
}
