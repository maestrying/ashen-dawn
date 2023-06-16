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
        ProgressManager.Instance.prefabLoader = this;
        LoadPrefabs();
    }

    public void LoadPrefabs()
    {
        List<Quest> quests = ProgressManager.Instance.Quests;

        switch (indexActiveScene)
        {
            // flat
            case 2:
                if (quests.Count == 8 && quests[7].questState == Quest.state.InProgress)
                {
                    Instantiate(prefabs[0].prefab, prefabs[0].loadPosition, Quaternion.identity); // Artyom
                }
                else
                {
                    Instantiate(prefabs[2].prefab, prefabs[2].loadPosition, Quaternion.identity); // toEntranceTrigger
                }

                if (quests.Count == 10)
                {
                    Instantiate(prefabs[4].prefab, prefabs[4].loadPosition, Quaternion.identity); // PsyMonologue
                }

                if (quests.Count == 0 && !SaveManager.isLoading)
                {
                    Instantiate(prefabs[1].prefab, prefabs[1].loadPosition, Quaternion.identity); // firstMonologue
                }

                break;

            // entrance-3
            case 3:
                if (quests.Count == 4 && quests[2].questState == Quest.state.InProgress)
                {
                    Instantiate(prefabs[0].prefab, prefabs[0].loadPosition, Quaternion.identity); // Wife
                }
                
                if (quests.Count == 8 && quests[6].questState == Quest.state.InProgress)
                {
                    Instantiate(prefabs[1].prefab, prefabs[1].loadPosition, Quaternion.identity); // Artyom
                    Instantiate(prefabs[3].prefab, prefabs[3].loadPosition, Quaternion.identity); // toCutSceneTrigger
                }
                else
                {
                    Instantiate(prefabs[2].prefab, prefabs[2].loadPosition, Quaternion.identity); // toFlatTrigger
                }
                break;

            // yard
            case 4:
                if (quests.Count == 0 || !(quests[0].questState == Quest.state.Completed))
                {
                    Instantiate(prefabs[0].prefab, prefabs[0].loadPosition, Quaternion.identity); // Max   
                }

                if (quests.Count == 7 && quests[5].questState == Quest.state.Completed)
                {
                    Instantiate(prefabs[2].prefab, prefabs[2].loadPosition, Quaternion.identity); // Artyom
                }

                if (!(ProgressManager.Instance.light == ProgressManager.LightState.Night))
                {
                    Instantiate(prefabs[1].prefab, prefabs[1].loadPosition, Quaternion.identity); // Kids   
                }
                break;

            // street-1
            case 11: 
                if (ProgressManager.Instance.light != ProgressManager.LightState.Night)
                {
                    Instantiate(prefabs[4].prefab, prefabs[4].loadPosition, Quaternion.identity); // ToStreet2
                }

                if (quests.Count == 2 && quests[1].questState == Quest.state.InProgress)
                {
                    Instantiate(prefabs[0].prefab, prefabs[0].loadPosition, Quaternion.identity); // MonologueTrigger
                    Instantiate(prefabs[2].prefab, prefabs[2].loadPosition, Quaternion.identity); // Box
                }

                if (quests.Count == 4 && quests[2].questState == Quest.state.Completed)
                {
                    Instantiate(prefabs[1].prefab, prefabs[1].loadPosition, Quaternion.identity); // ToAbandonedTrigger
                }

                if (quests.Count == 4 && quests[3].questState == Quest.state.Completed)
                {
                    Instantiate(prefabs[3].prefab, prefabs[3].loadPosition, Quaternion.identity); // NightMonologue
                }

                break;
            case 16:
                if (quests.Count == 9 && quests[8].questState == Quest.state.InProgress)
                {
                    Instantiate(prefabs[0].prefab, prefabs[0].loadPosition, Quaternion.identity); // birds
                }
                break;
            case 12:
                if (quests.Count == 10 && quests[9].questState == Quest.state.InProgress)
                {
                    Instantiate(prefabs[0].prefab, prefabs[0].loadPosition, Quaternion.identity); // ToPsyOffice
                }
                break;
        }
        
    }

    public void LoadPrefabById(int id)
    {
        Instantiate(prefabs[id].prefab, prefabs[id].loadPosition, Quaternion.identity);
    }
}
