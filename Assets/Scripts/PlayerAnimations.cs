using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;
    public bool IsMoving { private get; set; }

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        _animator.SetBool("IsMoving", IsMoving);
    }
}
