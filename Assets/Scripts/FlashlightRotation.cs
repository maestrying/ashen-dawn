using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlashlightRotation : MonoBehaviour
{
    public SpriteRenderer sprite;

    private void Start()
    {
        
    }

    private void Update()
    {
        Debug.Log(sprite.flipX);

        if (!sprite.flipX)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
            transform.position = new Vector3 (sprite.transform.position.x + 0.25f, transform.position.y, transform.position.z);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            transform.position = new Vector3(sprite.transform.position.x - 0.25f, transform.position.y, transform.position.z);
        }  
    }
}
