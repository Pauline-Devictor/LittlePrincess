using UnityEngine;

public class MonsieurFloDetectorScript : MonoBehaviour
{
    public delegate void animerFlo();

    public static event animerFlo animerFloEvent;
    
    // Start is called before the first frame update
    private void Start()
    {
    }


    private void OnTriggerEnter(Collider other)
    {
        animerFloEvent?.Invoke();
    }
    
    private void OnTriggerExit(Collider other)
    {
        animerFloEvent?.Invoke();
    }
}