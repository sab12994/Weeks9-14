using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.InputSystem;

public class localMultiplayerController : MonoBehaviour
{
    public Vector2 movementInput;
    public float speed = 5;
    public PlayerInput playerInput;
    public localMultiplayerManager manager;

    //public Transform duckie;

    //Coroutine doTheGrowingCoroutine;
    //Coroutine growTheCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    //public void StartTheTreeGrow()
    //{
    //    if (doTheGrowingCoroutine != null)
    //    {
    //        StopCoroutine(doTheGrowingCoroutine);
    //    }
        
    //    doTheGrowingCoroutine = StartCoroutine(DoTheGrowing());
    //}

    //IEnumerator DoTheGrowing()
    //{
    //    yield return growTheCoroutine = StartCoroutine(GrowDuckie());
    //}


    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movementInput * speed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
       movementInput = context.ReadValue<Vector2>();   
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log("Player" + playerInput.playerIndex + ": Attacking!");
            manager.PlayerAttacking(playerInput);
        }
        
    }

    //IEnumerator GrowDuckie()
    //{        
    //    float t = 0;
    //    while (t < 1)
    //    {
    //        t += Time.deltaTime;
    //        duckie.localScale = Vector2.one * t;
    //        yield return null;
    //    }
    //}
}
