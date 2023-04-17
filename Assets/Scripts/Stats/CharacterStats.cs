using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private Slider health_slider;
    [SerializeField] private Slider mana_slider;

    [SerializeField] private int maxHealth = 100; // dummy value
    [SerializeField] private int currentHealth { get; set; }
    [SerializeField] private int maxMana = 100; // dummy value
    [SerializeField] private int currentMana { get; set; }

    [SerializeField] private Stat damage;
    [SerializeField] private Stat armor;
    [SerializeField] private Stat magicResist;
    [SerializeField] private Stat speed;

    void Start()
    {
        // Set health slider to maxHealth 
        health_slider.maxValue = maxHealth;
        health_slider.value = maxHealth;

        // Set Mana Slider to maxMana
        mana_slider.maxValue = maxMana;
        mana_slider.value = maxMana;

        currentHealth = maxHealth;
        currentMana = maxMana;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10, 1);
  
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            TakeDamage(20, 2);
        }
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
        health_slider.value -= damage;
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
