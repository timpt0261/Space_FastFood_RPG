using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100; // dummy value
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat armor;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage (int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;
        Debug.Log(transform.name + " has taken " + damage + " damage.");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        // die for player and enemies
        // This is meant to be overwritten
        Debug.Log(transform.name + " has died.");
    }
}
