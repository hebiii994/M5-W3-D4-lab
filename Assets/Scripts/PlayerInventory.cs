using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }
    public event Action OnInventoryChanged;

    [SerializeField] private List<SO_Item> _items = new List<SO_Item>();
    [SerializeField] private Slider _teleportSlider;

    public List<SO_Item> Items => _items;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (_teleportSlider != null)
        {
            _teleportSlider.gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) UseItem(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) UseItem(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) UseItem(2);
    }

    public void AddItem(SO_Item item)
    {
        _items.Add(item);
        Debug.Log($"aggiunto {item.ItemName}. adesso possiedi {_items.Count}");
        OnInventoryChanged?.Invoke();
    }

    public void UseItem(int itemIndex)
    {
        if (itemIndex < 0 || itemIndex >= Items.Count) return;

        SO_Item itemToUse = Items[itemIndex];
        if (itemToUse is SO_TeleportRing)
        {
            StartCoroutine(TeleportSequence(itemIndex));
        }
        else
        {
            GameObject playerObject = FindObjectOfType<LifeController>()?.gameObject;
            if (playerObject != null)
            {
                itemToUse.Use(playerObject);
            }
            _items.RemoveAt(itemIndex);
            OnInventoryChanged?.Invoke();
        }
    }

    private IEnumerator TeleportSequence (int itemIndex)
    {
        if (_teleportSlider == null) yield break;
        Debug.Log("teletrasporto in corso...");
        _teleportSlider.gameObject.SetActive(true);
        float timer = 0f;
        const float c_duration = 2.0f;

        while (timer < c_duration)
        {
            _teleportSlider.value = timer / c_duration;
            timer += Time.deltaTime;
            yield return null;
        }
        _teleportSlider.gameObject.SetActive(false);

        Transform playerTransform = FindObjectOfType<LifeController>()?.transform;
        if (playerTransform != null)
        {
            playerTransform.position = new Vector3(0, 1, 0);
            Debug.Log("teletrasporto completato");
        }
        _items.RemoveAt(itemIndex);
        OnInventoryChanged?.Invoke();

    }
}
