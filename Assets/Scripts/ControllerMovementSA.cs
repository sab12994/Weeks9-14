using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerMovementSA : MonoBehaviour
{
    public float speed = 5;
    public Vector2 movement;
    public GameObject blur;
    public GameObject healthbar;    

    
    void Start()
    {
        //make these turned off when the game starts
        blur.SetActive(false);
        healthbar.SetActive(false);        
    }

    
    void Update()
    {
        //movement!
        transform.position += (Vector3)movement * speed * Time.deltaTime;
    }

    //for the player input
    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
        
    //functions for buttons
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
        healthbar.SetActive(false);
        speed = 5;
        GetComponent<SpriteRenderer>().color = Color.white; //colors the player back to white
    }

    public void PoisonMe()
    {
        float s = 0.3f;
        speed = speed * s;
        GetComponent<SpriteRenderer>().color = Color.green; //colors the player green, to make him look "sick"
    }
}
