using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    #region var
    [Header("General")]
    public float speedWalk;
    public float speedRun;
    public float speedMax;
    private float speed;

    [Header("Fuck")]
    public Vector3 gay;
    private Quaternion originalPosition;
    #endregion
    #region comp
    [Header("Mouse")]
    public GameObject mouse;
    public GameObject vis;

    private Rigidbody rigidBody;
    private Vector3 dir;
    private Camera cam;
    private Transform camTransform;
    #endregion
    private void Start()
    {
        speed = speedWalk;
        rigidBody = GetComponent<Rigidbody>();
        cam = Camera.main;
        camTransform = cam.transform.parent.transform;
        originalPosition = camTransform.rotation;
    }

    private void Update()
    {
        PlayerInput();
        PlayerMove();
        PlayerLook();
        PlayerMouse();

        //camTransform.rotation = Quaternion.RotateTowards(camTransform.rotation, originalPosition, Time.deltaTime * 5); //recoil beta
    }

    private void PlayerInput()
    {
        dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        print(dir);
        
        if (Input.GetKeyDown(KeyCode.Space)) Shoot();

        if (Input.GetKey(KeyCode.LeftShift)) PlayerAim();
        else camTransform.position = Vector3.MoveTowards(camTransform.position, transform.position, 15 * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.R)) Reload();
    }
    private void PlayerMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        Vector3 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mouse.transform.position = objectPosition;
    }
    private void PlayerLook()
    {
        //vis
    }
    private void PlayerMove()
    {
        rigidBody.velocity = dir * speed;
    }
    private void PlayerAim()
    {
        camTransform.position = Vector3.Lerp(transform.position, mouse.transform.position, 0.4f);
    }
    private void Reload()
    {

    }
    private void Shoot()
    {
        Vector3 a = mouse.transform.position - vis.transform.position;
        a.Normalize();
        a *= 10;
        Debug.DrawRay(vis.transform.position, a, Color.red, 0.5f);

        //camTransform.rotation *= Quaternion.Euler(gay);
        Recoil();
    }
    private void Recoil()
    {
        StopAllCoroutines();
        StartCoroutine(Reco());
    }
    private IEnumerator Reco()
    {
        float timer = 0;
        while(timer <= 0.1f)
        {
            yield return null;
            timer += Time.deltaTime;
            Vector3 ra = Random.insideUnitSphere * 0.35f;
            ra.y = 10;
            cam.transform.localPosition = ra;
        }
        cam.transform.localPosition = new Vector3(0,10,0);
    }
}
