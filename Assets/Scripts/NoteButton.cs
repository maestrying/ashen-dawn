using UnityEngine;

public class NoteButton : MonoBehaviour
{
    [SerializeField] private GameObject _ui;
    [SerializeField] private GameObject _notes;
    private bool _noteIsOpen = false;

    public void openHideNotes()
    {
        _notes.SetActive(!_noteIsOpen);
        _ui.SetActive(_noteIsOpen);
        _noteIsOpen = !_noteIsOpen;
    }
}
