using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance { get; private set; }

    public List<Quest> Quests;
    public PlayerData playerData;
    public GameData gameData;
    [SerializeField] private Notes _notes;
    [SerializeField] private GameObject character;
    [SerializeField] private SaveManager saveManager;

    // NOTES VARIABLES
    public List<string> notes;
    public List<string> activeTasks;
    public bool notesUnread = false;
    public bool tasksUnread = false;
    public bool unread = false;

    // PHONE STATUS
    public bool isCalling = false;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadResourses();
        }
        else
        {
            Instance.LoadResourses();
            Destroy(gameObject);
        }  
    }
    public void Start()
    {
        if (SaveManager.isLoading)
        {
            gameData = saveManager.LoadGameData();
            Quests = gameData.Quests;
            notes = gameData.notes;
            unread = gameData.unread;
            activeTasks = gameData.activeTasks;
            notesUnread = gameData.notesUnread;
            tasksUnread = gameData.tasksUnread;
            Debug.Log(_notes);
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
        gameData.notesUnread = notesUnread;
        gameData.tasksUnread = tasksUnread;
        gameData.unread = unread;

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
        _notes = (Notes)FindObjectOfType(typeof(Notes), true);
        saveManager = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SaveManager>();
        character = GameObject.FindGameObjectWithTag("Character");
        
        if (!SaveManager.isLoading) _notes.loadNotes();
    }

}
