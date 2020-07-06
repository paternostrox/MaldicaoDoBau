using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    public float speed;

    IInteractable currentInteractable;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        TryMove();
        TryInteraction();
    }

    private void TryMove()
    {
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        movement = movement.normalized * speed;

        rb.velocity = movement;
        animator.SetFloat("movement", movement.magnitude);
    }

    private void TryInteraction()
    {
        if (currentInteractable != null && currentInteractable.NeedsButton)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                currentInteractable.Interact();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        currentInteractable = collider.GetComponent<IInteractable>();
        if(!currentInteractable.NeedsButton)
        {
            currentInteractable.Interact();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentInteractable = null;
    }
}
