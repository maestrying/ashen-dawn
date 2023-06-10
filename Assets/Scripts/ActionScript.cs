using UnityEngine;

public class ActionScript : MonoBehaviour
{
    public GameObject actionObject;

    public void DoAction()
    {
        if (actionObject.name == "phone")
        {
            phoneScript script = actionObject.GetComponent<phoneScript>();
        }
    }
}
