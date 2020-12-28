using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaccumToGrab : MonoBehaviour
{
    private LineRenderer rr;

    private Transform origin;

    private GameObject holographic;


    private bool rendering = false;

    void Start()
    {
        rr = this.gameObject.AddComponent<LineRenderer>();
        origin = this.transform;
        rr.material = new Material(Shader.Find("Sprites/Default"));
        rr.widthMultiplier = 0.01f;
        rr.positionCount = 2;

        holographic = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects
        // hit.normal = returns the face of the vector that was hit by the point 
        Vector3 fwd = this.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(this.transform.position, fwd * 50, Color.green);
        if (Physics.Raycast(origin.position, origin.TransformVector(origin.transform.forward), out hit, 100))
        {
            rr.SetPosition(0, origin.position);
            rr.SetPosition(1, fwd * 50); //collision point

            if (OVRInput.Get(OVRInput.RawButton.A) && hit.collider.gameObject.tag == "Crystal")
            {
                PickUpObject(hit);
            }
        }
        else
        {
            //rr.SetPosition(0, origin.position);
            //rr.SetPosition(1, origin.TransformVector(caster.transform.forward) * 100.0f); //collision point
        }
    }

    void PickUpObject(RaycastHit hit)
    {
        Debug.Log("Picking up object");
        //hit.collider.gameObject.transform.position = caster.position;
        GetComponent<AudioSource>().Play(0);
        Destroy(hit.collider.gameObject);

    }
}
