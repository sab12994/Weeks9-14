using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public SpriteRenderer sensorBox;
    public bool isInBox = false;
    public UnityEvent OnEnter;
    public UnityEvent OnExit;

    //this script is for staff that I'm not sure where to put in. Might not use it at all

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (sensorBox.bounds.Contains(transform.position) == true)
        {
            //Y: player tripped the sensor 
            if (isInBox == true)
            {
                //don't do anything yet
            }
            else
            {
                //player just entered the sensor 
                isInBox = true;
                Debug.Log("entered the sensor");
                OnEnter.Invoke();
            }
        }
        else
        {
            if (isInBox == true)
            {
                //just left the hazard
                isInBox = false;
                Debug.Log("excited the sensor");
                OnExit.Invoke();
            }
            else
            {
                //we are outside of a sensor, don't do anything yet
            }
        }
    }
}
