using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static bool isLoading;
    public PlayerData playerData;
    public GameData gameData;

    public void SaveData()
    {
        playerData = ProgressManager.Instance.getPlayerData();
        gameData = ProgressManager.Instance.getGameData();
        SaveSystem.Save("playerdata", playerData);
        SaveSystem.Save("gamedata", gameData);

        DebugSave();
    }

    public PlayerData LoadPlayerData()
    {
        PlayerData _playerData;
        _playerData = SaveSystem.Load<PlayerData>("playerdata");
        return _playerData;
    }

    public GameData LoadGameData()
    {
        GameData _gameData;
        _gameData = SaveSystem.Load<GameData>("gamedata");
        return _gameData;
    }

    // delete later
    public void DebugSave()
    {
        Debug.Log("Scene: " + gameData.indexScene);
        Debug.Log("PositionX: " + playerData.position_x);
        foreach (Quest quest in gameData.Quests)
        {
            Debug.Log(quest.name + " | " + quest.questState);
        }
    }
}
