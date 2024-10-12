using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player; // Reference to the player
    public float speed = 3.0f; // Speed of the enemy
    public float chaseDistance = 10.0f; // Distance at which the enemy starts chasing
    public float stoppingDistance = 1.5f; // How close the enemy will get to the player
    public LayerMask obstacleMask; // LayerMask to identify obstacles

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        // If the player is within the chase distance
        if (distance < chaseDistance)
        {
            Vector3 direction = (player.position - transform.position).normalized; // Get the direction to the player

            // Check if the enemy is within the stopping distance
            if (distance > stoppingDistance)
            {
                // Raycast to check for obstacles
                if (!Physics.Raycast(transform.position, direction, distance, obstacleMask))
                {
                    // Move towards the player if there's no obstacle
                    transform.position += direction * speed * Time.deltaTime;
                }
                else
                {
                    // Optional: Logic when blocked, e.g., idle or patrol
                    // You can implement more sophisticated behavior here
                }
            }
        }
    }
}
