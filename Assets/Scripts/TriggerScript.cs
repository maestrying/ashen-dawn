using UnityEngine;
using UnityEngine.UI;

public class TriggerScript : MonoBehaviour
{
    public enum type
    {
        Action,
        MusicObject,
        Dialogue,
        Inspect
    }

    private Animator _anim;
    [SerializeField] private type _triggerType;
    [SerializeField] private int _inspectObjectId;

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

                if (GetComponent<NPCScript>().npc == NPCScript.NPC.Phone) 
                { 
                    ActionButton.isPhone = true;
                }
            }
            else if (_triggerType == type.Inspect)
            {
                ActionButton.inspectObjectId = _inspectObjectId;
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
            ActionButton.isPhone = false;
            _anim.SetTrigger("IsTriggered");
        }
    }
}
