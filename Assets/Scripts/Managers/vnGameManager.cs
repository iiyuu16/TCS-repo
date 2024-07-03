using UnityEngine;

public class vnGameManager : MonoBehaviour
{
    [Space]
    public DialogueTrigger baseTrigger;
    public DialogueTrigger shopTrigger;
    public DialogueTrigger hubTrigger;
    [Space]
    public bool baseConvoDone = false;
    public bool shopConvoDone = false;
    public bool hubConvoDone = false;
    [Space]

    public GameObject[] baseObjectsToEnable;
    public GameObject[] baseObjectsToDisable;
    [Space]

    public GameObject[] shopObjectsToEnable;
    public GameObject[] shopObjectsToDisable;
    [Space]

    public GameObject[] hubObjectsToEnable;
    public GameObject[] hubObjectsToDisable;
    [Space]

    private DialogueManager dialogueManager;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueManager.OnDialogueCompleted += OnDialogueCompleted;
    }

    void Update()
    {
        UpdateObjectives();
        OnDialogueCompleted();
    }

    void UpdateObjectives()
    {
        if (baseConvoDone)
        {
            EnableDisableObjects(baseObjectsToEnable, baseObjectsToDisable);
        }

        if (shopConvoDone)
        {
            EnableDisableObjects(shopObjectsToEnable, shopObjectsToDisable);
        }

        if (hubConvoDone)
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
        if (!shopConvoDone)
        {
            shopTrigger.SetTriggerEnabled(true);
            shopTrigger.StartDialogue();
        }
    }

    public void hubInteraction()
    {
        if (!hubConvoDone)
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
        else
        {
            Debug.Log("base convo already done");
        }

        if (!shopConvoDone && shopTrigger.HasCompletedDialogue())
        {
            shopConvoDone = true;
            Debug.Log("shop convo done");
        }
        else
        {
            Debug.Log("shop convo already done");
        }

        if (!hubConvoDone && hubTrigger.HasCompletedDialogue())
        {
            hubConvoDone = true;
            Debug.Log("hub convo done");
        }
        else
        {
            Debug.Log("hub convo already done");
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
