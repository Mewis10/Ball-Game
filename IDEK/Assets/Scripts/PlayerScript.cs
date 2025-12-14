using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    private PlayerInput input;
    private Vector2 movement;

    private Vector3 direction;

    [Header("Parameters")]

    [SerializeField] private float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = input.actions["Move"].ReadValue<Vector2>();
        direction = new Vector3(movement.x, 0f, movement.y);
        transform.position += direction * speed * Time.deltaTime;
        Debug.Log(movement);
    }
}
