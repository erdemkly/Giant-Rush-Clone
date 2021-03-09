using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct MyColor
{
    public enum MyColorEnum
    {
        Red,
        Blue,
        Green
    }

    public MyColorEnum color;
    public Material material;
    public Material colorChangerMaterial;

}
public class GameManager : MonoSingleton<GameManager>
{
    public UnityEvent idleEvent, startEvent, winEvent, loseEvent;

    public PlayerController currentPlayer;

    public GameObject statesParent;

    [SerializeField]
    public List<MyColor> allMaterials;
    
    
    
    public int starCount;

    public MyColor GetMyColorWithEnum(MyColor.MyColorEnum matName)
    {
        var myColor = allMaterials.FirstOrDefault(x => x.color == matName);
        return myColor;
    }
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        idleEvent.AddListener(()=>InputManager.Instance.SetState(new EmptyState()));
        startEvent.AddListener(()=>InputManager.Instance.SetState(new RunState()));
        idleEvent.Invoke();
       
    }

    private void Initialize()
    {
       // InputManager.Instance.SetState(new EmptyState());
    }

}
