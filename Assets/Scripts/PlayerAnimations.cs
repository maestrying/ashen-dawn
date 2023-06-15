using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;
    private bool isFlashlight;
    public bool IsMoving { private get; set; }

    void Start()
    {
        _animator = GetComponent<Animator>();
        isFlashlight = (ProgressManager.Instance.flashlight && SceneManager.GetActiveScene().buildIndex == 10);
        Debug.Log(isFlashlight);
    }

    void FixedUpdate()
    {
        if (isFlashlight) _animator.SetBool("isFlashlight", isFlashlight);
        _animator.SetBool("IsMoving", IsMoving);
    }
}
