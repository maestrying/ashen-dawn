[System.Serializable]
public class Dialogue
{
    public bool isQuestDialogue;
    public bool isMonologue;
    public string[] sentences;
}

[System.Serializable]
public class NPCDialogues
{
    public int id;
    public Dialogue[] dialogues;
}
