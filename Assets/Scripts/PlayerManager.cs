using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Animator playerAnimator;
    private Rigidbody2D playerRigidBody;
    public float movingSpeed = 5f;
    public string LastAreaTransitionUsed;
    public Transform startPosition;
    private Vector2 minBound;
    private Vector2 maxBound;

    public bool canMove = true;
    public bool dialogOpen, MenuOpen;

    public static PlayerManager instance;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        playerAnimator = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody2D>();

        LastAreaTransitionUsed = "Start";
        GetStartingPosition();
    }

    public void GetStartingPosition()
    {
        transform.position = startPosition.position;
    }

    void Update()
    {
        HandlePlayerInput();
        HandlePlayerAnimations();
        MaintainPlayerBoundaries();
    }

    private void MaintainPlayerBoundaries()
    {
        this.transform.position = new Vector3(Mathf.Clamp(transform.position.x, minBound.x, maxBound.x),
            Mathf.Clamp(transform.position.y, minBound.y, maxBound.y),
            this.transform.position.z);
    }

    public void SetPlayerBoundaries(Vector2 min, Vector2 max)
    {
        minBound = min + new Vector2(0.5f,0.7f);
        maxBound = max + new Vector2(-0.5f, -0.7f);
    }

    public void HandlePlayerInput()
    {
        if (canMove) 
        {
            playerRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * movingSpeed;
        } else
        {
            playerRigidBody.velocity = Vector2.zero;
        }
    }

    public void HandlePlayerAnimations()
    {
        if (canMove)
        {
            playerAnimator.SetFloat("MoveX", playerRigidBody.velocity.x);
            playerAnimator.SetFloat("MoveY", playerRigidBody.velocity.y);

            if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 ||
                Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
            {
                playerAnimator.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
                playerAnimator.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));
            }
        }
    }

    public void CanPlayerMove()
    {
        if(MenuOpen || dialogOpen)
        {
            PlayerManager.instance.canMove = false;
        } else
        {
            PlayerManager.instance.canMove = true;
        }
    }

}
