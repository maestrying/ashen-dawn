using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private Animator _anim;

    public static int indexScene;
    public static Vector3 position;
    //public static AudioClip changeSceneSound;
    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void Fade()
    {
        //PlayChangeSound();
        _anim.SetTrigger("fade");
    }

    public void FadeComplete()
    {
        SceneManager.LoadScene(indexScene);
    }

/*    public void PlayChangeSound()
    {
        if (changeSceneSound != null)
        {
            GetComponent<AudioSource>().clip = changeSceneSound;
            GetComponent<AudioSource>().Play();
        }
    }*/
}
