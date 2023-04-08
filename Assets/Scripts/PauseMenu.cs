using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool _isPaused = false;
    private GameObject _uiButtons;
    private Animator _activeButtonAnimator;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _buttons;
    [SerializeField] private SceneChanger _sceneChanger;



    private void Awake()
    {
        _uiButtons = GameObject.FindWithTag("UI_Buttons");
        _activeButtonAnimator = GameObject.FindWithTag("ActionButton").GetComponent<Animator>();
        _activeButtonAnimator.keepAnimatorStateOnDisable = true;
    }

    private void FixedUpdate()
    {
        if (_isPaused)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    public void Pause()
    {
        _isPaused = true;
        _pauseMenu.SetActive(true);
        _uiButtons.SetActive(false);
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }

    public void Resume()
    {
        _isPaused = false;
        _pauseMenu.SetActive(false);
        _uiButtons.SetActive(true);
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
    }

    public void ToMenu()
    {
        Time.timeScale = 1f;
        _isPaused = false;
        SceneChanger.indexScene = 1;
        _sceneChanger.Fade();
    }

}
