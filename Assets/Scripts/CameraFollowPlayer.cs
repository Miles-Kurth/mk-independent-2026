using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.1f;
    public Vector3 velocity;
    
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(target.position.x, target.position.y, -5);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
        
        /*Vector3 targetPosition = target.TransformPoint(target.position.x, target.position.y, -10);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);*/
        
        transform.position = new Vector3(target.position.x, target.position.y, -10); //WORKING
        
        transform.rotation = target.rotation;
    }
}
