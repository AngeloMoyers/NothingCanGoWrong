using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPanel : MonoBehaviour
{
    [SerializeField] GameObject TrapPanelPrefab;
    [SerializeField] Transform ContentContainer;

    Dictionary<string, int> TrapTypeCount;
    Dictionary<string, GameObject> TrapTypeToPanel;

    private void Awake()
    {
        TrapTypeCount = new Dictionary<string, int>();
        TrapTypeToPanel = new Dictionary<string, GameObject>();
    }

    public void AddTrapPanel (TrapObject data)
    {
        if (TrapPanelPrefab != null)
        {
            if (ContentContainer != null)
            {
                TrapPanel trapPanel = null;
                GameObject trapPanelGO;
                if (!TrapTypeCount.ContainsKey(data.GetName()))
                {
                    trapPanelGO = GameObject.Instantiate(TrapPanelPrefab, ContentContainer);
                    trapPanel = trapPanelGO.GetComponent<TrapPanel>();

                    TrapTypeCount.Add(data.GetName(), 1);
                    TrapTypeToPanel.Add(data.GetName(), trapPanelGO);
                }
                else
                {
                    TrapTypeCount[data.GetName()]++;

                    TrapPanel targetPanel = TrapTypeToPanel[data.GetName()].GetComponent<TrapPanel>();
                    if (targetPanel)
                    {
                        targetPanel.AdjustCount(1);
                    }
                }

                if (trapPanel != null)
                {
                    trapPanel.SetData(data);
                }
            }
        }
    }

    public void RemoveTrap (TrapObject data)
    {
        if (data)
        {
            if (TrapTypeCount.ContainsKey(data.GetName()))
            {
                TrapTypeCount[data.GetName()]--;

                if (TrapTypeCount[data.GetName()] <= 0)
                {
                    GameObject.Destroy(TrapTypeToPanel[data.GetName()]);
                    TrapTypeToPanel.Remove(data.GetName());
                    TrapTypeCount.Remove(data.GetName());
                }
                else
                {
                    TrapTypeToPanel[data.GetName()].GetComponent<TrapPanel>().AdjustCount(-1);
                }
            }    
        }
    }    
}
