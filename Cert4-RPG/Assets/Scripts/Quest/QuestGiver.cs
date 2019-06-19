using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class QuestUI
{
    public PlayerQuest player;
    public GameObject quetsWindow;

    public Text nameText;
    public Text descriptionText;
    public Text expText;
    public Text goldtext;
}
public class QuestGiver : MonoBehaviour
{
    //goes on our NPC
    public Quest quest;
    public QuestUI ui;

    public void OpenQuestWindow()
    {
        ui.quetsWindow.SetActive(true);
        ui.nameText.text = quest.name;
        ui.descriptionText.text = quest.description;
        ui.expText.text = quest.expReward.ToString();
        ui.goldtext.text = quest.goldReward.ToString();
    }

    public void AcceptQuest()
    {
        ui.quetsWindow.SetActive(false);
        if (quest.state == QuestState.New)
        {
            quest.state = QuestState.Accepted;
            ui.player.quests.Add(quest);
        }
    }
	
}
