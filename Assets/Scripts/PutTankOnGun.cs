using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutTankOnGun : MonoBehaviour
{

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "WaterTank")
		{
			Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
			Destroy(rb);
			col.gameObject.transform.SetParent(gameObject.transform, false);

			col.gameObject.transform.localRotation = Quaternion.identity;
			col.gameObject.transform.localPosition = new Vector3(0,0.189149f, -0.0722f);
		}
	}
}
