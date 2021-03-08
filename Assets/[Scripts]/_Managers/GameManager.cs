using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoSingleton<GameManager>
{
    public UnityEvent startEvent, winEvent, loseEvent;

    public PlayerController currentPlayer;

    public GameObject statesParent;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        startEvent.AddListener(()=>InputManager.Instance.SetState(new RunState()));
        
        startEvent.Invoke();
       
    }

    private void Initialize()
    {
       // InputManager.Instance.SetState(new EmptyState());
    }

}
