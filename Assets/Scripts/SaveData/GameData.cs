using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public int indexScene;
    public List<Quest> Quests;
    public List<string> notes;
    public List<string> activeTasks;
    public GameData()
    {
        indexScene = -1;
    }
}
