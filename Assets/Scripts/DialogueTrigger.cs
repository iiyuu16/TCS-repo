using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;

    public void StartDialogue()
    {
        // Disable the button
        Button dialogueButton = GetComponentInChildren<Button>();
        if (dialogueButton != null)
        {
            dialogueButton.interactable = false;
            gameObject.SetActive(false);
        }

        // Start the dialogue
        FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors);
    }
}

[System.Serializable]
public class Message
{
    public int actorID;
    public string message;
}

[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}
