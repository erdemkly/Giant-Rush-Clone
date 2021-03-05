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
        PullAllLevels();
        PlayerPrefs.SetInt("Level",PlayerPrefs.HasKey("Level")?PlayerPrefs.GetInt("Level"):0);
    }

    private void PullAllLevels()
    {
        var resourcesLevel = Resources.LoadAll<Level>("Levels");
        allLevels = resourcesLevel.ToList();
    }

    public void SetLevel(int level, bool keep)
    {
        //Level yükleme..
        
        if (!keep) return;
        PlayerPrefs.SetInt("Level",level);
    }
}
