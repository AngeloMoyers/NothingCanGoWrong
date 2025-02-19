using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Traps/Trap")]
public class TrapObject : ScriptableObject
{
    [SerializeField] string Name;
    [SerializeField] string Description;
    [SerializeField] GameObject ObjectPrefab;
    [SerializeField] Sprite Icon;

    public string GetName() { return Name; }
    public string GetDescription() { return Description; }
    public GameObject GetObjectPrefab() { return ObjectPrefab; }
    public Sprite GetIcon() { return Icon; }
}
