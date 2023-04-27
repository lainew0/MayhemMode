using UnityEngine;
using System;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text expText;
    [SerializeField] private TMP_Text killCountText;

    void OnEnable()
    {
        Character.onHealthChanged += ChangeHealthText;
    }

    void OnDisable()
    {
        Character.onHealthChanged -= ChangeHealthText;
    }

    void ChangeHealthText(int health)
    {
        healthText.text = "Здоровье: " + health.ToString();
    }
}
