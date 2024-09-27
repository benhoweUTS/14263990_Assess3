using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMovement : MonoBehaviour
{
    private Transform PacPos;
    private Animator pacAnimator;
    [SerializeField] private float speed;
    private Tweener tweener;
    
    //four corner positions
    private Vector3 topLeft = new Vector3(-8, 11, 0);
    private Vector3 topRight = new Vector3(3, 11, 0);
    private Vector3 botRight = new Vector3(3, 7, 0);
    private Vector3 botLeft = new Vector3(-8, 7, 0);
    
    // Start is called before the first frame update
    void Start()
    {
        PacPos = GetComponent<Transform>();
        pacAnimator = GetComponent<Animator>();
        tweener = GetComponent<Tweener>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PacPos.position == topLeft)
        {
            ResetBools();
            pacAnimator.SetBool("walkRight", true);
            tweener.AddTween(PacPos, PacPos.position, topRight, speed);
        } else if (PacPos.position == topRight)
        {

            ResetBools();
            pacAnimator.SetBool("walkDown", true);
            tweener.AddTween(PacPos, PacPos.position, botRight, speed);
        } else if (PacPos.position == botRight)
        {

            ResetBools();
            pacAnimator.SetBool("walkLeft", true);
            tweener.AddTween(PacPos, PacPos.position, botLeft, speed);
        } else if (PacPos.position == botLeft)
        {

            ResetBools();
            pacAnimator.SetBool("walkUp", true);
            tweener.AddTween(PacPos, PacPos.position, topLeft, speed);
        }
        
        
    }

    private void ResetBools()
    {
        foreach (var parameter in pacAnimator.parameters) {
            if (parameter.type == AnimatorControllerParameterType.Bool)
                pacAnimator.SetBool(parameter.name, false);
        }
    }
}
