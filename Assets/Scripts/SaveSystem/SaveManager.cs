using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    private GameObject _character;
    private SpriteRenderer _characterSprite;
    private PlayerData playerData;
    public static bool isLoading;

    public void Awake()
    {
        _character = GameObject.FindWithTag("Character");
        _characterSprite = _character.GetComponentInChildren<SpriteRenderer>();
    }
    public void Start()
    {
        if (isLoading)
        {
            LoadData();
            isLoading = false;
        }
        
    }

    public void SaveData()
    {
        SaveSystem.Save("character", characterData());
        SaveSystem.Save("game", gameData());
    }

    public void LoadData()
    {
        // characterData
        playerData = SaveSystem.Load<PlayerData>("character");
        _character.transform.position = new Vector3(playerData.position_x, playerData.position_y, playerData.position_z);
        _characterSprite.flipX = playerData.rotation;
    }



    // Data
    private PlayerData characterData()
    {
        var data = new PlayerData()
        {
            position_x = _character.transform.position.x,
            position_y = _character.transform.position.y,
            position_z = _character.transform.position.z,
            rotation = _character.GetComponentInChildren<SpriteRenderer>().flipX
        };

        return data;
    }
    
    private GameData gameData()
    {
        var data = new GameData()
        {
            indexScene = SceneManager.GetActiveScene().buildIndex
        };

        return data;
    }
}
