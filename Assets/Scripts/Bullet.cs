using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    [SerializeField] private GameObject[] prefabTrees;
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
        if (collision.gameObject.GetComponent<Seed>() != null && collision.gameObject.GetComponent<Seed>().IsSeed())
        {
            int randomTreeIndex = Mathf.RoundToInt(Random.Range(0, 1) * (prefabTrees.Length - 1));
            GameObject tree = Instantiate(prefabTrees[randomTreeIndex], collision.gameObject.transform);

            tree.GetComponent<Animator>().SetBool("shouldGrow", true);
            //Destroy(collision.gameObject
        }

        Collider[] hitColliders = Physics.OverlapSphere(collision.gameObject.transform.position, 1.5f);

        if (hitColliders.Length > 0){
            // Detect puddles nearby
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.tag == "Puddle")
                {    
                    hitCollider.gameObject.GetComponent<Animator>().SetTrigger("shouldShrink");
                }
            }
        }
    }
}
