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
        StartCoroutine(SummonMonster(objectsToSpawn[Random.Range(0, objectsToSpawn.Count)]));
    }

    private IEnumerator SummonMonster(GameObject monsterType)
    {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 monsterPosition = new Vector3(Random.Range(playerPosition.x - 5f, playerPosition.x + 5f), playerPosition.y + 5f, playerPosition.z); 
        GameObject newMonster = Instantiate(monsterType, monsterPosition, Quaternion.identity);

        if (newMonster.tag == "LightMonster")
        {
            playerLight.DimLight();
        }
        yield return new WaitForSeconds(monsterEventTime);

        if (newMonster.tag == "LightMonster")
        {
            playerLight.UndimLight();
        }
        yield return new WaitForSeconds(intervalTime);
        StartCoroutine(SummonMonster(objectsToSpawn[Random.Range(0, objectsToSpawn.Count)]));
    }
}
