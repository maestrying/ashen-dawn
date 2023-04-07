using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ExitTrigger : MonoBehaviour
{

    Animator _anim;
    [SerializeField] public int indexNextScene;

    public void Awake()
    {
       _anim = GameObject.FindGameObjectWithTag("ActionButton").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
   {
        if (other.CompareTag("Character"))
        {
            _anim.SetTrigger("IsTriggered");
            SceneChanger._indexScene = indexNextScene;
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
