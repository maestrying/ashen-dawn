using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    Animator _anim;
    [SerializeField] private int indexNextScene;
    public Vector3 nextPosition;
    public bool autoChangeScene;
    public AudioClip changeSceneSound;

    public void Awake()
    {
       _anim = GameObject.FindGameObjectWithTag("ExitButton").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Character"))
        {
            SceneChanger.indexScene = indexNextScene;
            SceneChanger.position = nextPosition;
            SceneChanger.changeSceneSound = changeSceneSound;

            if (autoChangeScene)
            {
                FindAnyObjectByType<SceneChanger>().Fade();
            }
            else
            {
                _anim.SetTrigger("IsTriggered");
            }
        }
    }
   
   private void OnTriggerExit2D(Collider2D other)
   {
       if (other.CompareTag("Character"))
       {
            _anim.SetTrigger("IsTriggered");
       }
   }
}
