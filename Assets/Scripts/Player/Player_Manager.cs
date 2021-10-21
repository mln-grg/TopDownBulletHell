using UnityEngine;

public class Player_Manager : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] AnimationManager animationManager;
    [SerializeField] GunController gunController;
    [Header("Movement")]
    [SerializeField] float moveSpeed;

    Rigidbody rb;
    Vector3 moveVelocity;

    //Inputs
    Vector3 moveInput;
    bool shootButtonDown;
    bool shootButtonUp;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleInputs();
        HandleLooking();
        HandleShooting();
        HandleAnimations();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }
    void HandleInputs()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        shootButtonDown = Input.GetMouseButtonDown(0);
        shootButtonUp = Input.GetMouseButtonUp(0);
    }

    void HandleMovement()
    {
        moveVelocity = moveInput.normalized * moveSpeed;
        rb.velocity = moveVelocity;
    }
    void HandleLooking()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay,out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.red);

            transform.LookAt(new Vector3(pointToLook.x,transform.position.y,pointToLook.z));
        }
    }

    void HandleShooting()
    {
        if (shootButtonDown)
        {
            gunController.isFiring = true;
            
        }
        else if(shootButtonUp)
        {
            gunController.isFiring = false;
        }
    }
    void HandleAnimations()
    {
        animationManager.SetSpeed(moveInput.magnitude);
        animationManager.SetIsFiring(gunController.isFiring);
    }

}
