using System.Diagnostics;

[System.Serializable]
public class GameData
{
    public int indexScene;
    public int activeQuest;
    public int notesFilling;

    public GameData()
    {
        indexScene = -1;
        activeQuest = -1;
    }
}
