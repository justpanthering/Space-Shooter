using UnityEngine;
using System.Collections;

public class PlayerShooter : MonoBehaviour
{
    public float fireDelay = 0.25f;
    float coolDownTimer = 0;

    void Update()
    {
        coolDownTimer -= Time.deltaTime;

        if(Input.GetButton("Fire1") && coolDownTimer <= 0)
        {
            //Shoot
            print("PEW!!!");
            coolDownTimer = fireDelay;
        }
    }
}
