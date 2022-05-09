using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputManagerSO input;

    void Update()
    {

    input.horizontalValue = Input.GetAxisRaw("Horizontal");
    
    input.verticalValue = Input.GetAxisRaw("Vertical");
    input.verticalDown = Input.GetButtonDown("Vertical");    
    
    input.longJumpDown = Input.GetButtonDown("Jump");
    input.backFlipJumpDown = Input.GetKeyDown(KeyCode.Backspace);

    input.fireDown = Input.GetKeyDown(KeyCode.G);

    PowerInput();

    }

    public void PowerInput()
    {
        bool lessPowerKey = Input.GetKey(KeyCode.Q);
        bool morePowerKey = Input.GetKey(KeyCode.E);

        bool lessPowerDown = Input.GetKeyDown(KeyCode.Q);
        bool morePowerDown = Input.GetKeyDown(KeyCode.E);

        if(lessPowerDown || morePowerDown)
        {
            input.powerDown = true;
        }else{
            input.powerDown = false;
        }

        if (lessPowerKey)
        {
            input.powerValue = -1f ;
        }
        else if(morePowerKey)
        {
            input.powerValue = 1f ;
        }
        else
        {
            input.powerValue = 0f;
        }

    }
}
