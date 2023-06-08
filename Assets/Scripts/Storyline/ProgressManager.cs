using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance { get; private set; }

    public List<Quest> Quests;
    public List<GameObject> NPC;
    public PlayerData playerData;
    public GameData gameData;
    private Notes _notes;
    private GameObject character;
    private SaveManager saveManager;

    public List<string> notes;
    public List<string> activeTasks;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public void Start()
    {
        if (SaveManager.isLoading)
        {
            gameData = saveManager.LoadGameData();
            Quests = gameData.Quests;
            notes = gameData.notes;
            activeTasks = gameData.activeTasks;

            _notes.loadNotes();

            SaveManager.isLoading = false;
        }
        else
        {
            Quests = getGameData().Quests;

            updatePlayerData();
            updateGameData();
        }
    }

    public void updateGameData()
    {
        gameData.indexScene = SceneManager.GetActiveScene().buildIndex;
        gameData.Quests = Quests;
        gameData.activeTasks = activeTasks;
        gameData.notes = notes;
    }
    public void updatePlayerData()
    {
        playerData = character.GetComponent<Player>().getData();
    }

    public PlayerData getPlayerData()
    {
        updatePlayerData();
        return playerData;
    }

    public GameData getGameData()
    {
        updateGameData();
        return gameData;
    }

    public List<Quest> getActiveQuests()
    {
        List<Quest> activeQuests = new List<Quest>();

        foreach (Quest quest in Quests)
        {
            if (quest.questState == Quest.state.InProgress)
            {
                activeQuests.Add(quest);
            }
        }

        return activeQuests;
    }

    public void setActiveQuest(int npcId, int id)
    {
       foreach (Quest quest in Quests)
       {
            if (quest.npcId == npcId && quest.questId == id)
            {
                quest.questState = Quest.state.InProgress;
            }
       }
       _notes.updateTasks(Quests);
    }

    public void addQuest(Quest quest)
    {
        if (!Quests.Contains(quest))
        {
            Quests.Add(quest);
            _notes.updateTasks(Quests);
        }
    }

    public void completeQuest(int npcId, int id)
    {
        foreach (Quest quest in Quests)
        {
            if (quest.npcId == npcId && quest.questId == id)
            {
                quest.questState = Quest.state.Completed;
            }
        }

        _notes.updateTasks(Quests);
    }

    public void LoadResourses()
    {
        _notes = (Notes) FindObjectOfType(typeof(Notes), true);
        saveManager = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SaveManager>();
        character = GameObject.FindGameObjectWithTag("Character");
        
        if (!SaveManager.isLoading) _notes.loadNotes();
    }

}
