using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour
{
    [SerializeField] Canvas dialogueCanvas = null;
    [SerializeField] Player target = null;
    [SerializeField] float talkingRange = 3.0f;
    [SerializeField] float verticalWindow = 1.0f;

    private float distanceToTarget;
    private float verticalOffset;

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
        verticalOffset = Mathf.Abs(target.transform.position.y - transform.position.y);

        if (distanceToTarget <= talkingRange && verticalOffset <= verticalWindow)
        {
            target.SetDialogueMode(true);
            dialogueCanvas.gameObject.SetActive(true);
        }
    }
}
