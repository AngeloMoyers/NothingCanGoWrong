using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrapPanelPopupInfoPnael : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI NameText;
    [SerializeField] TextMeshProUGUI DescriptionText;
    
    public void SetName(string name)
    {
        if (NameText != null)
        {
            NameText.text = name;
        }
    }

    public void SetDescription(string description)
    {
        if (DescriptionText != null)
        {
            DescriptionText.text = description;
        }
    }
}
