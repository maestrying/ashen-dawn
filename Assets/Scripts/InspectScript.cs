using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectScript : MonoBehaviour
{
    [SerializeField] private GameObject _ui;
    [SerializeField] private GameObject _inspectWindow;

    public void Back()
    {
        _ui.SetActive(true);
        _inspectWindow.SetActive(false);
    }
}
