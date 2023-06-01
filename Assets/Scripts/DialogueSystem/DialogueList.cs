using UnityEngine;

public class DialogueList : MonoBehaviour
{
    public NPCDialogues NPC;
    [SerializeField] private DialogueManager _dialogueManager;

    public void StartDialogue()
    {
        _dialogueManager.StartDialogue(NPC, 0);
    }
}
