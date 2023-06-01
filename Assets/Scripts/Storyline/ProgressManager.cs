using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressManager : MonoBehaviour
{
    public List<Quest> Quests;
    public GameData gameData;
    public PlayerData playerData;
    public GameObject character;
    public SaveManager saveManager;

    public void Awake()
    {
        character = GameObject.FindGameObjectWithTag("Character");
        saveManager = FindFirstObjectByType<SaveManager>();
        Debug.Log(character, saveManager.gameObject);
    }

    public void Start()
    {
        updatePlayerData();
        updateGameData();

        
    }

    public void updateGameData()
    {
        gameData.indexScene = SceneManager.GetActiveScene().buildIndex;
    }
    public void updatePlayerData()
    {
        playerData = character.GetComponent<Player>().getData();
        Debug.Log(playerData.position_x);
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

    public void setActiveQuest(int id)
    {
        gameData.activeQuest = id;
    }
    public void getQuestItem(string item)
    {
        playerData.questItems.Add(item);
    }


}
