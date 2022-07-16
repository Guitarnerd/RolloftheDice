using UnityEngine;

public class PlayerHealth : MonoBehaviour

{
    public float maxHealth;
    private float currentHealth;


    //Sets health to MaxHealth at start of frame
    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("Current health is " + currentHealth);
    }



    //Changes health and executes death if health == 0
    public void healthChange(float change)
    {
        if (currentHealth != 0)
        {
            currentHealth = currentHealth + change;

            if (currentHealth > 20)
            {
                currentHealth = maxHealth;
            }

            Debug.Log("Health is currently " + currentHealth);

        }
        else
        {
            dead();
        }

    }

    //the "You suck" method
    void dead()
    {
        Debug.Log("No more health left." + currentHealth);
    }

}