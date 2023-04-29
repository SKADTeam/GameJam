using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAtma : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Player;
    public bool baseAtabilir;

    public void Start()
    {
        baseAtabilir = true;
    }

    public void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (baseAtabilir )
            {
                StartCoroutine(BaseTeleport());
                
            }


            else
            {
                
            }
        }

    }

    IEnumerator BaseTeleport()
    {
        yield return new WaitForSeconds(2f);
        Camera.transform.position = new Vector3(-15f, 0f, -10f);
        Player.transform.position = new Vector3(12.25f, 0.01f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            baseAtabilir = false;
        }
    }

}
