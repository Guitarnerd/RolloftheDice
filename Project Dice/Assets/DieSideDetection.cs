using UnityEngine;

public class DieSideDetection : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Key registered");

            readHighPoint();
        }
    }
    //reads the highest point of the Die
    void readHighPoint()
    {
        GameObject[] numbers = GameObject.FindGameObjectsWithTag("Numbers");

        //The number on the die
        int number = 0;
        //the highest position
        float height = 0.0f;

        Debug.Log("Read High Points");


        foreach(GameObject name in numbers)
        { 
            if(name.transform.position.y > height)
            {
                height = name.transform.position.y;
                number = int.Parse(name.name);
            }
        }
        announceSide(number);
    }

    //Action depending on what the number is
    void action() { 
    }

    void announceSide(int Number)
    {
        Debug.Log("" + Number);
    }
}
