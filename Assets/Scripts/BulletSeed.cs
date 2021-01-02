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
		if (timeDelta > 1f)
		{
			Destroy(gameObject);
		}
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlantableArea>() != null && collision.gameObject.GetComponent<PlantableArea>().IsPlantableArea())
        {
            int randomTreeIndex = Mathf.RoundToInt(Random.Range(0, 1) * (prefabSeeds.Length - 1));
            ContactPoint contact = collision.contacts[0];
            GameObject tree = Instantiate(prefabSeeds[randomTreeIndex], contact.point, Quaternion.identity);

            tree.GetComponent<Animator>().SetBool("shouldGrow", true);
            Destroy(gameObject);
        }
    }
}

