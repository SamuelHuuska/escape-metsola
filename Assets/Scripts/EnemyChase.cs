using UnityEngine;
using UnityEngine.SceneManagement; // Include this for scene management

public class EnemyChase : MonoBehaviour
{
    public Transform player; // Reference to the player
    public float speed = 3.0f; // Speed of the enemy
    public float chaseDistance = 10.0f; // Distance at which the enemy starts chasing
    public float stoppingDistance = 1.5f; // How close the enemy will get to the player
    public LayerMask obstacleMask; // LayerMask to identify obstacles

    private PlayerMovement playerMovement; // Reference to the PlayerMovement script
    private CharacterController characterController; // CharacterController for collision detection

    private void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>(); // Get the PlayerMovement component
        characterController = GetComponent<CharacterController>(); // Get the CharacterController component
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        // If the player is within the chase distance
        if (distance < chaseDistance)
        {
            // Check if the player is crouching
            if (playerMovement.IsCrouching())
            {
                return; // If crouching, do not chase
            }

            Vector3 direction = (player.position - transform.position).normalized; // Get the direction to the player

            // Check if the enemy is within the stopping distance
            if (distance > stoppingDistance)
            {
                // Raycast to check for obstacles
                if (!Physics.Raycast(transform.position, direction, distance, obstacleMask))
                {
                    // Move towards the player if there's no obstacle
                    characterController.Move(direction * speed * Time.deltaTime);
                }
            }
            else
            {
                // Check for scene change if the enemy is within the stopping distance
                OnTriggerEnter(player.GetComponent<Collider>());
            }

            // Always look at the player
            LookAtPlayer();
        }
    }

    private void LookAtPlayer()
    {
        Vector3 lookDirection = player.position - transform.position;
        lookDirection.y = 0; // Keep the enemy's rotation only on the Y-axis
        Quaternion rotation = Quaternion.LookRotation(lookDirection);

        // Smooth rotation and lock the X-axis
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);

        // Ensure the X rotation is locked
        Vector3 eulerAngles = transform.rotation.eulerAngles;
        eulerAngles.x = -90; // Lock X rotation
        transform.rotation = Quaternion.Euler(eulerAngles);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            // Load the "End" scene when the enemy touches the player
            SceneManager.LoadScene("Main Menu");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
