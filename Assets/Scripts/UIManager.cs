using TMPro;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    //this script is for staff that I'm not sure where to put in. Might not use it at all

    public SpriteRenderer sensorBox;
    public bool isInBox = false;    
    public GameObject description;
    
    
    
    void Start()
    {
        description.SetActive(false);  //turn off the text from the beginning
    }

   
    void Update()
    {
        //made the sensor box
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
                description.SetActive(true);                
            }
        }
        else
        {
            if (isInBox == true)
            {
                //just left the sensor
                isInBox = false;
                Debug.Log("excited the sensor");
                description.SetActive(false);                
            }
            else
            {
                //don't do anything yet
            }
        }
    }
}
