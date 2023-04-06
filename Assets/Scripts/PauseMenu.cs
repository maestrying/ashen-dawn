using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool _isPaused = false;
    private GameObject _uiButtons;
    private Animator _activeButtonAnimator;
    [SerializeField] private GameObject _pauseMenu;



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
    }

    public void Resume()
    {
        _isPaused = false;
        _pauseMenu.SetActive(false);
        _uiButtons.SetActive(true);
        Time.timeScale = 1f;
    }
}
