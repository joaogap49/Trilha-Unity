using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var gameManager = GameManager.Instance;

        if (gameManager.IsGameOver())
        {
            return;
        }

        // Move the obstacle to the left based on the speed defined in GameManager
        float x = gameManager.obstacleSpeed * Time.fixedDeltaTime;
        transform.position -= new Vector3(x, 0, 0);

        // Destroy the obstacle if it goes off-screen
        if (transform.position.x <= -gameManager.obstacleOffsetX)
        {
            Destroy(gameObject);
        }
    }
}
