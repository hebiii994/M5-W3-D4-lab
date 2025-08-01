using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class SO_Item : ScriptableObject
{
    [SerializeField] protected int _id;
    [SerializeField] protected string _itemName;
    [SerializeField, TextArea(5, 10)] protected string _description;
    [SerializeField] protected Sprite _icon;

    public int ID => _id;
    public string ItemName => _itemName;
    public string Description => _description;
    public Sprite Icon => _icon;

    public abstract void Use(GameObject user);
}
