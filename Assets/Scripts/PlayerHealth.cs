using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public TMP_Text healthText;
    public CameraShake cameraShake;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateUI();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0) currentHealth = 0;

        UpdateUI();

        if (cameraShake != null)
            cameraShake.StartCoroutine(cameraShake.Shake(0.2f, 0.3f));

        if (currentHealth == 0)
        {
            Time.timeScale = 0f;
        }
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        Time.timeScale = 1f;
        UpdateUI();
    }

    void UpdateUI()
    {
        healthText.text = "Health: " + currentHealth;

        if (currentHealth > 60)
            healthText.color = Color.green;
        else if (currentHealth > 30)
            healthText.color = Color.yellow;
        else
            healthText.color = Color.red;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            TakeDamage(10);
        }
    }
}