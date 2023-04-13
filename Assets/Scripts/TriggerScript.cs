using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TriggerScript : MonoBehaviour
{
    public enum type
    {
        ChangeScene,
        MusicObject,
        Dialogue,
        GetItem
    }

    private GameObject _actionButton;
    private Animator _anim;
    private ActionButton _script;
    [SerializeField] private type _triggerType;
    [SerializeField] private int indexNextScene;
    public Vector3 nextPosition;

    public void Start()
    {
        _actionButton = GameObject.FindWithTag("ActionButton");
        _anim = _actionButton.GetComponent<Animator>();
        _script = _actionButton.GetComponent<ActionButton>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Character"))
        {
            ActionButton.actionType = _triggerType.ToString();
            _script.setTextureButton();
            _anim.SetTrigger("IsTriggered");

            if (_triggerType == type.ChangeScene)
            {
                SceneChanger.indexScene = indexNextScene;
                SceneChanger.position = nextPosition;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Character"))
        {
            _anim.SetTrigger("IsTriggered");
        }
    }
}
