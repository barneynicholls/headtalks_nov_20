using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform endOfBarrel;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform camera;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
    }

    private void Fire()
    {
        var bullet = Instantiate(bulletPrefab, endOfBarrel.position, endOfBarrel.rotation);

        var rb = bullet.GetComponent<Rigidbody>();

        rb.AddForce(camera.forward * 2000f);
    }
}
