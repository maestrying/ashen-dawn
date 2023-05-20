using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private SceneChanger sceneChanger;
    [SerializeField] private int _indexScene;
    [SerializeField] private Button _resumeButton;
    private GameData _gamedata;

    public void Start()
    {
        _gamedata = SaveSystem.Load<GameData>("game");

        if (_gamedata.indexScene == -1)
        {
            _resumeButton.interactable = false;
        }
        else 
        {
            _resumeButton.interactable = true;
        }
    }

    public void Resume()
    {
        SaveManager.isLoading = true;
        SceneChanger.indexScene = _gamedata.indexScene;
        sceneChanger.Fade();
    }

    public void NewGame()
    {
        SaveSystem.DeleteAllData();
        SceneChanger.indexScene = _indexScene;
        sceneChanger.Fade();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
