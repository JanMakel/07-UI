using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int points; //Puntuacion de los Prefabs
    public float lifetime = 2f;
    private GameManager gameManager;
    public GameObject explosionParticle;
    void Start()
    {
        Destroy(gameObject, lifetime); //Autodestruccion
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnMouseDown()
    {
        if (!gameManager.isGameOver)
        {
            if (gameObject.CompareTag("Bad"))
            {
                if (gameManager.hasPowerUpShield)
                {
                    gameManager.hasPowerUpShield = false;
                }
                else
                {
                    gameManager.minusLive();
                }
                
            }
            else if (gameObject.CompareTag("Good"))
            {
                gameManager.UpdateScore(points);
            }
            else if (gameObject.CompareTag("Shield"))
            {
                gameManager.hasPowerUpShield = true;
            }
        }
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        Destroy(gameObject);

    }

    private void OnDestroy()
    {
        gameManager.targetPositionsInScene.Remove(transform.position); //Dejamos libre la posicion para que la ocupe otro objeto

    }
}
