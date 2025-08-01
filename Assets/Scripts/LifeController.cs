using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private TMP_Text _healthText;

    [SerializeField] private int _currentHealth;
    public int CurrentHealth => _currentHealth;

    void Start()
    {
        _currentHealth = _maxHealth;
        UpdateHealthUI();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth < 0) _currentHealth = 0;
        Debug.Log($"Subiti {damage} danni. Vita rimasta: {_currentHealth}");
        UpdateHealthUI();
    }

    public void Heal(int amount)
    {
        _currentHealth += amount;
        if (_currentHealth > _maxHealth) _currentHealth = _maxHealth;
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (_healthText != null)
        {
            _healthText.text = $"Vita: {_currentHealth} / {_maxHealth}";
        }
    }
}
