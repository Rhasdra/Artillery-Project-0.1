using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    //[SerializeField] private TeamSO[] currentTeam;
    //[SerializeField] private GameObject[] _players;
    [SerializeField] private GameObject _personalUI;
    [SerializeField] private GameObject _battleUI;
    
    [SerializeField] private ListsScript _lists;
    [SerializeField] private TeamSO[] _teams;
    [SerializeField] private GameObject _turnsManager;
    [SerializeField] private GameObject _turnsUI;
    
    private void Awake() 
    {
        //Spawn Input Manager
        //Spawn
        //Spawn Terrain
        GameEvents.MatchStartEvent += SpawnPlayersOnRandomLocation;
        //GameEvents.MatchStart += SpawnBattleUI;
    }

    void SpawnPlayersOnRandomLocation()
    {
        _teams = _lists.teams;

        for (int teamIndex = 0; teamIndex < _teams.Length; teamIndex++) //For each team
        {
            for (int charIndex = 0; charIndex < _teams[teamIndex].characters.Length; charIndex++) //For each character on the team
            {
                //[TO ADD] Check if there's ground under
                Vector2 position = new Vector2 (Random.Range(-15f, 15), 15f);
                GameObject newPlayer = Instantiate(_teams[teamIndex].characters[charIndex], position, Quaternion.identity);
                
                //Assign character to its Team and to the Queue
                CharacterManager newPlayerManager = newPlayer.gameObject.GetComponent<CharacterManager>();
                newPlayerManager.characterTeam = _teams[teamIndex];
                _lists.characterQueue.Add(newPlayer);

                //Spawn PersonalUI and hook character to it
                GameObject newCharacterUI = Instantiate(_personalUI, newPlayer.transform.position, Quaternion.identity);
                newCharacterUI.GetComponent<UI_CharacterUI>().character = newPlayerManager;
                newCharacterUI.gameObject.SetActive(true);
            } 
        }

        StartTurnsManager();
    }

    void StartTurnsManager()
    {
        _turnsManager.gameObject.SetActive(true);
        _turnsUI.SetActive(true);
    }

    // void SpawnBattleUI()
    // {
    //     Instantiate(battleUI, Vector3.zero, Quaternion.identity);
    // }

}
