using System.Collections;
using System.Collections.Generic;
using OpenGlove_API_C_Sharp_HL;
using OpenGlove_API_C_Sharp_HL.OGServiceReference;
using System;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{


    public Transform theDest;
    static Glove guante;
    static List<Glove> gloves;
    public  OpenGloveAPI api = OpenGloveAPI.GetInstance();

    public void Start()
    {
        
    }

    public void OnMouseDown()
    {

        try
        {
            gloves = api.Devices;
            Debug.Log("dsadas");
            Debug.Log(gloves);
        }
        catch
        {
            Debug.Log("ERROR: El servicio no esta activo");
        }
        guante = gloves[1];
        api.Activate(guante, 1, 255);
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = theDest.position;
        this.transform.parent = GameObject.Find("Destination").transform;
        
        


    }
    
    public void OnMouseUp()
    {
       

        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        api.Activate(guante, 1, 0);

    }
}
