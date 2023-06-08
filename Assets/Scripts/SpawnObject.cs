using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public float speed = 5f;
    [HideInInspector] public float destroyPositionX;
    private float rotation = 0;
    private Vector3 move;

    void Update()
    {   
        if (rotation == 0) 
        { 
            rotation = GetComponent<SpriteRenderer>().flipX ? 1 : -1;
            move = new Vector3(rotation, 0, 0);
        }

        transform.Translate(move * speed * Time.deltaTime);
        
        if (transform.position.x >= destroyPositionX && rotation == 1)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x <= destroyPositionX && rotation == -1)
        {
            Destroy(gameObject);
        }
    }
}
