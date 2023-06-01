[System.Serializable]
public class Quest
{
    public enum state
    {
        Inactive,
        InProgress,
        Completed
    }

    public int npcId;
    public int questId;
    
    public state questState;
}
