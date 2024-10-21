using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CalmWalkMonster : MonoBehaviour
{
    public float lifeTime = 7f;
    public float agroTime = 60f;
    public float speed = 10f;

    private bool triggered = false;

    private GameObject Player;
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = Player.GetComponent<PlayerMovement>();
        StartCoroutine(LifeTime());
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            StopCoroutine(LifeTime());
            transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, speed * Time.deltaTime * 0.02f);
        }

        if (playerMovement.horizontal > 0f || playerMovement.vertical > 0f)
        {
            triggered = true;
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
                SceneManager.LoadScene(2);
            }
        }
    }
}
