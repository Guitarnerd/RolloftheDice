using UnityEngine;

public class DieSideDetection : MonoBehaviour
{

    //Cooldown in seconds for when next ability will be chosen
    public float cooldown = 60f;


    //No need to change the currentTimer
    private float currentTimer = 0;


    public Rigidbody player;

    // Update is called once per frame
    void FixedUpdate()
    {       
        if (Time.time > currentTimer)
        {
            resetAffects();
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


    private bool iceBool;
    private bool fireBool;
    private bool elec;
    private bool win;
    void resetAffects()
    {

        if (iceBool)
        {
            //RESET ice
            ice();
            return;
        }
        if (fireBool)
        {
            //RESET fire
            fire();
            return;
        }
        if (elec)
        {
            //RESET elec
            electricity();
            return;
        }
        if (win)
        {
            //RESET win
            criticalSuccess();
            return;
        }
            
    }


    //All Crit fail stuff
    void criticalFail()
    {
         
            player.velocity = randomLaunch(2f, maxFail);
         
    }

    public float maxFail;
    private Vector3 randomLaunch(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        var z = Random.Range(min, max);
        return new Vector3(x, y, z);
    }











    public float playerMassWithIce = .85f;
    void ice()
    {
        if (!iceBool)
        {
            iceBool = true;
            Debug.Log("Ice");

            player.mass = playerMassWithIce;
        } else
        {
            player.mass = 1f;
            iceBool = false;
        }

    }
    void fire()
    {
        if (!fireBool)
        {
            fireBool = true;
            Debug.Log("Fire");
        } else
        {
            fireBool = false;
        }

    }
    void electricity()
    {
        if (!elec)
        {
            elec = true;
            Debug.Log("elec");
        } else
        {
            elec = false;
        }
    }







    public float floatHeight;
    public float floatTime;
    private Vector3 startPosition;
    public Vector3 tempPosistion;
    private bool floating;
    private float startFloat = Time.time;

    void criticalSuccess()
    {

        tempPosistion = new Vector3(0, floatHeight, 0);
        startPosition = player.position;

        startPosition = startPosition + tempPosistion;

        if (!floating)
        {
            
            player.transform.position = startPosition;
            floating = true;

            if((Time.time - startFloat)> 5)
            {

            }
        }
        Debug.Log("Win");
        
    }

   
   
}


