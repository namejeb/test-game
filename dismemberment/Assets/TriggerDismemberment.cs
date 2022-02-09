using UnityEngine;
using UnityEngine.U2D.Animation;

public class TriggerDismemberment : MonoBehaviour
{
    public SpriteSkin limbSpriteSkin;
    void OnMouseDown()
    {
        Dismember();
    }

    void Dismember()
    {
        if(limbSpriteSkin == null) Debug.Log("bruh");
        else
        {
            Debug.Log("patah liao");
            limbSpriteSkin.gameObject.transform.SetParent(null);
            limbSpriteSkin.enabled = false;

            limbSpriteSkin.gameObject.AddComponent<PolygonCollider2D>();
            transform.localScale = new Vector3(0f, 0f, 0f);
        }
    }
}
