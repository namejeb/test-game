using Unity.VisualScripting;
using UnityEngine;

public class TestFindLimbs : MonoBehaviour
{ 
    private void Start ()
    {
        for (int i = 0; i < transform.childCount; i++) 
        {
            Transform obj = transform.GetChild(i);
            
            //When object is limb
            if (obj.CompareTag("Limb"))
            {
                obj.AddComponent<Dismemberment3>();
            }
        }
    }
}
