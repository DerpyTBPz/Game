using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamera : MonoBehaviour
{

    private Transform playerTransform;
    private string playerTag;
    public int constSpeed;
    private float movingSpeed; 
    Vector3 mousePosition;


    private void Awake()
    {
        if (this.playerTransform == null)
        {            
            this.playerTag = "Player";

            this.playerTransform = GameObject.FindGameObjectWithTag(this.playerTag).transform;
        }    

        mousePosition = Input.mousePosition; 
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);       

        this.transform.position = new Vector3()
        {
            x = this.playerTransform.position.x,
            y = this.playerTransform.position.y,
            z = this.playerTransform.position.z - 10,
        };
    }
    
    private void Update() 
    {
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        if (this.playerTransform)
        {           
           
            Vector3 target = new Vector3()
            {
                x = this.playerTransform.position.x,
                y = this.playerTransform.position.y,
                z = this.playerTransform.position.z - 10,
            };

            Vector3 pos = Vector3.Lerp(this.transform.position, target, this.movingSpeed = Time.deltaTime + constSpeed/100);

            this.transform.position = pos;
        }
        
    }

}
