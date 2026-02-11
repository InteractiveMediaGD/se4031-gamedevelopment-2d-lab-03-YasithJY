<<<<<<< HEAD
[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/6gX06Ox4)
[![Open in Visual Studio Code](https://classroom.github.com/assets/open-in-vscode-2e0aaae1b6195c2367325f4f02e2d04e9abb55f0b24a779b69b11b9e10269abc.svg)](https://classroom.github.com/online_ide?assignment_repo_id=22517410&assignment_repo_type=AssignmentRepo)
# 2D LAB SHEET 02
## Health Packs & Enemy System (Unity 2D)
=======
[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/-E4Wzqlo)
[![Open in Visual Studio Code](https://classroom.github.com/assets/open-in-vscode-2e0aaae1b6195c2367325f4f02e2d04e9abb55f0b24a779b69b11b9e10269abc.svg)](https://classroom.github.com/online_ide?assignment_repo_id=22638911&assignment_repo_type=AssignmentRepo)
# 2D LAB SHEET 03
## Projectiles, Speed Increase & Creative Feature (Unity 2D)
>>>>>>> 8bd0f13780e880d92e9e1b4f47ab706d8602a026

---

## Objective

<<<<<<< HEAD
To extend the game created in Lab Sheet 01 by adding:

- Health pack objects that restore player health  
- Enemy objects that damage the player  
- Automatic destruction of objects after passing the player  
- Visual distinction between health packs and enemies  
=======
To extend the existing game by adding:

- Player projectile shooting  
- Enemy destruction using projectiles  
- Score increase when enemies are destroyed  
- Gradual player speed increase over time  
- One simple creative feature  
>>>>>>> 8bd0f13780e880d92e9e1b4f47ab706d8602a026

---

## Learning Outcomes

By the end of this lab, students will be able to:

<<<<<<< HEAD
- Create collectible game objects  
- Use collision detection for gameplay logic  
- Modify player health dynamically  
- Create enemies that interact with the player  
- Destroy game objects using scripts  
- Visually differentiate different object types  
=======
- Create projectile prefabs  
- Instantiate objects using scripts  
- Detect collisions between projectiles and enemies  
- Modify player speed dynamically  
- Increase score through gameplay actions  
- Add a simple creative visual feature  
>>>>>>> 8bd0f13780e880d92e9e1b4f47ab706d8602a026

---

## Requirements

<<<<<<< HEAD
- Completed Lab Sheet 01 project  
=======
- Completed Lab Sheet 01 and Lab Sheet 02 project  
>>>>>>> 8bd0f13780e880d92e9e1b4f47ab706d8602a026
- Unity Editor (2D Core)  
- Visual Studio / VS Code  

---

<<<<<<< HEAD
## Part A — Create Health Pack Object

### Step 1: Create Health Pack Sprite

1. Hierarchy → Right Click → 2D Object → Sprite → Circle  
2. Rename to: HealthPack  
3. Change color to Green  
=======
## Part A — Create Projectile Object  

### Step 1: Create Projectile Sprite

Hierarchy → Right Click → 2D Object → Sprite → Circle  
Rename: Projectile  
Change color to Yellow  
>>>>>>> 8bd0f13780e880d92e9e1b4f47ab706d8602a026

---

### Step 2: Add Components

Add:

- CircleCollider2D → Is Trigger  
<<<<<<< HEAD
- (Optional) Rigidbody2D → Gravity Scale = 0  

---

### Step 3: Create Script HealthPack.cs

Scripts folder → Create → C# Script → HealthPack  
=======
- Rigidbody2D → Gravity Scale = 0  

---

### Step 3: Create Script Projectile.cs

Scripts → Create → C# Script → Projectile  

Paste:

```csharp
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
```

### Step 4: Attach Script

Drag Projectile.cs → onto Projectile

---

## Part B — Player Shooting System  

### Step 1: Create Script PlayerShoot.cs

Scripts → Create → C# Script → PlayerShoot
>>>>>>> 8bd0f13780e880d92e9e1b4f47ab706d8602a026


```csharp
using UnityEngine;

<<<<<<< HEAD
public class HealthPack : MonoBehaviour
{
    public int healAmount = 20;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.currentHealth = Mathf.Min(player.currentHealth + healAmount, player.maxHealth);
            player.SendMessage("UpdateUI");
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
=======
public class PlayerShoot : MonoBehaviour
{
    public GameObject projectilePrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
>>>>>>> 8bd0f13780e880d92e9e1b4f47ab706d8602a026
        }
    }
}
```
<<<<<<< HEAD
### Step 4: Attach Script

Drag HealthPack.cs → onto HealthPack

---

## Part B — Create Enemy Object 

### Step 1: Create Enemy Sprite

Hierarchy → Right Click → 2D Object → Sprite → Square

Rename: Enemy

Change color to Red

---

### Step 2: Add Components

Add:

BoxCollider2D → Is Trigger

(Optional) Rigidbody2D → Gravity Scale = 0

---

### Step 3: Create Script Enemy.cs

Scripts → Create → C# Script → Enemy
=======
### Step 2: Attach Script

Drag PlayerShoot.cs → onto Player

---

### Step 3: Link Projectile Prefab

Drag Projectile from Hierarchy into Project window (to create prefab)

Delete Projectile from scene

Select Player

Drag Projectile prefab into Projectile Prefab field

---

## Part C — Destroy Enemy with Projectile + Score Increase 

Open Enemy.cs and modify:

```csharp
void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Projectile"))
    {
        FindObjectOfType<ScoreManager>().AddScore(5);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

    PlayerHealth player = other.GetComponent<PlayerHealth>();

    if (player != null)
    {
        player.TakeDamage(damage);
        Destroy(gameObject);
    }
}
```
### Tag Projectile

Select Projectile prefab → Tag → Add Tag → create Projectile  
Assign tag to Projectile prefab

---

## Part D — Player Speed Increase Over Time 

Open PlayerMovement.cs

Modify:

```csharp
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
```

## Part E — Creative Feature (Choose ONE)  

### Option 1: Health Text Color Change

Modify PlayerHealth.cs → UpdateUI():

```csharp
if (currentHealth > 60)
    healthText.color = Color.green;
else if (currentHealth > 30)
    healthText.color = Color.yellow;
else
    healthText.color = Color.red;
```
### Option 2: Simple Screen Shake

Create script: CameraShake.cs
>>>>>>> 8bd0f13780e880d92e9e1b4f47ab706d8602a026

```csharp
using UnityEngine;

<<<<<<< HEAD
public class Enemy : MonoBehaviour
{
    public int damage = 20;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}
```
### Step 4: Attach Script

Drag Enemy.cs → onto Enemy

---

## Part C — Simple Spawning

For now:

- Duplicate HealthPack and Enemy objects
- Place them ahead of the player manually in the scene

(Automatic spawning will be covered in later labs.)

---

## Part D — Visual Differentiation Check

Ensure:

| Object     | Color | Shape  |
|------------|-------|--------|
| HealthPack | Green | Circle |
| Enemy      | Red   | Square |

---

## Testing
=======
public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
```

Attach to Main Camera.

## Testing  
>>>>>>> 8bd0f13780e880d92e9e1b4f47ab706d8602a026

Press Play

Check:

<<<<<<< HEAD
- Player collects health pack → health increases
- Health does not exceed maxHealth
- Enemy reduces player health
- Enemy disappears after collision
- Objects disappear after passing player

=======
- Player shoots projectile using left mouse click
- Projectile moves forward
- Enemy is destroyed on projectile hit
- Score increases
- Player speed increases gradually
- Creative feature works
>>>>>>> 8bd0f13780e880d92e9e1b4f47ab706d8602a026

