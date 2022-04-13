using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float movementSpeed = 5f;
    private Rigidbody2D rbody;
    private Animator anim;
    string currentState;
    const string TOMOKO_sWALK = "Tomoko_sWalk";
    const string TOMOKO_wWALK = "Tomoko_wWalk";
    const string TOMOKO_aWALK = "Tomoko_aWalk";
    const string TOMOKO_dWALK = "Tomoko_dWalk";

    private void Awake() 
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate() 
    {
        Vector2 currentPos = rbody.position;
        float horisontalInput = Input.GetAxis("Horizontal");
        float verticallInput = Input.GetAxis("Vertical");
        Vector2 inputVector = new Vector2(horisontalInput,verticallInput);
        inputVector = Vector2.ClampMagnitude(inputVector,1);
        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        rbody.MovePosition(newPos);

        if(horisontalInput > 0)
        {
            ChangeAnimationState(TOMOKO_dWALK);
        }
        if(horisontalInput < 0)
        {
            ChangeAnimationState(TOMOKO_aWALK);
        }
        if(verticallInput > 0)
        {
            ChangeAnimationState(TOMOKO_wWALK);
        }
        if(verticallInput < 0)
        {
            ChangeAnimationState(TOMOKO_sWALK);
        }
    }

    private void ChangeAnimationState(string newState) 
    {
         if(currentState == newState) return;

         anim.Play(newState);

         currentState = newState;
    }
}
