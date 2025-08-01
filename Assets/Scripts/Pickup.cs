using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private SO_Item _itemToPickup;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory.Instance.AddItem(_itemToPickup);
            Destroy(gameObject);
        }
    }
}
