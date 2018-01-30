using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offsetPosition;

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    [SerializeField]
    private bool lookAt = true;
    
    void Start()
    {
    	offsetPosition.x = 20;
    }

    private void LateUpdate()
    {
        Refresh();
    }

    public void Refresh()
    {
    
		if (offsetPosition.x > 3f)
    	{
    		offsetPosition.x -= 0.5f;
    	}
    	
		if (offsetPosition.x <= 3f )
		{
			offsetPosition.x -= 0.15f;
		}
		
		if (offsetPosition.x <= 0.2f )
		{
			offsetPosition.x = 0f;
		}
    	
        float spinangle = Mathf.Clamp(0, 70f, 179f);
        transform.rotation = Quaternion.Euler(spinangle, 0, 0);

        if (target == null)
        {
            Debug.LogWarning("Missing target ref !", this);

            return;
        }

        // compute position
       if (offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition);
            transform.position = Vector3.Lerp(transform.position, target.TransformPoint(offsetPosition), 0.20f);
        }
        else
        {
            transform.position = target.position + offsetPosition;
        }

        // compute rotation
        if (lookAt)
        {
            transform.LookAt(target);
			transform.rotation = Quaternion.Euler (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        else
        {
            transform.rotation = target.rotation;
        }
        
    }
    
}