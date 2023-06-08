[System.Serializable]
public class Quest
{
    public enum state
    {
        InProgress,
        Completed
    }

    public int npcId;
    public int questId;
    public string name;
    public state questState;
}
