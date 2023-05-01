using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    [SerializeField] private DialogueManager manager;

    public void TriggerDialogue()
    {
        manager.StartDialogue(dialogue, 0);
    }
}
