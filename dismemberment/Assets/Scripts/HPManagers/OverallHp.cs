using Unity.VisualScripting;
using UnityEngine;

public class OverallHp : MonoBehaviour
{

    //Components
    private Ragdoll ragdollScript;
    
    //Fields
    [SerializeField] private int overallHp;
    
    void Awake()
    {
        ragdollScript = GetComponent<Ragdoll>();
    }

    public int TakeOverallDamage(int dmg)
    {
        overallHp -= dmg;

        if (overallHp > 0) return overallHp;
        
        ragdollScript.ActivateRagdoll();
        return 0;
    }
}
