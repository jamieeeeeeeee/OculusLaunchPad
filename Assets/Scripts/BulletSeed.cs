using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSeed : MonoBehaviour
{


    [SerializeField] private GameObject[] prefabSeeds;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
            GameObject tree = Instantiate(prefabSeeds[0], contact.point, Quaternion.identity);

            tree.GetComponent<Animator>().SetBool("shouldGrow", true);
            Destroy(gameObject);
        }
    }
}

