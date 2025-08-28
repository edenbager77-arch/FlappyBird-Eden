using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject pipePairPrefab;

    [Header("Spawn timing")]
    [SerializeField] private float interval = 1.6f;

    [Header("Gap vertical range")]
    [SerializeField] private float minY = -1.5f;
    [SerializeField] private float maxY = +1.5f;

    private float timer;

    private void Update()
    {
        if (GameManager.Instance.CurrentState != GameState.Playing) return;

        timer += Time.deltaTime;
        if (timer >= interval)
        {
            timer = 0f;
            Spawn();
        }
    }

    private void Spawn()
    {
        float y = Random.Range(minY, maxY);
        Vector3 pos = new Vector3(transform.position.x, y, 0f);
        Instantiate(pipePairPrefab, pos, Quaternion.identity);
    }
}