using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private Animator _anim;

    public static int indexScene;
    public static Vector3 position;
    //public static AudioClip changeSceneSound;

    private void Awake()
    {
        if (GameObject.Find("ProgressManager") == null) return;

        if (indexScene == 1 || SceneManager.GetActiveScene().buildIndex == 1)
        {
            Destroy(ProgressManager.Instance.gameObject);
        }
        else
        {

            ProgressManager.Instance.LoadResourses();
        }
    }
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
