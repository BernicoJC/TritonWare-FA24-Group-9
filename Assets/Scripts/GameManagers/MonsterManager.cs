using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public float graceTimer = 30f;
    public float intervalTime = 20f;
    public float monsterEventTime = 7f;

    [SerializeField]
    private PlayerLight playerLight;
    [SerializeField]
    private List<GameObject> objectsToSpawn = new List<GameObject>();
    [SerializeField]
    private ProgressManager progressManager;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private List<AudioClip> audiosToPlay = new List<AudioClip>();

    void Start()
    {
        StartCoroutine(GracePeriod());
    }

    private void Update()
    {
        if (progressManager.itemCount == 0)
        {
            intervalTime = 20f;
        }
        if (progressManager.itemCount == 1)
        {
            intervalTime = 15f;
        }
        if (progressManager.itemCount == 2)
        {
            intervalTime = 10f;
        }
        if (progressManager.itemCount == 3)
        {
            intervalTime = 5f;
        }
    }

    private IEnumerator GracePeriod()
    {
        yield return new WaitForSeconds(graceTimer);
        StartCoroutine(SummonMonster(Random.Range(0, objectsToSpawn.Count)));
    }

    private IEnumerator SummonMonster(int monsterType)
    {
        GameObject theMonster = objectsToSpawn[monsterType];
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 monsterPosition = new Vector3(Random.Range(playerPosition.x - 5f, playerPosition.x + 5f), playerPosition.y + 5f, playerPosition.z);
        GameObject newMonster = Instantiate(theMonster, monsterPosition, Quaternion.identity);

        audioSource.clip = audiosToPlay[monsterType];
        audioSource.Play(0);

        if (monsterType == 0)
        {
            Debug.Log("Panic Light Monster Spawned");
        }
        if (monsterType == 1)
        {
            Debug.Log("Calm Light Monster Spawned");
        }
        if (monsterType == 2)
        {
            Debug.Log("Calm Walk Monster Spawned");
        }
        if (monsterType == 3)
        {
            Debug.Log("Panic Walk Monster Spawned");
        }


        if (newMonster.tag == "LightMonster")
        {
            playerLight.DimLight();
        }
        yield return new WaitForSeconds(monsterEventTime);
        audioSource.Stop();

        if (newMonster.tag == "LightMonster")
        {
            playerLight.UndimLight();
        }
        yield return new WaitForSeconds(intervalTime);
        StartCoroutine(SummonMonster(Random.Range(0, objectsToSpawn.Count)));
    }
}
