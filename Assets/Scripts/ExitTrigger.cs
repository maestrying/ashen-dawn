using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitTrigger : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] public int goToScene;

   private void OnTriggerEnter2D(Collider2D other)
   {
       if (other.CompareTag("Character")) 
       {
            _anim.SetBool("IsTriggered", true);
            SceneChanger._indexScene = goToScene;
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
