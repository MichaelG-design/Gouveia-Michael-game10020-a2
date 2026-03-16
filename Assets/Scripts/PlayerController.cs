using UnityEngine;

//This script handles anything related to the player's character

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float gravity = -9.81f;

    //The range the player can interact objects in
    public float interactRange = 5f;

    //Tracks if the player has the fire staff
    private bool hasFireStaff = false;

    private CharacterController controller;
    private Animator animator;
    private Vector3 velocity;

    //This is a refernce to the staff and where it's gonna go on the player's hand
    public Transform StaffEquipped;
    private GameObject equippedStaff;

    //The Fireball's prefab reference and intial spawn point
    public GameObject fireballPrefab;
    public Transform firePoint;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        MovePlayer();
        HandleInteraction();

        if (hasFireStaff && Input.GetMouseButtonDown(0))
        {
            ShootFireball();
        }

    }

    //MovePlayer is what handles all the player input
    void MovePlayer()
    {
        //Keyboard input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, 0f, z);
        Vector3 moveVelocity = move * moveSpeed;

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        moveVelocity.y = velocity.y;
        controller.Move(moveVelocity * Time.deltaTime);

        Vector3 horizontalVelocity = new Vector3(moveVelocity.x, 0f, moveVelocity.z);

        if (horizontalVelocity.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(horizontalVelocity);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                15f * Time.deltaTime
            );
        }

        if (animator != null)
        {
            animator.SetFloat("Speed", horizontalVelocity.magnitude);
        }
    }

    //Handles player interaction with objects
    void HandleInteraction()
    {
        //Press E to interact with things
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward);

            RaycastHit hit;

            //Check if we can interact with something within range
            if (Physics.Raycast(ray, out hit, interactRange))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();

                if (interactable != null)
                {
                    //Call the interact on that object
                    interactable.Interact();
                }
            }
        }
    }

    //This is called when the player picks up the Fire Staff
    public void EquipFireStaff(GameObject staff)
    {
        hasFireStaff = true;

        //Attach the staff to the player's hand
        staff.transform.SetParent(StaffEquipped);
        staff.transform.localPosition = Vector3.zero;
        staff.transform.localRotation = Quaternion.identity;

        equippedStaff = staff;
    }

    //Shoots a FireBall from the player
    void ShootFireball()
    {
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);

        Fireball fb = fireball.GetComponent<Fireball>();

        if (fb != null)
        {
            fb.SetDirection(transform.forward);
        }
    }

}
