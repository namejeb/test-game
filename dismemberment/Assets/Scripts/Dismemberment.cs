using UnityEngine;
using UnityEngine.U2D.Animation;

public class Dismemberment : MonoBehaviour
{
    // void OnMouseDown()
    // {
    //     Dismember();
    // }
    //
    public void Dismember()
    {
        SpriteSkin spriteSkin = gameObject.GetComponent<SpriteSkin>();
        spriteSkin.enabled = false;
        
        
        //Instantiate(limbPrefab, transform.position, Quaternion.identity);
        
        // Rigidbody2D theRb = limbPrefab.GetComponent<Rigidbody2D>();
        // theRb.velocity = new Vector2(50f, 50f);

        //Destroy(gameObject);
       //gameObject.transform.parent = null;
       
       // Rigidbody2D theRb = gameObject.GetComponent<Rigidbody2D>();
       // theRb.AddForce(new Vector2(50f, 50f));
    }
    
    //destroy limb after certain seconds

}
