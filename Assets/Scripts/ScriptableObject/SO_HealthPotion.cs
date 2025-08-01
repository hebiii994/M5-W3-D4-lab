using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Health Potion", menuName = "Inventory/Health Potion")]
public class SO_HealthPotion : SO_Item
{
    [SerializeField] private int _healingAmount = 25;

    public override void Use(GameObject user)
    {
        LifeController playerhealth = user.GetComponent<LifeController>();
        if (playerhealth != null)
        {
            playerhealth.Heal(_healingAmount);
        }
    }

}
