using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TrapToCount
{
    public TrapObject Trap;
    public int Count;
}

[CreateAssetMenu(menuName = "Levels/Data")]
public class LevelData : ScriptableObject
{
    [SerializeField] List<TrapToCount> TrapsAvailable;
    [SerializeField] List<TrapType> TrapsHacksUnlockedFor = new List<TrapType>();

    public List<TrapToCount> GetTrapsAvailable() {  return TrapsAvailable; }
    public List<TrapType> GetTrapsHacksUnlockedFor() { return TrapsHacksUnlockedFor; }
}
