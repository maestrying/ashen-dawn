using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    public enum NPC
    {
        Max,
        Seller,
        Phone
    }

    public NPC npc;
    public List<Quest> quests;
    [SerializeField] private DialogueManager dialogueManager;

    public void giveQuest(int id)
    {
        ProgressManager.Instance.addQuest(quests[id]);
    }

    public int getDialogueId()
    {
        if (npc == NPC.Max)
        {
            return MaxDialogueLogic();
        }
        else if (npc == NPC.Seller)
        {
            return SellerDialogueLogic();
        }
        else if (npc == NPC.Phone)
        {
            return 0;
        }

        return -1;
    }

    // NPC DIALOGUE LOGIC
    private int MaxDialogueLogic()
    {
        List<Quest> activeQuests = ProgressManager.Instance.Quests;

        if (activeQuests.Count == 0)
        {
            return 0;
        }
        else if (activeQuests[0].questState == Quest.state.InProgress && (activeQuests.Count < 2 || activeQuests[1].questState != Quest.state.Completed))
        { 
            return 1;
        }
        else if (activeQuests[0].questState == Quest.state.BackToComplete)
        {
            ProgressManager.Instance.setStateQuest(0, 0, Quest.state.Completed);
            return 2;
        }

        return 3;
    }

    private int SellerDialogueLogic()
    {
        List<Quest> activeQuests = ProgressManager.Instance.Quests;

        if (activeQuests.Count == 1 && activeQuests[0].questState == Quest.state.InProgress)
        {
            return 1;
        }
        else if (activeQuests.Count == 2 && activeQuests[1].questState == Quest.state.InProgress)
        {
            return 2;
        }
        else if (activeQuests.Count > 2 && activeQuests[1].questState == Quest.state.BackToComplete)
        {
            ProgressManager.Instance.setStateQuest(1, 0, Quest.state.Completed);
            ProgressManager.Instance.setStateQuest(0, 0, Quest.state.BackToComplete);
            return 3; 
        }
        return 0;
    }

    private int PhoneDialogueLogic()
    {
        List<Quest> activeQuests = ProgressManager.Instance.Quests;

        if (activeQuests.Count == 0)
        {
            return 0;
        }

        return -1;
    }
}
