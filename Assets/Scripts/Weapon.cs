using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform endOfBarrel;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform playerCamera;
    [SerializeField] float force = 2000f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            var bullet = Instantiate(bulletPrefab, endOfBarrel.position, endOfBarrel.rotation);

            var rb = bullet.GetComponent<Rigidbody>();

            rb.AddForce(playerCamera.forward * force);
        }
    }
}
