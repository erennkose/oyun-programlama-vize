using UnityEngine;

public class JumpingMushScript : MonoBehaviour
{
    // Mushroom'a dokunulunca y hızını değiştiren fonksiyon
    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            PlayerScript ps = collider.GetComponent<PlayerScript>();

            if(ps != null)
                ps.SetYSpeed(30);
        }
    }
}
