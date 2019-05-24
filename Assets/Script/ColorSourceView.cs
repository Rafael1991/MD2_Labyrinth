using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class ColorSourceView : MonoBehaviour
{
    public GameObject colorManager;
   // private ColorSourceManager _ColorManager;
    private KinectV2 kinect;
    
    void Start ()
    {
        gameObject.GetComponent<Renderer>().material.SetTextureScale("_MainTex", new Vector2(-1, 1));
    }
    
    void Update()
    {
        if (colorManager == null)
        {
            return;
        }
        
        kinect = KinectV2.GetComponent<KinectV2>();
        if (kinect == null)
        {
            return;
        }
        
        gameObject.GetComponent<Renderer>().material.mainTexture = kinect.GetColorTexture();
    }
}
