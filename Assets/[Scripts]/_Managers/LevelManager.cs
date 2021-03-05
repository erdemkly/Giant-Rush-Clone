using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoSingleton<LevelManager>
{
    public List<Level> allLevels;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        LoadAllLevels();
    }

    private void LoadAllLevels()
    {
        var resourcesLevel = Resources.LoadAll<Level>("Levels");
        allLevels = resourcesLevel.ToList();
    }
}
