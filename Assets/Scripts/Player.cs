using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player : Photon.MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;

    public DialogueUI DialogueUI => dialogueUI;

    public IIteractable Interactable { get; set; }
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (dialogueUI.IsOpen) return;
        }
        catch (Exception err)
        {

        }
        horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump")) 
        {
            jump = true;
            animator.SetBool("IsJump", true);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Interactable?.Interact(this);
        }

    }
    public void OnLanding()
    {
        animator.SetBool("IsJump", false);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
