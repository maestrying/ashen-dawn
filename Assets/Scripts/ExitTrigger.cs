using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    Animator _anim;
    [SerializeField] private int indexNextScene;
    public Vector3 nextPosition;

    public void Awake()
    {
       _anim = GameObject.FindGameObjectWithTag("ExitButton").GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Character"))
        {
            _anim.SetTrigger("IsTriggered");
            SceneChanger.indexScene = indexNextScene;
            
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
