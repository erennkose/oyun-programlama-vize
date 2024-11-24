using UnityEngine;
using UnityEngine.UIElements;

public class LollipopScript : MonoBehaviour
{
    [SerializeField]
    UIDocument UID;

    Label winUI;
    
    void Start()
    {
        winUI = UID.rootVisualElement.Q<Label>("Win");
    }

    // Lollipop'a dokunulunca oyunun bitiren fonksiyon
    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            PlayerScript ps = collider.GetComponent<PlayerScript>();

            if(ps != null)
            {
                winUI.style.display = DisplayStyle.Flex;
                Time.timeScale = 0;
            }
        }
    }
}
