using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    [HideInInspector] public static string actionType;
    [SerializeField] private Sprite _musicTexture;
    [SerializeField] private Sprite _dialogueTexture;
    [SerializeField] private Sprite _inspectTexture;
    [SerializeField] private GameObject _inspectWindow;
    [SerializeField] private GameObject _dialogueWindow;
    [SerializeField] private AudioSource _audioSource;
    private AudioSource _radioEnableSound;
    private GameObject _ui;
    public static DialogueList dialogueList; 

    public void Start()
    {
        _ui = GameObject.FindWithTag("UI");
        _radioEnableSound = GetComponent<AudioSource>();
        GameObject.FindGameObjectWithTag("ExitButton").GetComponent<Animator>().keepAnimatorStateOnDisable = true;
    }

    public void setTextureButton()
    {
        switch (actionType)
        {
            case "MusicObject":
                GetComponent<Image>().sprite = _musicTexture;
                break;
            case "Dialogue":
                GetComponent<Image>().sprite = _dialogueTexture;
                break;
            case "Inspect":
                GetComponent<Image>().sprite = _inspectTexture;
                break;
        }
    }

    public void doAction()
    {
        switch (actionType)
        {
            case "MusicObject":
                _radioEnableSound.Play();
                Debug.Log(actionType);
                if (!_audioSource.isPlaying)
                {
                    _audioSource.Play();
                }
                else
                {
                    _audioSource.Stop();
                }
                break;

            case "Dialogue":
                _dialogueWindow.SetActive(true);
                dialogueList.StartDialogue();
                break;

            case "Inspect":
                _ui.SetActive(false);
                _inspectWindow.SetActive(true);
                Debug.Log(actionType);
                break;
        }
    }
}
