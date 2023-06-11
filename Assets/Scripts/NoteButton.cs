using UnityEngine;
using UnityEngine.UI;

public class NoteButton : MonoBehaviour
{
    [SerializeField] private GameObject _ui;
    [SerializeField] private GameObject _notes;
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Sprite _unreadSprite;
    [SerializeField] private Image _image;
    private bool _noteIsOpen = false;
    public static bool activeWindowTasks = false;

    public void Start()
    {
        _image = GetComponent<Image>();
    }

    public void changeSprite()
    {
        bool unreadNotes = ProgressManager.Instance.notesUnread;
        bool unreadTasks = ProgressManager.Instance.tasksUnread;

        ProgressManager.Instance.unread = unreadNotes || unreadTasks ? true : false;
        _image.sprite = ProgressManager.Instance.unread ? _unreadSprite : _defaultSprite;
    }
    public void openHideNotes()
    {
        if (!_noteIsOpen && activeWindowTasks) 
        {
            ProgressManager.Instance.tasksUnread = false;
            changeSprite();
        }
        else if (!_noteIsOpen && !activeWindowTasks)
        {
            ProgressManager.Instance.notesUnread = false;
            changeSprite();
        }

        _notes.SetActive(!_noteIsOpen);
        _ui.SetActive(_noteIsOpen);
        _noteIsOpen = !_noteIsOpen;
    }
}
