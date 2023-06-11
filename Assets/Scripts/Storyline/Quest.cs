[System.Serializable]
public class Quest
{
    public enum state
    {
        InProgress,
        BackToComplete,
        Completed
    }

    public int npcId;
    public int questId;
    public string name;
    public state questState;
}
