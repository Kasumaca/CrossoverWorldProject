using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject testDialogue;

    public bool IsOpen { get; private set; }

    private ResponseHandler responseHandler;
    private TypewritterEffect typewritterEffect;

    private void Start()
    {
        typewritterEffect = GetComponent<TypewritterEffect>();
        responseHandler = GetComponent<ResponseHandler>();
        CloseDialogue();
    }
    public void ShowDialogue(DialogueObject dialogueObject)
    {
        IsOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }
    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {

        for(int i =0;i<dialogueObject.Dialogue.Length;i++ )
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return typewritterEffect.Run(dialogue, textLabel);

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses) break;

            
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        }
        if (dialogueObject.HasResponses)
        {
            responseHandler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            CloseDialogue();
        }
        
    }

    private void CloseDialogue()
    {
        IsOpen = false;
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
