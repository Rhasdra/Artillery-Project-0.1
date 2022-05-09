using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnsManagerScript : MonoBehaviour
{
    [SerializeField] ListsScript _listsManager;
    public List<GameObject> charQueue;
    [SerializeField] GameObject _currentChar;
    [SerializeField] int _currentCharIndex;

    public GameObject currentCharacter;
    public int turnsCounter;
    public int macroTurnsCounter;

    [SerializeField] private int _numberOfChars;

    ///// EVENTS /////
    public delegate void TurnsManagerInstalled();
    public static event TurnsManagerInstalled TurnsManagerInstalledEvent;

    public delegate void NextTurn();
    public static event NextTurn NextTurnEvent;

    public delegate void NextMacroTurn();
    public static event NextMacroTurn NextMacroTurnEvent;

    private void OnEnable() 
    {
        charQueue = _listsManager.characterQueue;
        turnsCounter = 0;
        macroTurnsCounter = 0;
        _numberOfChars = charQueue.Count;
    }


    private void Start() 
    {
        //[MUST ADD] Randomize list, or randomize delay values at spawn
        Shuffle(charQueue);
        StartTurn();
        CharacterManager.CharacterEndTurnEvent += EndTurn;
        
        TurnsManagerInstalledEvent?.Invoke();
    }

    void StartTurn()
    {
        //print ("Character Start Turn!");
        _currentChar = charQueue[_currentCharIndex]; //get first character in the queue
        currentCharacter = _currentChar; //public GO
        _currentChar.GetComponent<CharacterManager>().isMyTurn = true;
       
       
        NextTurnEvent?.Invoke();

    }

    void EndTurn()
    {
        IncreaseTurnsCounter();
        StartCoroutine("EndTurnCoroutine");
    }

    IEnumerator EndTurnCoroutine()
    {
        print ("Character End Turn!");
        _currentChar.GetComponent<CharacterManager>().isMyTurn = false;

        yield return new WaitForSeconds(0.2f);
        
        if (_currentCharIndex < _numberOfChars -1)
        {
            _currentCharIndex ++;
        }else
        {
            _currentCharIndex = 0;
        }
        // charQueue.RemoveAt(0); //remove first character in the queue
        // charQueue.Add(_currentChar); //add him at the end
        
        yield return null;
        StartTurn();
    }

    void IncreaseTurnsCounter()
    {
        turnsCounter ++;
        
        if (turnsCounter % _numberOfChars == 0f)
        {
            macroTurnsCounter ++;
            SortQueueByDelay(charQueue);
            NextMacroTurnEvent();
        }
    }

    void SortQueueByDelay(List<GameObject> unsorted)
    {
        int min;
        GameObject temp;

        for (int i = 0; i < unsorted.Count; i++)
        {
            min = i;

            for (int j = i + 1; j < unsorted.Count; j++)
            {
                if (unsorted[j].GetComponentInChildren<CharacterVariablesManager>().delay < unsorted[min].GetComponentInChildren<CharacterVariablesManager>().delay)
                {
                    min = j;
                }
            }

            if (min != i)
            {
                temp = unsorted[i];
                unsorted[i] = unsorted[min];
                unsorted[min] = temp;
            }
        }
    }

	void Shuffle(List<GameObject> a)
	{
		// Loops through array
		for (int i = a.Count-1; i > 0; i--)
		{
			// Randomize a number between 0 and i (so that the range decreases each time)
			int rnd = Random.Range(0,i);
			
			// Save the value of the current i, otherwise it'll overright when we swap the values
			GameObject temp = a[i];
			
			// Swap the new and old values
			a[i] = a[rnd];
			a[rnd] = temp;
		}
	}
}
