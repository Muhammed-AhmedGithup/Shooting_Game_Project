using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class Enemyspawner : MonoBehaviour
{
    public GameObject enemypre;
    public Transform[] spawnPoint;


    private PlayerMovment playerMovment;


    private void Awake()
    {
        playerMovment = FindAnyObjectByType<PlayerMovment>();
    }
    private void Start()
    {
        StartCoroutine(enemycoritene());
    }

    private IEnumerator enemycoritene()
    {
        while (playerMovment!=null)
        {
            GameObject enemy = Instantiate(enemypre, spawnPoint[Random.Range(0, spawnPoint.Length)].position
                , Quaternion.identity);

            yield return new WaitForSeconds(3);
        }
    }
}
