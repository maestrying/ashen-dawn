using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectScript : MonoBehaviour
{
    [SerializeField] private GameObject _ui;
    [SerializeField] private GameObject _inspectWindow;
    [SerializeField] private GameObject[] _inspectObjects;
    private int currentId;

    public bool startMonologue;

    public void Start()
    {
        if (startMonologue)
        {
            GetComponent<MonologueList>().StartMonologue();
        }
    }
    public void showObject(int id)
    {
        currentId = id;
        _inspectObjects[id].gameObject.SetActive(true);
    }
    public void Back()
    {
        _ui.SetActive(true);
        _inspectObjects[currentId].gameObject.SetActive(false);
        _inspectWindow.SetActive(false);
    }
}
