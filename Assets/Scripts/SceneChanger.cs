using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private Animator _anim;

    public static int indexScene;
    public static Vector3 position;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void Fade()
    {
        Debug.Log("position" + position);
        _anim.SetTrigger("fade");
    }

    public void FadeComplete()
    {
        SceneManager.LoadScene(indexScene);
    }
}
