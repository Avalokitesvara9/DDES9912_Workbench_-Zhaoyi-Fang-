using UnityEngine;

public class ColorBlink : MonoBehaviour
{
   [Header("Animation Timing Settings")]
   public float blinkClock;
   public float clockSpeed = 1;
   public float maxClock;
   public AnimationCurve blinkCurve;

   [Header("Colour Setting")]
   public Color currentColour;
   public Color startColour;
   public Color endColour;

   [Header("System System Setting (usually dont touch)")]
   public float lerpValue;
   public Material myMaterial;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myMaterial = GetComponent<MeshRenderer>().material;
        currentColour = myMaterial.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (blinkClock > maxClock)
            blinkClock = 0;
        lerpValue = blinkCurve.Evaluate(blinkClock);
        currentColour = Color.Lerp(startColour, endColour, lerpValue);

        myMaterial.SetColor("_EmissionColor", currentColour);
        myMaterial.color = currentColour;

        blinkClock += Time.deltaTime * clockSpeed;
    }

    public void SetSpeed(float newSpeed)
    {
        clockSpeed = newSpeed;
    }
}
