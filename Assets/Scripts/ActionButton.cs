using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    public string actionType;
    [SerializeField] private Sprite _changeSceneTexture;
    [SerializeField] private Sprite _musicTexture;

    public void setTextureButton()
    {
        switch (actionType)
        {
            case "ChangeScene":
                GetComponent<Image>().sprite = _changeSceneTexture;
                Debug.Log(GetComponent<Image>().sprite);
                break;

            case "Music":
                GetComponent<Image>().sprite = _musicTexture;
                Debug.Log(GetComponent<Image>().sprite);
                break;
        }
    }
}
