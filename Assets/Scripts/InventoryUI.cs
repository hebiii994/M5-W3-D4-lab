using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    
    [SerializeField] private Image[] _itemSlotImage;


    private void OnDisable()
    {
        if (PlayerInventory.Instance != null)
        {
            PlayerInventory.Instance.OnInventoryChanged -= UpdateUI;
        }
            
    }

    private void Start()
    {
        PlayerInventory.Instance.OnInventoryChanged += UpdateUI;
        UpdateUI();
    }
    private void UpdateUI()
    {
        
       List<SO_Item> items = PlayerInventory.Instance.Items;

        for (int i = 0; i < _itemSlotImage.Length; i++)
        {
            if (i < items.Count)
            {
                _itemSlotImage[i].sprite = items[i].Icon;
                _itemSlotImage[i].enabled = true;
            }
            else
            {
                _itemSlotImage[i].enabled = false;
            }
        }
    }
}
