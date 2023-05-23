using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Player player;

    private float horizontal, vertical;

    private Vector2 lookTarget;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        lookTarget = Input.mousePosition;

        if(Input.GetMouseButtonDown(0))
        {
            player.Shoot(Vector3.zero, 0);
        }
    }

    private void FixedUpdate()
    {
        {
            player.Move(new Vector2(horizontal, vertical), lookTarget);
        }
    }
}
