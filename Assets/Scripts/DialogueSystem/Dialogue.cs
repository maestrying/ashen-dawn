using System.Collections.Generic;

[System.Serializable]
public class Sentences
{
    public int id;
    public string[] sentences;
}

[System.Serializable]
public class Dialogue
{
    public string name;
    public Sentences[] sentences;
}
