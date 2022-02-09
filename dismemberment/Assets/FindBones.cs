using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class FindBones : MonoBehaviour
{
    void Awake()
    {
        Transform[] limbs = new Transform[8];

        for (int i = 0; i < 8; i++)
        {
            limbs[i] = transform.GetChild(i);
            //limbs[i].AddComponent<Dismemberment>();
            
            SpriteSkin spriteSkin = limbs[i].GetComponent<SpriteSkin>();
            spriteSkin.rootBone.transform.AddComponent<TriggerDismemberment>();

            TriggerDismemberment trigger = spriteSkin.rootBone.transform.GetComponent<TriggerDismemberment>();
            trigger.limbSpriteSkin = spriteSkin;
        }
    }
}
