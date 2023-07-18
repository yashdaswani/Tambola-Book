using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketsManager : MonoBehaviour
{
    public int _ticketsAtATime = 1;
    public GameObject _ticketsHolder;
    public GameObject[] _ticketTypesPrefab;

    public int _countForTicketsInScrollView;//Only for testing
    void Start()
    {
        for(int i = 0; i < _countForTicketsInScrollView; i++)
        {
            GameObject go = Instantiate(_ticketTypesPrefab[_ticketsAtATime]);
            go.transform.parent = _ticketsHolder.transform;
        }
    }
    void Update()
    {
        
    }
}
