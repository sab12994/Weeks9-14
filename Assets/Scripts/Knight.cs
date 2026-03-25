using UnityEngine;

public class Knight : MonoBehaviour
{
    public AudioSource SFX;
    public Transform start;
    public Transform end;
    public float t;
    public AnimationCurve curve;
    public float x;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position +=(Vector3)movement * speed * Time.deltaTime;

        t += Time.deltaTime;
        if(t > 1)
        {
            t = 0;
        }

        transform.position = Vector2.Lerp(start.position, end.position, t); 
        x = curve.Evaluate(t);
    }

    public void Footstep()
    {
        //Debug.Log("Step!");
        SFX.Play();
    }
}
