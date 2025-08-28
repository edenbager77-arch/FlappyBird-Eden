using UnityEngine;

public class PipeMover : MonoBehaviour
{
    [SerializeField] private float speed = 2.5f;   // units/second
    [SerializeField] private float destroyX = -8f; // when off-screen left 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.CurrentState != GameState.Playing) return;

        // Move left in world space
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Clean up when far off-screen (prevents memory growth)
        if (transform.position.x <= destroyX)
        {
            Destroy(gameObject);
        }
    }
    
}
