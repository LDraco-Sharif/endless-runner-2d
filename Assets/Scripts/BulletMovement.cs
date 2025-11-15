using System;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public Transform startPosition;

    [SerializeField]
    float startingOffset = 0;

    [SerializeField]
    float moveSpeed = 1;

    [SerializeField]
    float maxDistance = 1;

    bool isBulletMoving = false;

    ParticleSystem blastEffect;

    public GameObject bullet;

    [SerializeField]
    BulletInfo bulletInfo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletInfo = gameObject.GetComponent<BulletInfo>();
        blastEffect = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(isBulletMoving)
        {
            moveBullet();
        }


    }

    public void startMoving() {
        //if (bullet.activeSelf)
        //{
        //    return;
        //}

        bullet?.SetActive(true);
        isBulletMoving = true;
        bullet.transform.position = startPosition.position + new Vector3(0, startingOffset, 0);
    }

    void moveBullet()
    {
        if(bullet.transform.localPosition.y > maxDistance)
        {
            disappearBullet();
            return;
        }
        bullet.transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet")) {
            return;
        }

        HealthSystem enemy = other.GetComponent<HealthSystem>();
        
        if(enemy.isActiveAndEnabled)
        {
            enemy.damage(bulletInfo.damage);
        }

        if(blastEffect)
        {
            blastEffect.gameObject.transform.position = bullet.transform.position;
            blastEffect.Play();
        }
        disappearBullet();
    }

    void disappearBullet() {
        bullet.SetActive(false);
        isBulletMoving = false;
    }
}
