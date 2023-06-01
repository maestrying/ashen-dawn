using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public ProgressManager progressManager;

    public static bool isLoading;

    public void SaveData()
    {
        SaveSystem.Save("character", progressManager.getPlayerData());
        SaveSystem.Save("game", progressManager.getGameData());

        DebugSave();
    }

    public PlayerData LoadPlayerData()
    {
        PlayerData _playerData;
        _playerData = SaveSystem.Load<PlayerData>("character");
        return _playerData;
    }

    public GameData LoadGameData()
    {
        GameData _gameData;
        _gameData = SaveSystem.Load<GameData>("gameData");
        return _gameData;
    }

    // delete later
    public void DebugSave()
    {
        Debug.Log("______SAVE______");
        Debug.Log("Scene: " + progressManager.getGameData().indexScene);
        Debug.Log("position_x: " + progressManager.getPlayerData().position_x);
        Debug.Log("position_y: " + progressManager.getPlayerData().position_y);
        Debug.Log("position_z: " + progressManager.getPlayerData().position_z);
    }
}
