using UnityEngine;

public class vnGameManager : MonoBehaviour
{
    [Space]
    public DialogueTrigger TriggerConvo1;
    public DialogueTrigger TriggerConvo2;
    public DialogueTrigger TriggerConvo3;
    public DialogueTrigger TriggerConvo4;
    public DialogueTrigger TriggerConvo5;
    public DialogueTrigger TriggerConvo6;
    [Space]
    public bool Convo1Done = false;
    public bool Convo2Done = false;
    public bool Convo3Done = false;
    public bool Convo4Done = false;
    public bool Convo5Done = false;
    public bool Convo6Done = false;
    [Space]

    public GameObject[] Convo1ObjectsToEnable;
    public GameObject[] Convo1ObjectsToDisable;
    [Space]

    public GameObject[] Convo2ObjectsToEnable;
    public GameObject[] Convo2ObjectsToDisable;
    [Space]

    public GameObject[] Convo3ObjectsToEnable;
    public GameObject[] Convo3ObjectsToDisable;
    [Space]

    public GameObject[] Convo4ObjectsToEnable;
    public GameObject[] Convo4ObjectsToDisable;
    [Space]

    public GameObject[] Convo5ObjectsToEnable;
    public GameObject[] Convo5ObjectsToDisable;
    [Space]
    public GameObject[] Convo6ObjectsToEnable;
    public GameObject[] Convo6ObjectsToDisable;
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
        if (Convo1Done)
        {
            EnableDisableObjects(Convo1ObjectsToEnable, Convo1ObjectsToDisable);
        }

        if (Convo2Done)
        {
            EnableDisableObjects(Convo2ObjectsToEnable, Convo2ObjectsToDisable);
        }

        if (Convo3Done)
        {
            EnableDisableObjects(Convo3ObjectsToEnable, Convo3ObjectsToDisable);
        }

        if (Convo4Done)
        {
            EnableDisableObjects(Convo4ObjectsToEnable, Convo4ObjectsToDisable);
        }

        if (Convo5Done)
        {
            EnableDisableObjects(Convo5ObjectsToEnable, Convo5ObjectsToDisable);
        }

        if (Convo6Done)
        {
            EnableDisableObjects(Convo6ObjectsToEnable, Convo6ObjectsToDisable);
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

    public void convo1Interaction()
    {
        if (!Convo1Done)
        {
            TriggerConvo1.SetTriggerEnabled(true);
            TriggerConvo1.StartDialogue();
        }
    }

    public void convo2Interaction()
    {
        if (!Convo2Done)
        {
            TriggerConvo2.SetTriggerEnabled(true);
            TriggerConvo2.StartDialogue();
        }
    }

    public void convo3Interaction()
    {
        if (!Convo3Done)
        {
            TriggerConvo3.SetTriggerEnabled(true);
            TriggerConvo3.StartDialogue();
        }
    }

    public void convo4Interaction()
    {
        if (!Convo4Done)
        {
            TriggerConvo4.SetTriggerEnabled(true);
            TriggerConvo4.StartDialogue();
        }
    }

    public void convo5Interaction()
    {
        if (!Convo5Done)
        {
            TriggerConvo5.SetTriggerEnabled(true);
            TriggerConvo5.StartDialogue();
        }
    }

    public void convo6Interaction()
    {
        if (!Convo6Done)
        {
            TriggerConvo6.SetTriggerEnabled(true);
            TriggerConvo6.StartDialogue();
        }
    }

    private void OnDialogueCompleted()
    {
        Debug.Log("Dialogue completed event triggered");

        if (!Convo1Done && TriggerConvo1.HasCompletedDialogue())
        {
            Convo1Done = true;
        }


        if (!Convo2Done && TriggerConvo2.HasCompletedDialogue())
        {
            Convo2Done = true;
        }


        if (!Convo3Done && TriggerConvo3.HasCompletedDialogue())
        {
            Convo3Done = true;
        }


        if (!Convo4Done && TriggerConvo4.HasCompletedDialogue())
        {
            Convo4Done = true;
        }

        if (!Convo5Done && TriggerConvo5.HasCompletedDialogue())
        {
            Convo5Done = true;
        }


        if (!Convo6Done && TriggerConvo6.HasCompletedDialogue())
        {
            Convo6Done = true;
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
