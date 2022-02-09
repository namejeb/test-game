using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    #region Singleton

    public static ObjectPooler objPoolerInstance;

    void Awake()
    {
        objPoolerInstance = this;
    }

    #endregion

    //Components
    public GameObject[] ObjectArr;
    
    //Fields
    private const int poolSize = 5;

    [System.Serializable] 
    public class Pool
    {
        [SerializeField] private GameObject gameObj;
        private  string name;
        private  int size;

        public Pool(string name, GameObject gameObj)
        {
            this.name = name;
            this.gameObj = gameObj;
            this.size = poolSize;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return name;
        }
        public GameObject GetGameObj()
        {
            return gameObj;
        }
        public int GetSize()
        {
            return size;
        }
    }
    
    public Dictionary<string, Queue<GameObject>> poolDictionary;   
    public List<Pool> pools;


    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        //Mainly for pooling limbs, also for bullet and FX
        //Add characters in inspector
        foreach (GameObject obj in ObjectArr)
        {
            if (obj.transform.childCount > 0)
            {
                //Finds all chidlren in obj, excludes bones, add to pools list
                for (int i = 0; i < obj.transform.childCount; i++)
                {
                    GameObject child = obj.transform.GetChild(i).gameObject;

                    if (!child.CompareTag("Bone"))
                    {
                        Pool newPool = new Pool(child.name, child);
                        pools.Add(newPool);
                    }
                }
            }
            else
            {
                Pool newPool = new Pool(obj.name, obj);
                pools.Add(newPool);
            }
        }

        //Add Queues of gameObjects
        foreach (Pool myPool in pools)
        {
            Queue<GameObject> objPool = new Queue<GameObject>();

            //Instantiating, setting inactive & enqueueing into pool
            for (int i = 0; i < myPool.GetSize(); i++)
            {
                GameObject objToPool = Instantiate(myPool.GetGameObj());
                
                objToPool.AddComponent<Rigidbody2D>();
                objToPool.name = myPool.GetName();
                objToPool.SetActive(false);

                objPool.Enqueue(objToPool);
            }

            //Add to dictionary
            poolDictionary.Add(myPool.GetName(), objPool);
        }
    }

    public GameObject SpawnFromPool(string name, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(name))
        {
            Debug.Log("Pool '" + name + "' doesn't exist.");
            return null;
        }
        
        GameObject objectToSpawn = poolDictionary[name].Dequeue();

        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.SetActive(true);
        
        poolDictionary[name].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
