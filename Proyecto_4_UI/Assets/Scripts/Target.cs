using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameManager gameManagerScript;
    private float destroyTime = 1f;
    public ParticleSystem explosion;
    
   
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
        gameManagerScript = FindObjectOfType<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Good"))
        { Destroy(gameObject);
            if (!gameManagerScript.gameOver)
            { gameManagerScript.score = gameManagerScript.score + 1; }
           
        }

        else if (gameObject.CompareTag("Bad"))
        {
            Destroy(gameObject);
            gameManagerScript.missTarget += 1;
            if (gameManagerScript.missTarget > gameManagerScript.totalmisses)
            { gameManagerScript.gameOver = true; }
            if (!gameManagerScript.gameOver)
            { gameManagerScript.live = gameManagerScript.live - 1; }

        }
        Instantiate(explosion, transform.position, explosion.transform.rotation);
    }
    private void OnDestroy()
    {
        gameManagerScript.targetPositions.Remove(transform.position);
    }
}
