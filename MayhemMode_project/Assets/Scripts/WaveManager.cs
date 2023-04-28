using UnityEngine;
using System;

public class WaveManager : MonoBehaviour
{
    [Header("Время, сколько будут идти враги")]
    [SerializeField] private float totalTime = 10;
    [SerializeField] private float currentTime;

    [Header("")]
    [SerializeField] private GameObject player;
    [SerializeField] private int limitedEnimiesOnMap;
    [SerializeField] private Vector2 spawnArea;
    [SerializeField] private float spawnTimer;


    public Wave[] waves;
    private Wave currentWave;
    [SerializeField] private int waveNumber = 0;
    private float waveDuration;
    public bool stopSendingWaves = false;

    public static Action<string> onCurrentWaveChanged;

    void Awake()
    {
        currentWave = waves[waveNumber];
        
        currentTime = totalTime;

        waveDuration = currentWave.WaveDuration;
        spawnTimer = currentWave.CooldownSpawn;
    }

    void Update()
    {
        if (stopSendingWaves) return;
        // currentTime -= Time.deltaTime;

        HandleWaves();

        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0f)
        {
            SpawnWave();
            spawnTimer = currentWave.CooldownSpawn;
        }
    }

    void HandleWaves()
    {
        if (waveNumber >= waves.Length) stopSendingWaves = true;

        waveDuration -= Time.deltaTime;
        if (waveDuration <= 0)
        {
            waveNumber++;
            currentWave = waves[waveNumber];
            waveDuration = currentWave.WaveDuration;
        }

        onCurrentWaveChanged?.Invoke(currentWave.waveName);
    }

    void SpawnWave()
    {
        Vector3 position = GenerateRandomPosition();
        position += player.transform.position;

        int randomEnemyInWave = UnityEngine.Random.Range(0, currentWave.EnemiesInWave.Length);

        GameObject newEnemy = Instantiate(currentWave.EnemiesInWave[randomEnemyInWave]);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<EnemyBehaviour>().SetTarget(player);
        newEnemy.transform.parent = transform;
    }


    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();

        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;

        if (UnityEngine.Random.value > 0.5f)
        {
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
        }
        else {
            position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * f;
        }

        position.z = 0;

        return position;
    }
}
