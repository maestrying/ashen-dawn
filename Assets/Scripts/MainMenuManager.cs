using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    private const int _indexStartScene = 15;

    [SerializeField] private SceneChanger sceneChanger;
    [SerializeField] private Button _resumeButton;
    private GameData _gamedata;

    public void Start()
    {
        Application.targetFrameRate = 45;

        _gamedata = SaveSystem.Load<GameData>("gamedata");
        _resumeButton.interactable = _gamedata.indexScene == -1 ? false : true;
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
        SceneChanger.indexScene = _indexStartScene;
        SceneChanger.position = Vector3.zero;
        sceneChanger.Fade();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
