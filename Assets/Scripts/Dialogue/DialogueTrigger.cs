using UnityEngine;
using UnityEngine.UI;
public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;

    public DialogueTrigger previousDialogueTrigger;

    private bool isTriggerEnabled = true;
    private DialogueManager dialogueManager;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void StartDialogue()
    {
        if (!isTriggerEnabled)
        {
            Debug.Log("Dialogue trigger is disabled.");
            return;
        }

        if (previousDialogueTrigger != null && !previousDialogueTrigger.HasCompletedDialogue())
        {
            Debug.Log("Cannot start dialogue. Previous dialogue not completed.");
            return;
        }

        Button dialogueButton = GetComponentInChildren<Button>();
        if (dialogueButton != null)
        {
            dialogueButton.interactable = false;
            gameObject.SetActive(false);
            Debug.Log("Dialogue State: " + HasCompletedDialogue());
        }

        dialogueManager.OpenDialogue(messages, actors);
    }

    public bool HasCompletedDialogue()
    {
        return dialogueManager.DialogueCompleted;
    }

    public void SetTriggerEnabled(bool isEnabled)
    {
        isTriggerEnabled = isEnabled;
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
