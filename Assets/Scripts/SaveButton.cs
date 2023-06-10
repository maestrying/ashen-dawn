using UnityEngine;
using UnityEngine.UI;

public class SaveButton : MonoBehaviour
{
    private Text _buttonLabel;
    private SaveManager _manager;

    public void Start()
    {
        _manager = FindFirstObjectByType<SaveManager>();
        _buttonLabel = GetComponent<Text>();
    }
    public void Save()
    {
        _manager.SaveData();
        showResult();
    }

    public void showResult()
    {
        _buttonLabel.text = "Игра сохранена";
        _buttonLabel.color = new Color(0.3f, 1, 0.3f);
    }

    public void setDefault()
    {
        _buttonLabel.text = "Сохранить игру";
        _buttonLabel.color = Color.white;
    }
}
