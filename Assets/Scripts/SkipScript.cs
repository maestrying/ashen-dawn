using UnityEngine;

public class SkipScript : MonoBehaviour
{
    public SceneChanger changer;

    private void OnMouseDown()
    {
        changer.Fade();
    }
}
