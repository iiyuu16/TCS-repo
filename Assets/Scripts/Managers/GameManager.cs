using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DialogueTrigger baseTrigger;
    public DialogueTrigger shopTrigger;
    public DialogueTrigger hubTrigger;

    public GameObject blockerPlaceholder;


    private bool baseConvoDone = false;
    private bool shopConvoDone = false;
    private bool hubConvoDone = false;

    void Start()
    {
        baseInteraction();
    }

    public void baseInteraction()
    {
        blockerPlaceholder.SetActive(false);
        if (!baseConvoDone)
        {
            baseTrigger.SetTriggerEnabled(true);
            baseTrigger.StartDialogue();
            baseConvoDone = true;
        }
        else
            blockerPlaceholder.SetActive(true);
    }

    public void shopInteraction()
    {
        blockerPlaceholder.SetActive(false);
        if (!shopConvoDone && baseConvoDone)
        {
            shopTrigger.SetTriggerEnabled(true);
            shopTrigger.StartDialogue();
            shopConvoDone = true;
        }
        else
        {
            blockerPlaceholder.SetActive(true);
        }
    }

    public void hubInteraction()
    {
        blockerPlaceholder.SetActive(false);
        if (!hubConvoDone && shopConvoDone && baseConvoDone)
        {
            hubTrigger.SetTriggerEnabled(true);
            hubTrigger.StartDialogue();
            hubConvoDone = true;
        }
        else
        {
            blockerPlaceholder.SetActive(true);
        }
    }
}
