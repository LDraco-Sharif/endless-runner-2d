using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 1;

    [SerializeField]
    float leftPositionLimit = -6;

    [SerializeField]
    float rightPositionLimit = 6;

    [SerializeField]
    float smoothTime = 10;

    public InputAction moveAction;

    float velocity = 0;

    float horizontalInput = 0;

    bool shouldPlayerMove = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.movePlayer();
    }

    private void FixedUpdate()
    {
        if (shouldPlayerMove) {
            float rawVelocity = horizontalInput * speed;

            velocity = Mathf.Lerp(velocity, rawVelocity, Time.deltaTime * smoothTime);

            transform.Translate(velocity * Time.deltaTime, 0, 0);
            if (transform.position.x > rightPositionLimit && horizontalInput > 0)
            {
                transform.position = new Vector3(rightPositionLimit, transform.position.y, transform.position.z);
                return;
            }

            if (transform.position.x < leftPositionLimit && horizontalInput < 0)
            {
                transform.position = new Vector3(leftPositionLimit, transform.position.y, transform.position.z);
                return;
            }
        }
    }

    private void movePlayer()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        
        horizontalInput = Mathf.Clamp(moveInput.x, - 1, 1);
        velocity = 0;

        if (transform.position.x > rightPositionLimit && horizontalInput > 0)
        {
            shouldPlayerMove = false;
            return;
        }

        if (transform.position.x < leftPositionLimit && horizontalInput < 0)
        {
            shouldPlayerMove = false;
            return;
        }

        shouldPlayerMove = true;
    }


}
