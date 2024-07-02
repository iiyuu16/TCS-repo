using UnityEngine;

public class vnGameManager : MonoBehaviour
{
    public DialogueTrigger baseTrigger;
    public DialogueTrigger shopTrigger;
    public DialogueTrigger hubTrigger;

    public bool baseConvoDone = false;
    public bool shopConvoDone = false;
    public bool hubConvoDone = false;

    public GameObject[] baseObjectsToEnable;
    public GameObject[] baseObjectsToDisable;

    public GameObject[] shopObjectsToEnable;
    public GameObject[] shopObjectsToDisable;

    public GameObject[] hubObjectsToEnable;
    public GameObject[] hubObjectsToDisable;

    private DialogueManager dialogueManager;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueManager.OnDialogueCompleted += OnDialogueCompleted;
    }

    void Update()
    {
        UpdateObjectives();
    }

    void UpdateObjectives()
    {
        if (baseConvoDone)
        {
            EnableDisableObjects(baseObjectsToEnable, baseObjectsToDisable);
        }

        if (shopConvoDone && baseConvoDone)
        {
            EnableDisableObjects(shopObjectsToEnable, shopObjectsToDisable);
        }

        if (hubConvoDone && shopConvoDone && baseConvoDone)
        {
            EnableDisableObjects(hubObjectsToEnable, hubObjectsToDisable);
        }
    }

    void EnableDisableObjects(GameObject[] objectsToEnable, GameObject[] objectsToDisable)
    {
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(true);
        }

        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(false);
        }
    }

    public void baseInteraction()
    {
        if (!baseConvoDone)
        {
            baseTrigger.SetTriggerEnabled(true);
            baseTrigger.StartDialogue();
        }
    }

    public void shopInteraction()
    {
        if (!shopConvoDone && baseConvoDone)
        {
            shopTrigger.SetTriggerEnabled(true);
            shopTrigger.StartDialogue();
        }
    }

    public void hubInteraction()
    {
        if (!hubConvoDone && shopConvoDone && baseConvoDone)
        {
            hubTrigger.SetTriggerEnabled(true);
            hubTrigger.StartDialogue();
        }
    }

    private void OnDialogueCompleted()
    {
        Debug.Log("Dialogue completed event triggered");

        if (!baseConvoDone && baseTrigger.HasCompletedDialogue())
        {
            baseConvoDone = true;
            Debug.Log("base convo done");
        }
        else if (!shopConvoDone && shopTrigger.HasCompletedDialogue())
        {
            shopConvoDone = true;
            Debug.Log("shop convo done");
        }
        else if (!hubConvoDone && hubTrigger.HasCompletedDialogue())
        {
            hubConvoDone = true;
            Debug.Log("hub convo done");
        }
    }

    void OnDestroy()
    {
        if (dialogueManager != null)
        {
            dialogueManager.OnDialogueCompleted -= OnDialogueCompleted;
        }
    }
}
