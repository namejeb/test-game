using Unity.VisualScripting;
using UnityEngine;

public class FindLimbs : MonoBehaviour
{
    void Awake ()
    {
        Transform[] limbs = new Transform[8];
        Collider2D[] colliders = new Collider2D[8];

        
        for (int i = 0; i < 8; i++)
        {
            //Add Dismemberment script to individual limbs
            limbs[i] = transform.GetChild(i);
            limbs[i].AddComponent<Dismemberment2>();
            
            colliders[i] = transform.GetComponentInChildren<Collider2D>();
        }

        //Ignore Collision of all player colliders
        for (int i = 0; i < 8; i++)
        {
            for (int j = i + 1; j < 8; j++)
            {
                Physics2D.IgnoreCollision(colliders[i], colliders[j]);
            }
            
            //Initial limb setup
            Rigidbody2D limbRb = limbs[i].GetComponent<Rigidbody2D>();
            limbRb.gravityScale = 0f;
            colliders[i].isTrigger = true;
        }
    }
}
