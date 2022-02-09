using UnityEngine;
using UnityEngine.U2D.Animation;


public class Ragdoll : MonoBehaviour
{
    //Components
    public ObjectPooler pooler;

    #region Initiliase ObjectPooler
    void Awake()
    {
        pooler = ObjectPooler.objPoolerInstance;
    }
    #endregion
    
    public void ActivateRagdoll()
    {
        //GetComponent<Animator>().enabled = false;

        if (pooler == null)
        {
            Debug.Log("Pooler instance doesn't exist");
            return;
        }
        
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform limb = transform.GetChild(i);

            if (limb.gameObject.activeInHierarchy && limb.CompareTag("Limb"))
            {
                RagdollEffect(limb);
                limb.gameObject.SetActive(false);
            }
        }
    }

    private void RagdollEffect(Transform limb)
    {
        GameObject ragdolledLimb = pooler.SpawnFromPool(limb.name, limb.transform.position, Quaternion.identity);
        ragdolledLimb.transform.localScale = transform.localScale;
            
        //Disable spriteSkin
        ragdolledLimb.GetComponent<SpriteSkin>().enabled = false;
                        
        Rigidbody2D rb = ragdolledLimb.GetComponent<Rigidbody2D>();
        rb.gravityScale = 3f;
    }
}
