using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Prefab
{
    public GameObject prefab;
    public Vector3 loadPosition;
}
public class PrefabLoader : MonoBehaviour
{
    private int indexActiveScene;
    public Prefab[] prefabs;

    private void Start()
    {
        indexActiveScene = SceneManager.GetActiveScene().buildIndex;
        LoadPrefabs();
    }

    private void LoadPrefabs()
    {
        List<Quest> quests = ProgressManager.Instance.Quests;

        switch (indexActiveScene)
        {
            // entrance-3
            case 3:
                if (quests.Count == 4 && quests[2].questState == Quest.state.InProgress)
                {
                    Instantiate(prefabs[0].prefab, prefabs[0].loadPosition, Quaternion.identity); // Wife
                }
                break;

            // yard
            case 4:
                if (quests.Count == 0 || !(quests[0].questState == Quest.state.Completed))
                {
                    Instantiate(prefabs[0].prefab, prefabs[0].loadPosition, Quaternion.identity); // Max   
                }

                Instantiate(prefabs[1].prefab, prefabs[1].loadPosition, Quaternion.identity); // Kids   
                break;

            // street-1
            case 11: 
                if (quests.Count == 2 && quests[1].questState == Quest.state.InProgress)
                {
                    Instantiate(prefabs[0].prefab, prefabs[0].loadPosition, Quaternion.identity); // MonologueTrigger
                    Instantiate(prefabs[2].prefab, prefabs[2].loadPosition, Quaternion.identity); // Box
                }

                if (quests.Count == 4 && quests[2].questState == Quest.state.Completed)
                {
                    Instantiate(prefabs[1].prefab, prefabs[1].loadPosition, Quaternion.identity); // ToAbandonedTrigger
                }
                break;
        }
        
    }
}
