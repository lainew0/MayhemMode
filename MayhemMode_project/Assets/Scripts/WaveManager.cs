using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private bool stopSendingWaves = false;

    enum WaveState
    {
        First,
        Second,
        Third,
        Fourth,
    }

    WaveState waveState = WaveState.First;

    void Awake()
    {
        currentWave = waves[waveNumber];
        
        currentTime = totalTime;
        spawnTimer = currentWave.CooldownSpawn;
    }

    void Update()
    {
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
        currentWave.WaveDuration -= Time.deltaTime;

        if (currentWave.WaveDuration <= 0)
        {
            waveNumber++;
            currentWave = waves[waveNumber];
        }

        if (waveNumber + 1 < waves.Length) stopSendingWaves = true;
    }

    void SpawnWave()
    {
        Vector3 position = GenerateRandomPosition();
        position += player.transform.position;

        GameObject newEnemy = Instantiate(currentWave.EnemiesInWave[0]);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<EnemyBehaviour>().SetTarget(player);
        newEnemy.transform.parent = transform;
    }

    /*
    void HandleWavesState()
    {
        if (currentTime <= totalTime * 0.75)
        {
            waveState = WaveState.Second;
        }
        else if (currentTime <= totalTime * 0.5)
        {
            waveState = WaveState.Third;
        }
        else if (currentTime <= totalTime * 0.25)
        {
            waveState = WaveState.Fourth;
        }

        switch (waveState)
        {
            case WaveState.First:
                
            break;
            case WaveState.Second:

            break;
            case WaveState.Third:

            break;
            case WaveState.Fourth:

            break;
        }
    }
    */

    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();

        float f = Random.value > 0.5f ? -1f : 1f;

        if (Random.value > 0.5f)
        {
            position.x = Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
        }
        else {
            position.y = Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * f;
        }

        position.z = 0;

        return position;
    }
}
