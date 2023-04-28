    using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "ScriptableObjects/Waves")]
public class Wave : ScriptableObject
{
    public string waveName = "";
    public GameObject[] EnemiesInWave;
    public float WaveDuration;
    public float LimitedNumberToSpawn;
    public float CooldownSpawn;
}
