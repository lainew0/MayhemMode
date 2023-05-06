using UnityEngine;
using System;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text expText;
    [SerializeField] private TMP_Text killCountText;
    [SerializeField] private TMP_Text waveNameText;

    void OnEnable()
    {
        ActionsManager.onHealthChanged += ChangeHealthText;
        ActionsManager.onKillCountChanged += ChangeKillCountText;
        ActionsManager.onExpChanged += ChangeExpText;
        WaveManager.onCurrentWaveChanged += ChangeWaveText;
    }

    void OnDisable()
    {
        ActionsManager.onHealthChanged -= ChangeHealthText;
        ActionsManager.onKillCountChanged -= ChangeKillCountText;
        ActionsManager.onExpChanged -= ChangeExpText;
        WaveManager.onCurrentWaveChanged -= ChangeWaveText;
    }

    void ChangeHealthText(int health)
    {
        healthText.text = "Health: " + health.ToString();
    }

    private void ChangeExpText(int exp)
    {
        expText.text = "EXP: " + exp.ToString();
    }
    private void ChangeKillCountText(int killCount)
    {
        killCountText.text = "Kills: " + killCount.ToString();
    }

    private void ChangeWaveText(string waveName)
    {
        waveNameText.text = "Волна: " + waveName;
    }


}
