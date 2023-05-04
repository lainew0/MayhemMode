using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    WorldScrolling ws;
    public GameObject targetMap;

    void Start()
    {
        ws = FindObjectOfType<WorldScrolling>();
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player")) ws.currentChunk = targetMap;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (ws.currentChunk == targetMap)
            {
                ws.currentChunk = null;
            }
        }
    }
}
