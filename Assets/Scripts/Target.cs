using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int points;
    public float lifetime = 2f;
    private GameManager gameManager;
    public GameObject explosionParticle;
    void Start()
    {
        Destroy(gameObject, lifetime);
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnMouseDown()
    {
        if (!gameManager.isGameOver)
        {
            if (gameObject.CompareTag("Bad"))
            {
                gameManager.isGameOver = true;
            }
            else if (gameObject.CompareTag("Good"))
            {
                gameManager.UpdateScore(points);
            }
        }
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        gameManager.targetPositionsInScene.Remove(transform.position);

    }
}
