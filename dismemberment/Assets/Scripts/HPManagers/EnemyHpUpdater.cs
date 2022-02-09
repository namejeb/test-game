using UnityEngine;


public class EnemyHpUpdater : MonoBehaviour
{
    //Components
    private SetupEnemyHp setup;
    public OverallHp overallHp;

    #region Singleton, Initialise SetupEnemyHp instance

    public static EnemyHpUpdater enemyHpManagerInstance;
    
    void Awake()
    {
        enemyHpManagerInstance = this;
        
        setup = SetupEnemyHp.setupInstance;
    }

    #endregion
    
    public int TakeDamage(int dmg, string limbName)
    {
        // if(!setup.isActiveAndEnabled) Debug.Log("no setup");
        // else Debug.Log("yes");
        
        SetupEnemyHp.Limb foundLimb = setup.limbList.Find(limb => limb.GetLimbName() == limbName);
        int currHp = 0;
        
        if (foundLimb != null)
        {
            foundLimb.hp -= dmg;
        }
        currHp = foundLimb.hp;
        
        overallHp.TakeOverallDamage(dmg);
        

        return currHp;
    }
}
