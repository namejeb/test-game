using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

//Get limbs in editor time, able to change hp right away
[ExecuteInEditMode]
public class SetupEnemyHp : MonoBehaviour
{
    //Components
    private ObjectPooler pooler;
    
    //Fields
    public List<Limb> limbList;
    
    #region Singleton & Initialise pooler instance

    public static SetupEnemyHp setupInstance;
    void Awake()
    {
        setupInstance = this;
        pooler = ObjectPooler.objPoolerInstance;
    }
    
    #endregion
    
    
    //Limb class for setting hp
    [System.Serializable]
    public class Limb
    {
        public int hp = 0;
        [SerializeField] private Transform limb;
        private bool created = false;
        
        public Limb(Transform limb)
        {
            this.limb = limb;
        }

        //Getter 
        public string GetLimbName()
        {
            return limb.name;
        }

        public bool GetCreated()
        {
            return created;
        }


        //Setters
        public void SetLimb(Transform limb)
        {
            this.limb = limb;
        }

        public void SetCreated(bool created)
        {
            this.created = created;
        }
    }
    
    //Setup List (copy from existing pools), only for limbs
    void Start()
    {
        if (limbList.Count != 0) return;
        
        for (int i = 0; i < pooler.pools.Count; i++)
        {
            var objPool = pooler.pools[i];
            Transform obj = objPool.GetGameObj().transform;
            
            if (obj.CompareTag("Limb"))
            {
                Limb newLimb = new Limb(obj);
                limbList.Add(newLimb);
            }
        }
    }
}
