using UnityEngine;

public class Spin1 : MonoBehaviour
{
   public float yspeed = 50f; 
   void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform. Rotate(0, yspeed * Time.deltaTime, 0);
    
    }

    public void Stop()
    { 
        yspeed = 0;
    }

    public void SetSpeed(float newSpeed)
    {
        yspeed = newSpeed;
    }
}
