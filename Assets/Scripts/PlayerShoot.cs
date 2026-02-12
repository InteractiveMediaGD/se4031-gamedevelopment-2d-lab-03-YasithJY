using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectilePrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Get mouse position in world space
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;

            // Calculate direction from player to mouse click
            Vector2 direction = (mousePos - transform.position).normalized;

            // Calculate rotation angle so the projectile faces the mouse
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0f, 0f, angle);

            GameObject proj = Instantiate(projectilePrefab, transform.position, rotation);
            proj.GetComponent<Projectile>().SetDirection(direction);
        }
    }
}