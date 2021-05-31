using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextNavigator : MonoBehaviour
{
    [SerializeField] Text[] dialogueTexts;
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
        if (idx >= dialogueTexts.Length) { return; }

        foreach (Text text in dialogueTexts)
        {
            text.gameObject.SetActive(false);
        }

        dialogueTexts[idx].gameObject.SetActive(true);
    }
}
