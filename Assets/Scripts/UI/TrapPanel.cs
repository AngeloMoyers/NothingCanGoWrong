using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapPanel : MonoBehaviour
{
    [SerializeField] Image Icon;
    
    private TrapObject Data;
    private int Count; //TODO
    public void SetData(TrapObject data)
    {
        Data = data;

        if (Icon)
        {
            Icon.sprite = data.GetIcon();
        }
        //TODO
    }

    public void AdjustCount(int adjustBy)
    {
        //TODO
    }
}
