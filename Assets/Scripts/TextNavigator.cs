using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextNavigator : MonoBehaviour
{
    [SerializeField] Text[] dialogueTexts = null;
    [SerializeField] bool preMissionDialogue = true;
    [SerializeField] bool inMissionDialogue = false;
    [SerializeField] bool endMissionDialogue = false;

    private Text dialogueText;
    private int dialogueTextIdx;

    // Start is called before the first frame update
    void Start()
    {
        dialogueTextIdx = 0;
        SetActiveText(dialogueTextIdx);
        dialogueText = dialogueTexts[dialogueTextIdx];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextText()
    {
        dialogueTextIdx += 1;
        SetActiveText(dialogueTextIdx);
    }

    private void SetActiveText(int idx)
    {
        if (idx >= dialogueTexts.Length) 
        {
            HandleEndDialogue();
            return; 
        }

        foreach (Text text in dialogueTexts)
        {
            text.gameObject.SetActive(false);
        }

        dialogueTexts[idx].gameObject.SetActive(true);
    }

    private void HandleEndDialogue()
    {
        if (preMissionDialogue)
        {
            FindObjectOfType<SceneLoader>().NextScene();
        }

        else if (inMissionDialogue)
        {
            // TODO: handle this
            return;
        }

        else if (endMissionDialogue)
        {
            Debug.Log("Mission Complete!");
        }
        
    }
}
