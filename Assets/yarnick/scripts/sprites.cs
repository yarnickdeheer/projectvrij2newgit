using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprites : MonoBehaviour
{
    Vector2 m_MyFirstVector;
    Vector2 m_MySecondVector;

    float m_Angle;
    public follow direction;

    public GameObject[] afbeeldingen;
    public GameObject cam;
    public GameObject p;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = p.transform.position;
        //Fetch the first GameObject's position
        m_MyFirstVector = this.transform.position;
        //Fetch the second GameObject's position
        m_MySecondVector = cam.transform.position;
        //Find the angle for the two Vectors
        m_Angle = Vector2.Angle(m_MyFirstVector, m_MySecondVector);


        Vector3 relative = transform.InverseTransformPoint(cam.transform.position);
        float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
        //if (p.transform.eulerAngles.y > 180)
        //{
        //    p.transform.eulerAngles = new Vector3(
        //    p.transform.eulerAngles.x,
        //    p.transform.eulerAngles.y - 360,
        //    p.transform.eulerAngles.z);
        //}else if (p.transform.eulerAngles.y < -180)
        //{
        //    p.transform.eulerAngles = new Vector3(
        //   p.transform.eulerAngles.x,
        //   p.transform.eulerAngles.y + 360,
        //   p.transform.eulerAngles.z);
        //}
        Debug.Log("rotation van enemy" + p.transform.eulerAngles.y + " angle: " + angle );
        //angle = angle - p.transform.eulerAngles.y;
       // Debug.Log("angle na rotation" + angle);
        

      
        if (angle >= 135 &&  angle <= 180  || angle >=-190 && angle <= -135 )
        {
            //front || angle <= 45 && angle >= -45 && direction.back == true
            // cam.GetComponent<MeshRenderer>().material = afbeeldingen[0];
            afbeeldingen[0].SetActive(true);
            afbeeldingen[1].SetActive(false);
            afbeeldingen[2].SetActive(false);
            afbeeldingen[3].SetActive(false);

        }
        else if (angle <=45 && angle >=-45 )
        {
            //back || angle >= 135 && angle <= 180 && direction.front == true || angle >= -190 && angle <= -135 && direction.front == true
            //cam.GetComponent<MeshRenderer>().material = afbeeldingen[1];
            afbeeldingen[0].SetActive(false);
            afbeeldingen[1].SetActive(true); 
            afbeeldingen[2].SetActive(false);
            afbeeldingen[3].SetActive(false);
        }
        else if (angle >=45 && angle <=135  )
        {
            //right || angle > -135 && angle < -45 &&  direction.back == true
            // cam.GetComponent<MeshRenderer>().material = afbeeldingen[2];
          
                afbeeldingen[0].SetActive(false);
                afbeeldingen[1].SetActive(false);
                afbeeldingen[2].SetActive(true);
                afbeeldingen[3].SetActive(false);
            

        }
        else if (angle >=-135 && angle <= -45 )  
        {
            //left || angle > 45 && angle < 135 && direction.back == true
            // cam.GetComponent<MeshRenderer>().material = afbeeldingen[3];
        
        
                afbeeldingen[0].SetActive(false);
                afbeeldingen[1].SetActive(false);
                afbeeldingen[2].SetActive(false);
                afbeeldingen[3].SetActive(true);
            
        }


      //  Debug.Log(angle);



    }
}
