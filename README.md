[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/6gX06Ox4)
[![Open in Visual Studio Code](https://classroom.github.com/assets/open-in-vscode-2e0aaae1b6195c2367325f4f02e2d04e9abb55f0b24a779b69b11b9e10269abc.svg)](https://classroom.github.com/online_ide?assignment_repo_id=22517410&assignment_repo_type=AssignmentRepo)
# 2D LAB SHEET 02
## Health Packs & Enemy System (Unity 2D)

---

## Objective

To extend the game created in Lab Sheet 01 by adding:

- Health pack objects that restore player health  
- Enemy objects that damage the player  
- Automatic destruction of objects after passing the player  
- Visual distinction between health packs and enemies  

---

## Learning Outcomes

By the end of this lab, students will be able to:

- Create collectible game objects  
- Use collision detection for gameplay logic  
- Modify player health dynamically  
- Create enemies that interact with the player  
- Destroy game objects using scripts  
- Visually differentiate different object types  

---

## Requirements

- Completed Lab Sheet 01 project  
- Unity Editor (2D Core)  
- Visual Studio / VS Code  

---

## Part A — Create Health Pack Object

### Step 1: Create Health Pack Sprite

1. Hierarchy → Right Click → 2D Object → Sprite → Circle  
2. Rename to: HealthPack  
3. Change color to Green  

---

### Step 2: Add Components

Add:

- CircleCollider2D → Is Trigger  
- (Optional) Rigidbody2D → Gravity Scale = 0  

---

### Step 3: Create Script HealthPack.cs

Scripts folder → Create → C# Script → HealthPack  


```csharp
using UnityEngine;

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
        }
    }
}
```
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

```csharp
using UnityEngine;

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

Press Play

Check:

- Player collects health pack → health increases
- Health does not exceed maxHealth
- Enemy reduces player health
- Enemy disappears after collision
- Objects disappear after passing player


