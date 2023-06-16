using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance { get; private set; }

    // PROGRESS MANAGER RESOURSES
    public List<Quest> Quests;
    public PlayerData playerData;
    public GameData gameData;
    [SerializeField] private Notes _notes;
    [SerializeField] private GameObject character;
    [SerializeField] private SaveManager saveManager;
    public PrefabLoader prefabLoader;

    // LIGHTING STATE
    public enum LightState
    {
        Day,
        Evening,
        Night
    }
    public new LightState light;

    // NOTES VARIABLES
    public List<string> notes;
    public List<string> activeTasks;
    public List<string> completedTasks;
    public bool notesUnread = false;
    public bool tasksUnread = false;
    public bool unread = false;

    public bool flashlight = false;
    public bool spatula = false;

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
            light = gameData.lightState;
            notes = gameData.notes;
            unread = gameData.unread;
            activeTasks = gameData.activeTasks;
            completedTasks = gameData.completedTasks;
            notesUnread = gameData.notesUnread;
            tasksUnread = gameData.tasksUnread;
            flashlight = gameData.flashlight;
            spatula = gameData.spatula;

            Debug.Log(_notes);
            _notes.loadNotes();

            prefabLoader = FindFirstObjectByType<PrefabLoader>();
            prefabLoader.LoadPrefabs();

            SaveManager.isLoading = false;
        }
        else
        {
            Quests = getGameData().Quests;

            updatePlayerData();
            updateGameData();
            _notes.updateTasks(Quests);
        }
    }

    public void updateGameData()
    {
        gameData.indexScene = SceneManager.GetActiveScene().buildIndex;
        gameData.Quests = Quests;
        gameData.lightState = light;
        gameData.activeTasks = activeTasks;
        gameData.completedTasks = completedTasks;
        gameData.notes = notes;
        gameData.notesUnread = notesUnread;
        gameData.tasksUnread = tasksUnread;
        gameData.unread = unread;
        gameData.flashlight = flashlight;
        gameData.spatula = spatula;

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
            if (quest.questState == Quest.state.InProgress) activeQuests.Add(quest);
        }

        return activeQuests;
    }

    public void setActiveQuest(int npcId, int id)
    {
       foreach (Quest quest in Quests)
       {
            if (quest.npcId == npcId && quest.questId == id) quest.questState = Quest.state.InProgress;
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

    public void setStateQuest(int npcId, int id, Quest.state state)
    {
        foreach (Quest quest in Quests)
        {
            if (quest.npcId == npcId && quest.questId == id) quest.questState = state;
        }

        _notes.updateTasks(Quests);
    }
    public void completeQuest(int npcId, int id)
    {
        foreach (Quest quest in Quests)
        {
            if (quest.npcId == npcId && quest.questId == id) quest.questState = Quest.state.Completed;
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
