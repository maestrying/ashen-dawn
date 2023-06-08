[System.Serializable]
public class Dialogue
{
    public bool isQuestDialogue;
    public int questId;
    public bool isMonologue;
    public string[] sentences;
}

[System.Serializable]
public class NPCDialogues
{
    public Dialogue[] dialogues;
}
