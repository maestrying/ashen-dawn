using UnityEngine;
using UnityEngine.UI;

public class Elevator : MonoBehaviour
{
    [SerializeField] private SceneChanger _sceneChanger;
    private Vector3 _elevatorPosition = new Vector3(-4.57f, -0.66f, -0.5f);
    public void selectFloor(Text floor)
    {
        switch (floor.text)
        {
            case "1":
                SceneChanger.indexScene = 5;
                break;
            case "3":
                SceneChanger.indexScene = 3;
                break;
            case "5":
                SceneChanger.indexScene = 6;
                break;
            case "8":
                SceneChanger.indexScene = 7;
                break;
            case "12":
                SceneChanger.indexScene = 8;
                break;
        }

        SceneChanger.position = _elevatorPosition;
        _sceneChanger.Fade();
    }

}
