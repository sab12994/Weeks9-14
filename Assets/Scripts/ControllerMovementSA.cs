using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerMovementSA : MonoBehaviour
{
    public float speed = 5;
    public Vector2 movement;
    public GameObject blur;
    public GameObject healthbar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blur.SetActive(false);
        healthbar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movement * speed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {

    }

    public void SlowMe()
    {
        float s = 0.6f;
        speed = speed * s;
    }

    public void HurtMe()
    {
        healthbar.SetActive(true);
    }

    public void BlurMe()
    {
        blur.SetActive(true);
    }

    public void HealMe()
    {
        blur.SetActive(false);
        healthbar.SetActive(true);
        speed = 5;

    }
}
