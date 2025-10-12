using UnityEngine;

[RequireComponent(typeof(Collider))]
public class WaterFlowForce : MonoBehaviour
{
    public enum Axis { Right, Up, Forward }

    public Axis torqueAxis = Axis.Up;   // 你的轴是Y就用Up

    public float torquePerSecond = 100f;

    public float maxSpeedDegPerSec = 40f;

    [Range(0f, 1f)]
    public float brakingRatio = 0.2f;

    public bool affectRootRigidbody = true;

    void Reset()
    {
        var col = GetComponent<Collider>();
        if (col) col.isTrigger = true;
    }

    void OnTriggerStay(Collider other)
    {
        Rigidbody rb = affectRootRigidbody
            ? other.attachedRigidbody ? other.attachedRigidbody.GetComponentInParent<Rigidbody>() : null
            : other.attachedRigidbody;

        if (rb == null) return;

        // 轴向
        Vector3 local = torqueAxis == Axis.Right ? Vector3.right :
                        torqueAxis == Axis.Up    ? Vector3.up :
                                                   Vector3.forward;
        Vector3 worldAxis = rb.transform.TransformDirection(local.normalized);

        // 当前角速度 (rad/s)
        float omega = Vector3.Dot(rb.angularVelocity, worldAxis);
        float maxOmega = maxSpeedDegPerSec * Mathf.Deg2Rad;

        if (Mathf.Abs(omega) < maxOmega)
        {
            // 低于目标 → 加力
            rb.AddTorque(worldAxis * torquePerSecond * Time.deltaTime, ForceMode.Force);
        }
        else
        {
            // 超过目标 → 施加轻微反向扭矩（刹车）
            rb.AddTorque(-Mathf.Sign(omega) * worldAxis * torquePerSecond * brakingRatio * Time.deltaTime, ForceMode.Force);
        }
    }
}