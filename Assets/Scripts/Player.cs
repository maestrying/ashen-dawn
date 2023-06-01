using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerData playerData;

    public void Start()
    {
        if (SaveManager.isLoading)
        {
            playerData = FindFirstObjectByType<SaveManager>().LoadPlayerData();
            Debug.Log("loaded pos: " + playerData.position_x);
            transform.position = new Vector3(playerData.position_x, playerData.position_y, playerData.position_z);
            GetComponentInChildren<SpriteRenderer>().flipX = playerData.rotation;

            SaveManager.isLoading = false;
        }

        if (SceneChanger.position != new Vector3(0, 0, 0)) transform.position = SceneChanger.position;
    }

    public void Update()
    {
        playerData.position_x = transform.position.x;
        playerData.position_y = transform.position.y;
        playerData.position_z = transform.position.z;
        playerData.rotation = GetComponentInChildren<SpriteRenderer>().flipX;
    }

    public PlayerData getData()
    {
        Debug.Log(playerData.position_x);
        return playerData;
    }
}
