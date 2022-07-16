using UnityEngine;

public class PlayerHealthChange : MonoBehaviour
{
    private PlayerHealth playerHealth;
    public float change;

    //Negative number is damage
    //Positive number is health
    void updateHealth()
    {
        playerHealth.healthChange(change);
    }

}
