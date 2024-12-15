using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;
    private Vector3 currentSpawnPoint;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetSpawnPoint(Vector3 position)
    {
        currentSpawnPoint = position;
        Debug.Log("Spawn point set at: " + currentSpawnPoint);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            TeleportToSpawn();
        }
    }

    public void TeleportToSpawn()
    {
        if (currentSpawnPoint == Vector3.zero)
        {
            Debug.LogWarning("No spawn point set.");
            return;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            CharacterController controller = player.GetComponent<CharacterController>();
            if (controller != null)
            {
                controller.enabled = false;
            }

            player.transform.position = currentSpawnPoint;

            if (controller != null)
            {
                controller.enabled = true;
            }

            Debug.Log("Teleported to spawn point: " + currentSpawnPoint);
        }
        else
        {
            Debug.LogWarning("Player not found.");
        }
    }
}
