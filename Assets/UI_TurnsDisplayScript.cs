using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_TurnsDisplayScript : MonoBehaviour
{
    [SerializeField] TurnsManagerScript turnsManager;
    [SerializeField] TextMeshProUGUI turnsCounterDisplay;
    [SerializeField] TextMeshProUGUI charQueueDisplay;

    [SerializeField] List<GameObject> listBeingDisplayed;

private void Awake() {
    TurnsManagerScript.TurnsManagerInstalledEvent += Install;
}

private void Install() 
{
    UpdateTurnsCounter();
    UpdateCharQueue();

    TurnsManagerScript.NextTurnEvent += UpdateTurnsCounter;
    TurnsManagerScript.NextMacroTurnEvent += UpdateCharQueue;
}

void UpdateTurnsCounter()
{
    turnsCounterDisplay.text = (turnsManager.macroTurnsCounter.ToString() + " : " + turnsManager.turnsCounter.ToString());
}

void UpdateCharQueue ()
{
    if (listBeingDisplayed.Count != 0)
    {
        foreach (GameObject u in listBeingDisplayed)
        {
            Destroy(u);
        }
        listBeingDisplayed.Clear();
    }

    for (int i = 0; i < turnsManager.charQueue.Count; i++)
    {
        TeamSO charTeam = turnsManager.charQueue[i].GetComponent<CharacterManager>().characterTeam;
        string charName = turnsManager.charQueue[i].name.ToString();
        int charDelay = turnsManager.charQueue[i].GetComponentInChildren<CharacterVariablesManager>().delay;

        TextMeshProUGUI charTMP = Instantiate(charQueueDisplay, transform.position, Quaternion.identity);
        charTMP.transform.SetParent(gameObject.transform);
        charTMP.rectTransform.anchoredPosition = new Vector2(charTMP.rectTransform.anchoredPosition.x , charTMP.rectTransform.anchoredPosition.y - (i*charTMP.fontSize*1.2f));

        charTMP.text = (charTeam.name + " - " + charName + " - " + charDelay + "\n");
        charTMP.color = charTeam.color;

        listBeingDisplayed.Add(charTMP.gameObject); 
    }
    
}

}
