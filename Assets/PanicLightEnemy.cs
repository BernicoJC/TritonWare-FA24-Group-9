using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanicLightEnemy : MonoBehaviour
{
    public float lifeTime = 7f;
    public float responseTime = 2f;
    public float agroTime = 60f;
    public float speed = 10f;

    private bool triggered = false;

    private GameObject Player;
    private PlayerLight playerLight;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerLight = Player.GetComponent<PlayerLight>();
        StartCoroutine(LifeTime());
        StartCoroutine(ListenToResponds());
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            StopCoroutine(LifeTime());
            transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, speed * Time.deltaTime);
        }
    }

    private IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(lifeTime);

        if (!triggered)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (triggered)
        {
            if (other.gameObject == Player)
            {
                Destroy(other.gameObject);
                // Start a coroutine for ending screen
            }
        }
    }

    private IEnumerator ListenToResponds()
    {
        yield return new WaitForSeconds(responseTime);
        if (playerLight.light_timer > 25f)
        {
            triggered = true;
        }
    }
}
