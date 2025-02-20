using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class TrapPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image Icon;
    [SerializeField] TextMeshProUGUI CountText;
    [SerializeField] GameObject PopupInfoPanelPrefab;

    private BuildPanel OwningBuildPanel; 
    private TrapObject Data;
    private int Count;

    private GameObject PopupInfoPanelObject;
    private TrapPanelPopupInfoPnael PopupInfoPanel;
    private void SetCount(int newCount)
    {
        Count = newCount;
        CountText.text = Count.ToString();
    }

    public void SetOwningBuildPanel(BuildPanel buildPanel)
    {
        OwningBuildPanel = buildPanel;
    }

    public void SetData(TrapObject data)
    {
        Data = data;

        if (Icon)
        {
            Icon.sprite = data.GetIcon();
        }
        SetCount(1);

        PopupInfoPanelObject = GameObject.Instantiate(PopupInfoPanelPrefab, transform);
        PopupInfoPanel = PopupInfoPanelObject.GetComponent<TrapPanelPopupInfoPnael>();
        PopupInfoPanel.SetName(data.GetName());
        PopupInfoPanel.SetDescription(data.GetDescription());
        PopupInfoPanelObject.SetActive(false);
    }

    public void AdjustCount(int adjustBy)
    {
        SetCount(Count + adjustBy);
    }

    public void BeginPlacing()
    {
        TrapPlacementManager placementManager = GameObject.FindObjectOfType<TrapPlacementManager>();
        if (placementManager != null)
        {
            placementManager.BeginPlacement(Data, CompletePlacementCallback);
        }
    }

    private void CompletePlacementCallback()
    {
        if (OwningBuildPanel)
        {
            OwningBuildPanel.RemoveTrap(Data);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (PopupInfoPanelObject)
        {
            PopupInfoPanelObject.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (PopupInfoPanelObject)
        {
            PopupInfoPanelObject.SetActive(false);
        }
    }
}
