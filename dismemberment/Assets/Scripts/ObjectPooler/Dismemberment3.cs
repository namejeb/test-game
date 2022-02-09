using UnityEngine;
using UnityEngine.U2D.Animation;


public class Dismemberment3 : MonoBehaviour, IPooledObjects
{
    //Components
    private ObjectPooler objectPooler;
    private EnemyHpUpdater hpManager;
    
    //Fields
    private Vector3 objActualScale;

    #region Initialise EnemyHpUpdater instance
    void Awake()
    {
        hpManager = EnemyHpUpdater.enemyHpManagerInstance;
    }
    #endregion
    
    void Start()
    {
        objectPooler = ObjectPooler.objPoolerInstance;
        objActualScale = transform.parent.localScale;
    }

    
    private void OnMouseDown()
    {
        int remainingHp = hpManager.TakeDamage(1, transform.name);

        if (remainingHp > 0) return;
        OnObjectSpawn();
    }
    
    public void OnObjectSpawn()
    {
        Dismember();
    }

    //Optimize a lot of enabling and disabling components (do changes before pooling)
    private void Dismember()
    {
        GameObject detachedLimb = objectPooler.SpawnFromPool(transform.name, transform.position, Quaternion.identity);
        
        //Disable spriteSkin
        detachedLimb.GetComponent<SpriteSkin>().enabled = false;

        if (detachedLimb == null) return;
        detachedLimb.transform.localScale = objActualScale;
        
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
        
        Rigidbody2D limbRb = detachedLimb.GetComponent<Rigidbody2D>();
        limbRb.AddForce(new Vector2(1 * 30f, 1 * 10f), ForceMode2D.Impulse);
    }
}
