using UnityEngine;

public class SpinSet : MonoBehaviour
{
    public float ySpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, ySpeed * Time.deltaTime, 0);
    }

public void SetSpeed(float newSpeed)
{
    ySpeed = newSpeed;
}
public void Stop()
{
    ySpeed = 0;
}
}
