using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    void Start(){
    	var temp = GetComponent<ParticleSystem>().main;
    	temp.startColor = Random.ColorHSV(0,1,1,1,1,1,50.0f/255.0f,50.0f/255.0f);
    }

    void Update () 
    {
        transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);

    }
}