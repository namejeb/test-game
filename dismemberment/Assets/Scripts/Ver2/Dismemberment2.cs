using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class Dismemberment2 : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("patah");
        Dismember();
    }

    private void Dismember()
    {
        Animator anim = transform.parent.GetComponent<Animator>();
        //anim.enabled = false;
        
        transform.SetParent(null);
        
        
        //Add Rigidbody & physics after dismembered
        if (!TryGetComponent(out Rigidbody2D limbRb))
        {
            transform.AddComponent<Rigidbody2D>();
        }
        limbRb.gravityScale = 1f;
        limbRb.AddForce(new Vector2(1 * 30f, 1 * 10f) , ForceMode2D.Impulse);

        Collider2D collider = GetComponent<Collider2D>();
        collider.isTrigger = false;

        //Disable SpriteSkin
        // SpriteSkin spriteSkin = transform.GetComponent<SpriteSkin>();
        // spriteSkin.enabled = false;
    }
}
