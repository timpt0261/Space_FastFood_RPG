using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    //private int maxExperince = 5000;
    private int currentExperiance { get; set; }

    //private int maxHealth = 100; // dummy value
    private int currentHealth { get; set; }
    //private int maxMana = 100; // dummy value
    private int currentMana { get; set; }

    private Stat damage;
    private Stat armor;
    private Stat accuracy;
    private Stat speed;
    private Stat magicResist;


    public void setStats(int exp = 10 , int health = 100, int mana = 20) {

        currentExperiance = exp;
        currentHealth = health;
        currentMana = mana;

    }





    public void TakeDamage (int damage, int type)
    {
        //type 1 = physical, type 2 = magical
        if (type == 1)
        {
            damage -= armor.GetValue();
        }
        else
        {
            damage -= magicResist.GetValue();
        }
        // makes sure damage is 0 at the min and not neg
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;
        if (type == 1)
        {
            Debug.Log(transform.name + " has taken " + damage + " physical damage.");
        }
        else
        {
            Debug.Log(transform.name + " has taken " + damage + " magical damage.");
        }
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
