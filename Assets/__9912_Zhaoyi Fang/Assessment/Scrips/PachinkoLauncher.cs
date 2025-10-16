using UnityEngine;

public class PachinkoLauncher : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
        public Rigidbody subject;
        public Transform launchPoint;
        public float launchForce;
        public float launchForceDelta;

        void Start(){}

    // Update is called once per frame
    private void Update()
    {
        launchForce = launchForce + launchForceDelta * Time.deltaTime;
    }
    private void OnTriggerStay(Collider other)
    {
        if(subject == null)
        {
           subject = other.GetComponent<Rigidbody>();
        }
    }
    public void Launch()
   {
    if (subject != null)
    {
      subject.transform.position = launchPoint.position;
      subject.linearVelocity = Vector3.zero;
      subject.AddForce(launchPoint.forward * launchForce);
      subject = null;
     }
   }
}
