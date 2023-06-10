using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerData playerData;

    public void Awake()
    {
        if (SaveManager.isLoading)
        {
            playerData = FindFirstObjectByType<SaveManager>().LoadPlayerData();
            Debug.Log("loaded pos: " + playerData.position_x);
            transform.position = new Vector3(playerData.position_x, playerData.position_y, playerData.position_z);
            GetComponentInChildren<SpriteRenderer>().flipX = playerData.rotation;

            return;
        }

        Debug.Log(SceneChanger.position);
        if (SceneChanger.position != new Vector3(0, 0, 0)) transform.position = SceneChanger.position;
    }

    public PlayerData getData()
    {
        var data = new PlayerData()
        {
            position_x = transform.position.x,
            position_y = transform.position.y,
            position_z = transform.position.z,
            rotation = GetComponentInChildren<SpriteRenderer>().flipX
        };

        playerData = data;

        return playerData;
    }
}
