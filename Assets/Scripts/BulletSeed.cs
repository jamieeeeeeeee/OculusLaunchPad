using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSeed : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabSeeds;
	float timeDelta = 0f;
	
	void Update()
	{
		timeDelta = timeDelta + Time.deltaTime;
		if (timeDelta > 2f)
		{
			Destroy(gameObject);
		}
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter CloudBullet");
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.GetComponent<PlantableArea>() != null && collision.gameObject.GetComponent<PlantableArea>().IsPlantableArea())
        {
            int randomTreeIndex = Mathf.RoundToInt(Random.Range(0, 1) * (prefabSeeds.Length - 1));
            Debug.Log("OnCollisionEnter Seed");
            ContactPoint contact = collision.contacts[0];
            GameObject tree = Instantiate(prefabSeeds[randomTreeIndex], contact.point, Quaternion.identity);

            tree.GetComponent<Animator>().SetBool("shouldGrow", true);
            Destroy(gameObject);
        }
    }
}

