using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float _speed;
    private GameObject _ui;
    private Vector3 _input;
    private bool _IsMoving;
    
    private PlayerAnimations _animations;
    [SerializeField] private SpriteRenderer _characterSprite;
    private AudioSource _moveSound;

    private void Start()
    {
        _animations = GetComponentInChildren<PlayerAnimations>();
        _moveSound = GetComponent<AudioSource>();
        _ui = GameObject.FindGameObjectWithTag("UI");
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!_ui.activeInHierarchy)
        {
            _animations.IsMoving = false;
            OnButtonUp();
            return;
        }

        transform.position += _input * _speed * Time.deltaTime;

        _IsMoving = _input.x != 0 ? true : false;

        if (_IsMoving) {
            _characterSprite.flipX = _input.x < 0 ? true : false;
        }

        _animations.IsMoving = _IsMoving;
    }

    public void OnLeftButtonDown()
    {
        if (BoxScript.objectTouched || BedScript.objectTouched) return;
        _input = new Vector2(-1, 0);
        _moveSound.Play();
    }

    public void OnRightButtonDown()
    {
        if (BoxScript.objectTouched || BedScript.objectTouched) return;
        _input = new Vector2(1, 0);
        _moveSound.Play();
    }

    public void OnButtonUp() 
    {
        _input = new Vector2(0, 0);
        _moveSound.Stop();
    }
}
