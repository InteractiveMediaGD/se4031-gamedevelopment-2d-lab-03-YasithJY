using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(x, y);

        float currentSpeed = speed + timer * 0.3f;

        transform.Translate(move * currentSpeed * Time.deltaTime);
    }
}   