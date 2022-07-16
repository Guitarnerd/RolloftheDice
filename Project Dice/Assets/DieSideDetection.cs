using UnityEngine;

public class DieSideDetection : MonoBehaviour
{

    //Cooldown in seconds for when next ability will be chosen
    public float cooldown = 60;


    //No need to change the currentTimer
    private float currentTimer = 0;


    public Rigidbody player;

    // Update is called once per frame
    void FixedUpdate()
    {
        
       
        if (Time.time > currentTimer)
        {
            currentTimer = Time.time + cooldown;
            action();
        }

    }


    //What happens once the timer is completed
    void action()
    {
        //the animations will be above readHighPoint


        readHighPoint();


        //the setting of Dice states will be below readHighPoint
    }


    //reads the highest point of the Die
    void readHighPoint()
    {
        GameObject[] numbers = GameObject.FindGameObjectsWithTag("Numbers");

        //saves the current die number that is the same as highest position
        int number = 0;

        //saves the highest position
        float height = 0.0f;



        foreach(GameObject name in numbers)
        { 
            if(name.transform.position.y > height)
            {
                height = name.transform.position.y;
                number = int.Parse(name.name);
            }
        }
        roll(number);
    }

    //Checks the number and sends to the different states
    public void roll(int number)
    {
        if (number == 1)
            criticalFail();

        if (number == 2 || number == 3 || number == 4 || number == 5 || number == 6 || number == 7)
            ice();

        if (number == 8 || number == 9 || number == 10 || number == 11 || number == 12 || number == 13)
            fire();


        if (number == 14 || number == 15 || number == 16 || number == 17 || number == 18 || number == 19)
            electricity();

        if (number == 20)
            criticalSuccess();

    }
    void criticalFail()
    {
        Debug.Log("FAIL");
    }
    void ice()
    {
        Debug.Log("Ice");

    }
    void fire()
    {
        Debug.Log("Fire");

    }
    void electricity()
    {
        Debug.Log("elec");

    }
    void criticalSuccess()
    {
        Debug.Log("Win");

    }
}


