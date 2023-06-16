using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public int indexScene;
    public ProgressManager.LightState lightState;
    public bool flashlight;
    public bool spatula;
    public List<Quest> Quests;
    public List<string> notes;
    public List<string> activeTasks;
    public List<string> completedTasks;
    public bool notesUnread;
    public bool tasksUnread;
    public bool unread;
    public GameData()
    {
        indexScene = -1;
    }
}
