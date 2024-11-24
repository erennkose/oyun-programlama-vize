using UnityEngine;

public class DayNightCycleScript : MonoBehaviour
{
    bool isCycleEnabled = false;

    void Update()
    {
        // isCycleEnabled'a bakarak belirli süreyle gündüz ve gece olmasını sağlayan kod parçası
        if(isCycleEnabled)
            transform.rotation *= Quaternion.Euler(75 * Time.deltaTime,0,0);
        else
            transform.rotation = Quaternion.Euler(50, -30, 0);
    }

    // Player'dan gece gündüz döngüsünü açıp kapatan fonksiyon
    public void SetCycle(bool b)
    {
        isCycleEnabled = b;
    }
}
