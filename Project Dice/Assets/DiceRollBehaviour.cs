using UnityEngine;

public class DiceRollBehaviour : MonoBehaviour
{
    public Rigidbody dieRoller;
    private Vector3 randomLaunch(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        var z = Random.Range(min, max);
        return new Vector3(x, y, z);
    }
    public void RollForEffect()
    {
        dieRoller.velocity = randomLaunch(15f, 25f);

    }
}
