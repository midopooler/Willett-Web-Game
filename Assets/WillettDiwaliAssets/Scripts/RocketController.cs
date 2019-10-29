using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{

    Rigidbody2D Rb;

    bool movebody = false;
    float Speed = 3f;


    GameObject TargetPoint;

    //[SerializeField]
    //Transform LerpPoint;

    Vector3 TargetPosAtLaunch;
    Vector3 TargetAtMouse;
   // GameObject SceneCamera;
    


    void Start()
    {
        Rb = transform.GetComponent<Rigidbody2D>();

        TargetPoint = GameObject.Find("TargetPoint");

        Screen.SetResolution(800, 600, true); 

        //SceneCamera = GameObject.Find("SceneCamera");
    }

    
    void Update()
    {
        //Debug.Log(Screen.currentResolution.height);s
        Vector3 MousePos = new Vector3(Input.mousePosition.x,0 , 0f);
       // float mousePos = Input.mousePosition.x;
        TargetPoint.transform.position = new Vector3( Camera.main.ScreenToWorldPoint(MousePos).x,4,0);


        if(Input.GetMouseButtonUp(0) && !movebody)
        {
            //Vector3 transformPos = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
            movebody = true;
            TargetPosAtLaunch = new Vector3(0,0,TargetPoint.transform.position.z);
            TargetAtMouse = TargetPoint.transform.position;
            transform.GetChild(0).gameObject.SetActive(true);

        }

        if(movebody)
        {

            Vector3 difference = transform.position - TargetAtMouse;
            float diff = difference.magnitude;

            if (TargetAtMouse.x > 3f || TargetAtMouse.x < -3f)
            {
                transform.position = Vector3.Slerp(transform.position, TargetAtMouse, 0.1f);
                transform.localScale -= new Vector3(diff * 0.001f, diff * 0.001f, 0);

                transform.Rotate(0, 0, TargetPoint.transform.position.x * 0.1f);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, TargetAtMouse, 0.1f);
                transform.localScale -= new Vector3(diff * 0.002f, diff * 0.002f, 0);

                transform.Rotate(0, 0, TargetPoint.transform.position.x * -0.2f);
            }

            
            


            //transform.LookAt(TargetPosAtLaunch);

            if (diff <= 0.3f)
            {
                movebody = false;
                // Debug.Log("Reached");
                Destroy(transform.gameObject);
            }
        }
    }


}
        /*
        if(Input.GetKeyDown(KeyCode.Space) && !movebody)
        {
            float force = transform.up.magnitude * 1f;

            //Rb.velocity += new Vector2(0,force);
            movebody = true;
            Speed = 3f;
            //transform.Translate(0, 5f * Time.deltaTime, 0, Space.Self);
        }

        if(movebody)
        {
            transform.Translate(0, Speed * Time.deltaTime, 0, Space.Self);
            Speed-= 0.1f;

            if (Speed <= 0.1f)
            {
                movebody = false;
            }

        }

        //Vector3 mousePos = new Vector3(0, 0,);

        //transform.LookAt(0,0,Camera.main.WorldToScreenPoint(mousePos));

        //transform.Rotate(0, 0, Camera.main.WorldToScreenPoint(Input.mousePosition.x));
    
    */
