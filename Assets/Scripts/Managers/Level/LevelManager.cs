using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct LevelToData
{
    public int Level;
    public LevelData LevelData;
}

public class LevelManager : MonoBehaviour
{
    [SerializeField] CharacterLoopManager LoopMan;
    [SerializeField] BuildManager BuildMan;
    [SerializeField] List<LevelToData> LevelTrapData;

    private Dictionary<int, LevelData> LevelDataDict = new Dictionary<int, LevelData>();

    private void Awake()
    {
        for (int i = 0; i < LevelTrapData.Count; i++)
        {
            LevelDataDict.Add(LevelTrapData[i].Level, LevelTrapData[i].LevelData); 
        }
    }

    void Start()
    {
        DontDestroyOnLoad(this);
        LoopMan.BeginLevel(LevelDataDict[SGameManager.CurrentLevel].GetTrapsHacksUnlockedFor());
        BuildMan.LoadLevelData(LevelDataDict[SGameManager.CurrentLevel]);
    }

    public void AdvanceLevel()
    {
        SceneManager.LoadScene(SGameManager.IterateLevel());
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LoopMan.BeginLevel(LevelDataDict[SGameManager.CurrentLevel].GetTrapsHacksUnlockedFor());
        BuildMan.LoadLevelData(LevelDataDict[SGameManager.CurrentLevel]);
    }
}
