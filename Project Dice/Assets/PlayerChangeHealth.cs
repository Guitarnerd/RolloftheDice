using UnityEngine;

public class PlayerHealthChange : MonoBehaviour
{
    private PlayerHealth playerHealth;


    //Negative number is damage
    //Positive number is health
    void updateHealth(int change)
    {
        playerHealth.healthChange(change);
    }

}
