using UnityEngine;

public class DieSideDetection : MonoBehaviour
{

    //Cooldown in seconds for when next ability will be chosen
    public float cooldown = 60f;


    //No need to change the currentTimer
    private float currentTimer = 0;


    public Rigidbody player;

    public GameObject failAura;
    public GameObject iceAura;
    public GameObject fireAura;
    public GameObject elecAura;
    public GameObject winAura;


    public float floatHeightForElec = .13f;
    public float floatheightForWIN = .2f;
    private Vector3 startPosition;


    

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Time.time > currentTimer)
        {
            resetAffects();
            currentTimer = Time.time + cooldown;
            action();
        }
        if (Input.GetKey(KeyCode.Mouse0) && elec)
        {
            startPosition = player.position;
            player.transform.position = new Vector3(startPosition.x,startPosition.y+ floatHeightForElec, startPosition.z);
        }
        if(Input.GetKey(KeyCode.Mouse0) && winBool)
        {
            startPosition = player.position;
            player.transform.position = new Vector3(startPosition.x, startPosition.y + floatheightForWIN, startPosition.z);
        }
        //if (Input.GetButton("space") && winBool)
        

        

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

    private bool failBool;
    private bool iceBool;
    private bool fireBool;
    private bool elec;
    private bool winBool;
    void resetAffects()
    {
        if (failBool)
        {
            criticalFail();
            return;
        }
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
        if (winBool)
        {
            //RESET win
            criticalSuccess();
            return;
        }
            
    }

    //All Crit fail stuff
    void criticalFail()
    {
        if (!failBool)
        {
            failBool = true;
            failAura.SetActive(true);
            player.velocity = randomLaunch(2f, maxFail);
        } else
        {
            failAura.SetActive(false);
            failBool = false;
        }
        
         
    }

    public float maxFail;
    private Vector3 randomLaunch(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        var z = Random.Range(min, max);
        return new Vector3(x, y, z);
    }


    
    public SphereCollider iceCollide;
    void ice()
    {
        if (!iceBool)
        {
            iceCollide.enabled=true;
            iceBool = true;
            iceAura.SetActive(true);
            
           
            
        } else
        {
            iceCollide.enabled = false;
            iceBool = false;
            iceAura.SetActive(false);
        }

    }

    public bool destroyWithFire;
    void fire()
    {
        if (!fireBool)
        {
            destroyWithFire = true;
            fireAura.SetActive(true);
            fireBool = true;
            
        } else
        {
            destroyWithFire = false;
            fireAura.SetActive(false);
            fireBool = false;
        }

    }


    void electricity()
    {
        if (!elec)
        {
            elecAura.SetActive(true);
            elec = true;
           
        } else
        {
            elecAura.SetActive(false);
            elec = false;
        }
    }


    void criticalSuccess()
    {
        if (!winBool)
        {
            winBool = true;
            winAura.SetActive(true);
            

        } else
        {
            winBool = false;
            winAura.SetActive(false);
        }
    }

   
   
}


