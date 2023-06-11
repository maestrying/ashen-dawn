using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notes : MonoBehaviour
{
    public List<string> notes;

    [SerializeField] private NoteButton _noteButton;
    [SerializeField] private GameObject _noteSide;
    [SerializeField] private GameObject _questSide;

    [SerializeField] private Text leftPageText;
    [SerializeField] private Text rightPageText;

    private int leftIndex = 0, rightIndex = 1;
    private const int notesOffset = 2;

    [SerializeField] private Text taskPrefab;
    [SerializeField] private Transform activeTaskListContainer;
    [SerializeField] private Transform completedTaskListContainer;

    public static List<string> activeTasks = new List<string>();
    public static List<string> completedTasks = new List<string>();

    public void setNotesUnread()
    {
        ProgressManager.Instance.notesUnread = true;
        _noteButton.changeSprite();
    }

    public void setTasksUnread()
    {
        ProgressManager.Instance.tasksUnread = true;
        _noteButton.changeSprite();
    }

    public void addNote(string note)
    {
        notes.Add(note);
    }

    public void updateNotesUI()
    {
        if (leftIndex >= 0 && leftIndex < notes.Count)
        {
            leftPageText.text = notes[leftIndex];
        }
        else
        {
            leftPageText.text = "";
        }

        if (rightIndex >= 0 && rightIndex < notes.Count)
        {
            rightPageText.text = notes[rightIndex] != null ? notes[rightIndex] : "";
        }
        else
        {
            rightPageText.text = "";
        }
    }

    public void prevNotePage()
    {
        if (leftIndex != 0)
        {
            leftIndex -= notesOffset;
            rightIndex -= notesOffset;

            updateNotesUI();
        }
    }

    public void nextNotePage()
    {
        if (rightIndex >= 0 && rightIndex < notes.Count)
        {
            leftIndex += notesOffset;
            rightIndex += notesOffset;

            updateNotesUI();
        }
    }

    public void updateTasks(List<Quest> quests)
    {
        foreach (Quest quest in quests)
        {
            if (quest.questState == Quest.state.InProgress && !activeTasks.Contains(quest.name)) 
            {
                activeTasks.Add(quest.name);
            }

            else if ((quest.questState == Quest.state.Completed || quest.questState == Quest.state.BackToComplete) && !completedTasks.Contains(quest.name))
            {
                if (activeTasks.Contains(quest.name)) activeTasks.Remove(quest.name);
                completedTasks.Add(quest.name);
            }
        }

        setTasksUnread();
        updateTasksUI();
        saveNotes();
    }

    private void updateTasksUI()
    {
        foreach (Transform task in activeTaskListContainer)
        {
            Destroy(task.gameObject);
        }

        foreach (string task in activeTasks)
        {
            Text taskText = Instantiate(taskPrefab, activeTaskListContainer);
            taskText.text = task;
        }

        foreach (Transform task in completedTaskListContainer)
        {
            Destroy(task.gameObject);
        }

        foreach (string task in completedTasks)
        {
            Text taskText = Instantiate(taskPrefab, completedTaskListContainer);
            taskText.text = task;
        }
    }

    public void openNoteSide()
    {
        NoteButton.activeWindowTasks = false;
        ProgressManager.Instance.notesUnread = false;
        _noteButton.changeSprite();

        _questSide.SetActive(false);
        _noteSide.SetActive(true);
    }

    public void openQuestSide()
    {
        NoteButton.activeWindowTasks = true;
        ProgressManager.Instance.tasksUnread = false;
        _noteButton.changeSprite();
        _noteSide.SetActive(false);
        _questSide.SetActive(true);
    }

    public void saveNotes()
    {
        ProgressManager.Instance.notes = notes;
        ProgressManager.Instance.activeTasks = activeTasks;
        ProgressManager.Instance.completedTasks = completedTasks;
    }

    public void loadNotes()
    {
        if (ProgressManager.Instance.activeTasks != null)
        {
            activeTasks = ProgressManager.Instance.activeTasks;
        }

        if (ProgressManager.Instance.completedTasks != null)
        {
            completedTasks = ProgressManager.Instance.completedTasks;
        }

        if (ProgressManager.Instance.notes != null)
        {
            notes = ProgressManager.Instance.notes;
        }
       
        updateNotesUI();
        updateTasksUI();
        _noteButton.changeSprite();

        Debug.Log("notes loaded");
    }
}