using UnityEngine;

public class BedScript : MonoBehaviour
{
    public static bool objectTouched;
    private SceneChanger _changer;

    public void Start()
    {
        if (!(ProgressManager.Instance.light == ProgressManager.LightState.Night))
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            _changer = GameObject.FindGameObjectWithTag("SceneChanger").GetComponent<SceneChanger>();
        }
    }
    private void OnMouseDown()
    {
        objectTouched = true;
        SceneChanger.indexScene = 17;
        _changer.Fade();
    }
    private void OnMouseUp()
    {
        objectTouched = false;
    }
}
