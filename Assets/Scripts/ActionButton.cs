using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    [HideInInspector] public static string actionType;
    [SerializeField] private Sprite _changeSceneTexture;
    [SerializeField] private Sprite _musicTexture;
    [SerializeField] private Sprite _dialogueTexture;
    [SerializeField] private Sprite _getItemTexture;

    public void Update()
    {
        Debug.Log(actionType);
    }
    public void setTextureButton()
    {
        switch (actionType)
        {
            case "ChangeScene":
                GetComponent<Image>().sprite = _changeSceneTexture;
                Debug.Log(GetComponent<Image>().sprite);
                break;

            case "MusicObject":
                GetComponent<Image>().sprite = _musicTexture;
                Debug.Log(GetComponent<Image>().sprite);
                break;
            case "Dialogue":
                GetComponent<Image>().sprite = _dialogueTexture;
                Debug.Log(GetComponent<Image>().sprite);
                break;
            case "GetItem":
                GetComponent<Image>().sprite = _getItemTexture;
                Debug.Log(GetComponent<Image>().sprite);
                break;
        }
    }
}
