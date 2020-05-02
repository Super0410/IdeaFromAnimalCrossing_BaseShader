using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10;
    private PlayerMovement movement;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        movement.Init();
    }

    private void Update()
    {
        movement.Move(moveSpeed);
        movement.LookAt(Input.mousePosition);
    }
}
