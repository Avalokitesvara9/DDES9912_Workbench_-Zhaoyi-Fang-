using UnityEngine;

public class WaterWheelRotation : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public enum Axis { Right, Up, Forward }
    public Axis localAxis = Axis.Up; // 水车常用 Right 或 Forward

    void Update()
    {
        Vector3 axis = localAxis == Axis.Right ? Vector3.right :
                       localAxis == Axis.Up    ? Vector3.up    :
                                                 Vector3.forward;
        transform.Rotate(axis * rotationSpeed * Time.deltaTime, Space.Self);
    }
}