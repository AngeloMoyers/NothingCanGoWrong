using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public enum TrapType
{
    kSpike,
    kFallingSpike
}

[CreateAssetMenu(menuName = "Traps/Trap")]
public class TrapObject : ScriptableObject
{
    [SerializeField] TrapType Type;
    [SerializeField] string Name;
    [SerializeField] string Description;
    [SerializeField] GameObject ObjectPrefab;
    [SerializeField] Sprite Icon;
    [SerializeField] Vector2Int TileDimensions;
    public TrapType GetTrapType() { return Type; }
    public string GetName() { return Name; }
    public string GetDescription() { return Description; }
    public GameObject GetObjectPrefab() { return ObjectPrefab; }
    public Sprite GetIcon() { return Icon; }
    public Vector2Int GetTileDimensions() {  return TileDimensions; }
}
