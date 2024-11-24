using System.Collections;
using UnityEngine;

public class CandyScript : MonoBehaviour
{
    bool isEnabled = true;

    MeshRenderer candyMR;

    float currX;
    float currY;

    void Start()
    {
        candyMR = this.GetComponent<MeshRenderer>();
        currX = transform.position.x;
        currY = transform.position.y;
    }

    void Update()
    {
        if(!isEnabled)
            CandyMovement();
    }

    // Candy'nin animasyon fonksiyonu
    void CandyMovement()
    {
        float newX = (Mathf.Sin(Time.time*30)/10 + currX);
        float newY = (Mathf.Sin(Time.time*30)/10 + currY);
        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    // Candy'i alınca disable eden fonksiyon
    void disableCandy()
    {
        isEnabled = false;
        candyMR.material.color = Color.black;
        StartCoroutine(enableCandy());
    }

    // Candy'i 10 saniye sonra enable eden fonksiyon
    IEnumerator enableCandy()
    {
        yield return new WaitForSeconds(10f);
        candyMR.material.color = Color.white;
        isEnabled = true;
    }

    // Candy'e donkunulunca hızını arttıran fonksiyon
    void OnTriggerEnter(Collider collider)
    {
        if(isEnabled && collider.tag == "Player")
        {
            PlayerScript ps = collider.GetComponent<PlayerScript>();

            if(ps != null)
            {
                ps.SetMaxXSpeed(20f);
                disableCandy();
            }
        }
    }

}
