using System;
using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    BulletMovement[] bullets;
    [SerializeField]
    float fireInterval = 0.5f;

    int currentBulletIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bullets = GetComponentsInChildren<BulletMovement>(true);
        handleBulletFires();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void handleBulletFires()
    {
        currentBulletIndex = 0;
        Console.WriteLine("something");
        StartCoroutine(FireRoutine());
    }

    IEnumerator FireRoutine()
    {
        int bulletLength = bullets.Length;
        
        
        while (true) // keep looping forever
        {
            BulletMovement currentBullet = bullets[currentBulletIndex];
            if (currentBullet != null) {
                currentBullet.startMoving();
            } else
            {
            }
                Console.WriteLine("Current Bullet:" + currentBullet);

                currentBulletIndex = (currentBulletIndex + 1) % bulletLength;
            yield return new WaitForSeconds(fireInterval); // wait half a second
        }
    }
}
