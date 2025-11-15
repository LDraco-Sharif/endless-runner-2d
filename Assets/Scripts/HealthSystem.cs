using System.Collections;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    float health = 100;
    [SerializeField]
    Color damageColor = Color.red;
    [SerializeField]
    float damageDuration = 0.5f;

    Renderer rend;
    Color originalColor;
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    public void damage(float damageValue)
    {
        health -= damageValue;
        showDamageVisual();
        if (health <= 0)
        {
            /** ToDo: Add death logic **/
        }
    }

    private void showDamageVisual()
    {
        StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        if(rend.material.color != originalColor)
        {
            yield return null;
        }
        rend.material.color = damageColor;
        yield return new WaitForSeconds(damageDuration);
        rend.material.color = originalColor;
    }

}
