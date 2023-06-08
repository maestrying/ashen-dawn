using UnityEngine;
using UnityEngine.UI;

public class TriggerScript : MonoBehaviour
{
    public enum type
    {
        MusicObject,
        Dialogue,
        Inspect
    }

    private Animator _anim;
    [SerializeField] private type _triggerType;

    public void Start()
    {
        _anim = GameObject.FindGameObjectWithTag("ActionButton").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Character"))
        {
            ActionButton.actionType = _triggerType.ToString();

            if (_triggerType == type.Dialogue)
            {
                FindFirstObjectByType<DialogueManager>().npcScript = GetComponent<NPCScript>();
                ActionButton.dialogueList = GetComponent<DialogueList>();
            }


            FindObjectOfType<ActionButton>().setTextureButton();
            _anim.SetTrigger("IsTriggered");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Character"))
        {
            if (FindFirstObjectByType<DialogueManager>() != null) FindFirstObjectByType<DialogueManager>().npcScript = null;
            _anim.SetTrigger("IsTriggered");
        }
    }
}
