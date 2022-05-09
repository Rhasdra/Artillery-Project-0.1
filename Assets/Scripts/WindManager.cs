using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindManager : MonoBehaviour
{
    float[] angles = {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};
    float[] power = {0, 1, 2, 5, 10};
    AreaEffector2D areaEffector;

    //This one goes to the Wind UI to display the stars
    public int randomPower;

    void Awake()
    {
        areaEffector = GetComponent<AreaEffector2D>();
        RandomizeWindAngle();
        RandomizeWindPower();
    }

    public void RandomizeWindAngle()
    {
        int randomAngle = Random.Range(0, angles.Length);

        while (areaEffector.forceAngle == angles[randomAngle])
        {
            randomAngle = Random.Range(0, angles.Length);
        }

        areaEffector.forceAngle = angles[randomAngle] * 22.5f;
    }

    public void RandomizeWindPower()
    {
        randomPower = Random.Range(0, power.Length);

        while (areaEffector.forceMagnitude == power[randomPower])
        {
            randomPower = Random.Range(0, power.Length);
        }
        
        areaEffector.forceMagnitude = power[randomPower];
    }
}
