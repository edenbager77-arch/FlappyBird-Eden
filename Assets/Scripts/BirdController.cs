using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] // ensures the component exists on the same GameObject
public class BirdController : MonoBehaviour
{ 
    [SerializeField] private float flapImpulse = 5.5f; // to adjust flap strength
   [SerializeField] private Rigidbody2D rb; // explicit reference to avoid getComponent 
   
   private bool canFlap = true; // guard to temporarily disable input

   private void onValidate()
   {
       if (rb == null) rb = GetComponent<Rigidbody2D>();
       if (flapImpulse <= 0f) flapImpulse = 0f; // ensure positive value
   }
   
    private void Update()
    {
         if (!canFlap) return; // early exit if flapping is disabled    
         
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) // spacebar or left mouse click
        {
            if (GameManager.Instance.CurrentState == GameState.NotStarted) 

            {
                GameManager.Instance.StartGame();
            }
            
            if (GameManager.Instance.CurrentState != GameState.Playing) return; // only flap when playing
            
            Flap();
        }
    }

    private void Flap()
    {
        var v = rb.linearVelocity; // remove current vertical speed
        v.y = 0f;
        rb.linearVelocity = v; // apply modified velocity
        rb.AddForce(Vector2.up * flapImpulse, ForceMode2D.Impulse); //  apply an immediate upward "kick"
    }
    
    private void disableFlapping() => canFlap = false; // disable flapping input
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        disableFlapping(); // stop responding to input
        GameManager.Instance.GameOver();
        Debug.Log("Bird died: hit " + collision.gameObject.name);
    }

    
}
