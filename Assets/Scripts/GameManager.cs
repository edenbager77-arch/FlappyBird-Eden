using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance { get; private set; } // singleton instance
    
    public GameState CurrentState { get; private set; } = GameState.NotStarted; // initial state
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // enforce singleton pattern
            return;
        }
        Instance = this;
        
    }

    public void StartGame()
    {
        if (CurrentState != GameState.NotStarted) return; // only start if not already started
        CurrentState = GameState.Playing;
        Debug.Log("Game Started");
    }
    
    public void GameOver()
    {
        if (CurrentState != GameState.GameOver) return; // only end if currently playing
        CurrentState = GameState.GameOver;
        Debug.Log("Game Over");
    }
    
    public void Restart()
    {
        // reloads current scene = full reset
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
