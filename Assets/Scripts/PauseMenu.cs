using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //private bool _isPaused = false;
    private GameObject _uiButtons;
    private Animator _activeButtonAnimator;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _buttons;
    [SerializeField] private SaveButton _saveButton;
    [SerializeField] private SceneChanger _sceneChanger;
    [SerializeField] private SettingsManager _settingsManager;

    private void Awake()
    {
        _uiButtons = GameObject.FindWithTag("UI_Buttons");
        _activeButtonAnimator = GameObject.FindWithTag("ActionButton").GetComponent<Animator>();
        _activeButtonAnimator.keepAnimatorStateOnDisable = true;
    }

    public void Pause()
    {
        _pauseMenu.SetActive(true);
        _uiButtons.SetActive(false);
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }

    public void Resume()
    {
        _pauseMenu.SetActive(false);
        _uiButtons.SetActive(true);
        _saveButton.setDefault();
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    public void Settings()
    {
        _buttons.SetActive(false);
        _settings.SetActive(true);
    }

    public void Back()
    {
        _buttons.SetActive(true);
        _settings.SetActive(false);
        _settingsManager.SaveSettings();
    }

    public void ToMenu()
    {
        AudioListener.pause = false;
        Destroy(ProgressManager.Instance.gameObject);
        Time.timeScale = 1f;
        SceneChanger.indexScene = 1;
        _sceneChanger.Fade();
    }

}
