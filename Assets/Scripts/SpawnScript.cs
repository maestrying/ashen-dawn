using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] private Vector3 leftSpawnPosition = new Vector3(-20, (float)-3.7, 9);
    [SerializeField] private Vector3 rightSpawnPosition = new Vector3(40, (float)-3.6, 10);

    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject[] objects;
    [SerializeField] private int minDelay, maxDelay;
    private int randObjectIndex;


    private void Start()
    {
        if (ProgressManager.Instance.light == ProgressManager.LightState.Night) return;

        Invoke("SpawnLeftObj", Random.Range(minDelay, maxDelay));
        Invoke("SpawnRightObj", Random.Range(minDelay, maxDelay));
    }
    private void SpawnLeftObj()
    {
        randObjectIndex = Random.Range(0, objects.Length);
        GameObject obj = Instantiate(objects[randObjectIndex], leftSpawnPosition, Quaternion.identity);
        obj.transform.SetParent(parent.transform);
        obj.GetComponent<SpriteRenderer>().flipX = true;
        obj.GetComponent<SpawnObject>().destroyPositionX = 50;
        Invoke("SpawnLeftObj", Random.Range(minDelay, maxDelay));
    }

    private void SpawnRightObj()
    {
        randObjectIndex = Random.Range(0, objects.Length);
        GameObject obj = Instantiate(objects[randObjectIndex], rightSpawnPosition, Quaternion.identity);
        obj.transform.SetParent(parent.transform);
        obj.GetComponent<SpriteRenderer>().flipX = false;
        obj.GetComponent<SpawnObject>().destroyPositionX = -20;
        Invoke("SpawnRightObj", Random.Range(minDelay, maxDelay));

    }
}
