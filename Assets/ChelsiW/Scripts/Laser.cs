using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float laserDistance;
    [SerializeField]
    private float visibleDistance;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;

    private LineRenderer lineRenderer;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        /*RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, laserDistance);

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, player.transform.position);

        if(hit && hit.collider.CompareTag("Player"))
        {
            Vector2 direction = (hit.point - (Vector2)transform.position).normalized;
            ShootBullet(direction);

        }*/

        Vector2 direction = player.transform.position - transform.position;
        float distanceToPlayer = direction.magnitude;
        direction.Normalize();



        if (distanceToPlayer <= visibleDistance)
        {
            lineRenderer.enabled = true;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, laserDistance);


            if (hit)
            {
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, hit.point);

                if (hit.collider.CompareTag("Player"))
                {
                    ShootBullet(direction);
                }
            }
            else
            {
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, (Vector2)transform.position + direction * laserDistance);
            }
        }
        else
        {
            lineRenderer.enabled = false;
        }
        


    

}

    private void ShootBullet(Vector2 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = direction * bulletSpeed;
    }

}
