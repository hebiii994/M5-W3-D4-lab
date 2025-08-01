using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Teleport Ring", menuName = "Inventory/Teleport Ring")]
public class SO_TeleportRing : SO_Item
{
    public override void Use(GameObject user)
    {
        Debug.Log("dovrei spostarla da PlayerInventory?");
    }
}
