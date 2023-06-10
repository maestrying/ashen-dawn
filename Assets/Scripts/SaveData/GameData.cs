using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public int indexScene;
    public List<Quest> Quests;
    public List<string> notes;
    public List<string> activeTasks;
    public bool notesUnread;
    public bool tasksUnread;
    public bool unread;
    public GameData()
    {
        indexScene = -1;
    }
}
