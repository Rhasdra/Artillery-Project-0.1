using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
public characterStats characterStats;
public TeamSO characterTeam;

[Header("Must Drag")]
[SerializeField] private InputManagerSO _input;
[SerializeField] private Rigidbody2D _characterRB;
[SerializeField] private Transform _raycastSpawnLeft;
[SerializeField] private Transform _raycastSpawnRight;


private RaycastHit2D _rayLeft;
private RaycastHit2D _rayRight;
private RaycastHit2D _rayMiddle;
[SerializeField] private float _rayDistance = 2f;

public bool canMove;
public bool isJumping;
public bool isGrounded;
public bool isMyTurn = false;

///// EVENTS /////
public delegate void CharacterEndTurn();
public static event CharacterEndTurn CharacterEndTurnEvent;

void Awake() 
{

}

private void Start() {
            
    int[] flip = {-1,1};
    int randomFlip = (int)Random.Range(0f,flip.Length);
    transform.localScale = new Vector3 (flip[randomFlip], 1f, 1f);

    //isMyTurn = true;
}

void FixedUpdate()
{
    CharacterTilt();
}

//////////////////////////////
//// Methods to be called ////
/////////////////////////////

public void CharacterTilt() 
{      
     //Cast Raycasts
      _rayLeft = Physics2D.Raycast (_raycastSpawnLeft.position , -Vector3.up , 5f, LayerMask.GetMask("Terrain"));
      _rayRight = Physics2D.Raycast (_raycastSpawnRight.position , -Vector3.up, 5f, LayerMask.GetMask("Terrain"));
    
    if(canMove)
    {
     //Rotate player according to terrain
     transform.up = Vector2.Lerp (_rayLeft.normal , _rayRight.normal , 0.5f);

    }
}

public void CharacterMove()
{
    //Flip player if going left
    if (_input.horizontalValue != 0)
    {
        CharacterFlip();
    }

    //Move player
    if (canMove == true)
    {
    transform.Translate (Vector3.right * (_input.horizontalValue * characterStats.movementSpeed * Time.deltaTime));
    }
}

public void CharacterFlip()
{
        transform.localScale = new Vector3 (_input.horizontalValue, 1f, 1f);
}

public void LongJump()
{
    canMove = false;
    _characterRB.velocity = new Vector2 (transform.localScale.x * characterStats.longJumpForce, characterStats.longJumpForce);
}

public void BackflipJump()
{    
    canMove = false;
    _characterRB.velocity = new Vector2 (transform.localScale.x * characterStats.backFlipJumpForceX, characterStats.backFlipJumpForceY);
    StartCoroutine("BackFlip");
}

IEnumerator BackFlip()
{
    float startRotation = transform.rotation.eulerAngles.z;
   
   for (int i = 0; i <= 60f; i++)
   {
       transform.rotation = Quaternion.Euler ( 0f, 0f, startRotation + (i * 6f * transform.localScale.x));

       if(canMove)
       {
           StopCoroutine("BackFlip");
       }

       yield return new WaitForSeconds(1f/60f);
   }
}

public void CheckGroundBeneath()
{
    _rayMiddle = Physics2D.Raycast (transform.position, -Vector3.up, _rayDistance, LayerMask.GetMask("Terrain"));
    _rayLeft = Physics2D.Raycast (_raycastSpawnLeft.position , -Vector3.up , _rayDistance, LayerMask.GetMask("Terrain"));
    _rayRight = Physics2D.Raycast (_raycastSpawnRight.position , -Vector3.up, _rayDistance, LayerMask.GetMask("Terrain"));

    if (_rayMiddle || _rayLeft || _rayRight)
    {
        isGrounded = true;
    } 
    else
    {
        isGrounded = false;
    }
}

public void CheckVerticalVelocity()
{
    if( Mathf.Abs(_characterRB.velocity.y) < 1.5f)
    {
        isJumping = false;
    }
    else
    {
        isJumping = true;
    }
}

public void CheckIfCanMove()
{
    CheckGroundBeneath();
    CheckVerticalVelocity();

    if(isGrounded==true && isJumping==false)
    {
        canMove = true;
    }else
    {
        canMove = false;
    }
}

public void CharacterEndTurnMethod()
{
    CharacterEndTurnEvent();
}
}