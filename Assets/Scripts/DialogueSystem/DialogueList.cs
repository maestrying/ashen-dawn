using UnityEngine;

public class DialogueList : MonoBehaviour
{
    public NPCDialogues NPC;
    [SerializeField] private DialogueManager _dialogueManager;

    private void Start()
    {
        _dialogueManager = FindFirstObjectByType<DialogueManager>();
    }
    public void StartDialogue()
    {
        int id = GetComponent<NPCScript>().getDialogueId();

        _dialogueManager.StartDialogue(NPC, id);
    }
}
