using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;

    public GameObject box;
    private Coroutine goodByeRoutine;

    void Start()
    {
        StartCoroutine(SpawnRoutine()); 
        //InvokeRepeating(nameof(RandomSpawn), 0, 5);
        //StartCoroutine (Hello());
        //StartCoroutine(Goodbye());
        //goodByeRoutine = StartCoroutine(Goodbye());
    }

    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(5+5-5);
        while (true)
        {
            RandomSpawn();
            yield return new WaitForSeconds(3);
        }
    }

    void RandomSpawn()
    {
        var index = Random.Range(0, spawnPoints.Length);
        var spawnPoint = spawnPoints[index];
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity); 
    }

    //private void Update()
    //{
    //    if (Time.time > 5)
    //    {
    //        if(goodByeRoutine != null) // -----> Stop Only 1 Coroutine 
    //        {
    //            StopCoroutine(goodByeRoutine);
    //        }


    //        //StopAllCoroutines(); // -----> Stop All
            
    //    }
    //}
    IEnumerator Goodbye()
    {
        while (true)
        {
            Debug.Log ("Bye " + Time.frameCount + " " + Time.time);
            //yield return new WaitForSeconds(1);
            yield return null;

            yield break; // -----> Stop immediately

            //StartCoroutine(Hello());
            yield return Hello(); 
        }
    }
    IEnumerator Hello()
    {
        Debug.Log("Hello " + Time.frameCount);
        Debug.Log("Hello " + Time.frameCount);
        Debug.Log("Hello " + Time.frameCount);
        yield return null;
        Debug.Log("Hello " + Time.frameCount);
        yield return null;
        Debug.Log("Hello " + Time.frameCount);
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        Debug.Log("Hello " + Time.frameCount);
    }


}
