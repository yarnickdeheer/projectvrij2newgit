using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using FMODUnity;
using UnityEngine.UI;
public class pcontroller : MonoBehaviour
{
    private bool groundedPlayer;

    CharacterController Controller;
    private Vector3 playerVelocity;
    public float Speed;
    public float jumpHeight = 5.0f;
    public Transform Cam;
    public bool ground;
    private float gravityValue = -9.81f;
    public bool dubblejump;
    public Animator anim;
    protected AnimatorOverrideController overrideController;

    public Sprite[] sprites;

    public Transform target;
    public SpriteRenderer alto;

    public AnimationClip[] idles;

    public StudioEventEmitter footsteps;
    public StudioEventEmitter jumpSound;




    public GameObject turtlecam;
    public GameObject cam;
    public GameObject turtle;


    public RawImage ui;
    public Texture bearUI;

    public Transform groundCheck;
    public LayerMask groundLayer;

    private float footstepTimer;
    private float footstepVolume;


    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Controller = GetComponent<CharacterController>();
        overrideController = new AnimatorOverrideController(anim.runtimeAnimatorController);
    }

    // Update is called once per frame
    void Update()
    {
        if(footstepTimer >= 1f)
        {
            footstepVolume = Mathf.Lerp(footstepVolume, 0.3f, 0.05f);
        }

        if(footstepTimer < 1f)
        {
            footstepVolume = 1;
        }

        footsteps.SetParameter("Voetstap_Volume", footstepVolume, false);

        groundedPlayer = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if (footsteps.IsPlaying() == false && groundedPlayer)
                footsteps.Play();

            footstepTimer += Time.deltaTime;

            Move();
        }


        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            //Debug.Log("nani");
            if (anim.GetBool("frontmovement") == true)
            {

                anim.SetBool("frontmovement", false);
                anim.SetBool("backmovement", false);
                anim.SetBool("sidemovement", false);
                //this.GetComponent<SpriteRenderer>().sprite = sprites[0];
               // overrideController["idle"] = idles[0];
               // anim.runtimeAnimatorController = overrideController;
                //anim.GetCurrentAnimatorClipInfo(0). = idles[0];


            }
            else if (anim.GetBool("backmovement") == true)
            {
                anim.SetBool("frontmovement", false);
                anim.SetBool("backmovement", false);
                anim.SetBool("sidemovement", false);
                overrideController["idle"] = idles[1];
                anim.runtimeAnimatorController = overrideController;
                //this.GetComponent<SpriteRenderer>().sprite = sprites[1];
            }
            else if (anim.GetBool("sidemovement") == true && this.GetComponent<SpriteRenderer>().flipX == true)
            {
                anim.SetBool("frontmovement", false);
                anim.SetBool("backmovement", false);
                anim.SetBool("sidemovement", false);
                this.GetComponent<SpriteRenderer>().flipX = true;
                this.GetComponent<SpriteRenderer>().sprite = sprites[3];
            }
            else if (anim.GetBool("sidemovement") == true && this.GetComponent<SpriteRenderer>().flipX == false)
            {
                anim.SetBool("frontmovement", false);
                anim.SetBool("backmovement", false);
                anim.SetBool("sidemovement", false);
                this.GetComponent<SpriteRenderer>().flipX = false;
                this.GetComponent<SpriteRenderer>().sprite = sprites[2];
            }

            footstepTimer = 0;
        }


        if (Input.GetButtonDown("Jump") && groundedPlayer == true)
        {
            Debug.Log("jump");
            anim.SetBool("viool", false);
            anim.SetBool("vioolZ", false);
            alto.enabled = true;
            anim.SetBool("backjump", true);
            ground = false;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * (gravityValue / 5));
            if (jumpSound.IsPlaying() == false)
                jumpSound.Play();
        }
        

        playerVelocity.y += gravityValue * Time.deltaTime;
        Controller.Move(playerVelocity * Time.deltaTime);



        Vector3 targetPostition = new Vector3(target.position.x,
                                     this.transform.position.y,
                                     target.position.z);
        this.transform.LookAt(targetPostition);
        
    }

    void Move()
    {
        float Horizontal = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float Vertical = Input.GetAxis("Vertical") * Speed * Time.deltaTime;


        Vector3 Movement = Cam.transform.right * Horizontal + this.gameObject.transform.forward * Vertical *-1;
        Controller.Move(Movement);
        if (Movement.magnitude != 0f)
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Cam.GetComponent<CameraMove>().Xsensivity * Time.deltaTime);


            Quaternion CamRotation = Cam.rotation;
            CamRotation.x = 0f;
            CamRotation.z = 0f;

            transform.rotation = Quaternion.Lerp(transform.rotation, CamRotation, 0.1f);

        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {

            this.GetComponent<SpriteRenderer>().flipX = false;
            //this.GetComponent<SpriteRenderer>().sprite = sprites[2];

            anim.SetBool("frontmovement", false);
            anim.SetBool("backmovement", false);
            anim.SetBool("sidemovement", true);
            anim.SetBool("viool", false);
            anim.SetBool("vioolZ", false);
            alto.enabled = true;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
            //this.GetComponent<SpriteRenderer>().sprite = sprites[3];

            anim.SetBool("frontmovement", false);
            anim.SetBool("backmovement", false);
            anim.SetBool("sidemovement", true);
            anim.SetBool("viool", false);
            anim.SetBool("vioolZ", false);
            alto.enabled = true;
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {

            anim.SetBool("sidemovement", false);
            anim.SetBool("backmovement", false);
            anim.SetTrigger("anim");
            anim.SetBool("frontmovement", true);
            anim.SetBool("viool", false);
            anim.SetBool("vioolZ", false);
            alto.enabled = true;
            //this.GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {

            anim.SetBool("frontmovement", false);
            anim.SetBool("sidemovement", false);
            anim.SetBool("viool", false);
            anim.SetBool("vioolZ", false);
            anim.SetBool("backmovement", true);
            alto.enabled = true;
            //this.GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            
            cam.gameObject.SetActive(true);
            turtlecam.gameObject.SetActive(false);
            anim.SetBool("backjump", false);
            ground = true;
        }
      
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
           
            ground = true;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "kill")
        {
            Debug.Log("kill the turtle");
            cam.gameObject.SetActive(true);
            turtlecam.gameObject.SetActive(false);
            turtle.SetActive(false);
        }
        if (other.gameObject.tag == "uitrigger")
        {
            ui.texture = bearUI;
            var tempColor = ui.color;
            tempColor.a =1f;
            ui.color = tempColor;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "uitrigger")
        {
            ui.texture = null;
            var tempColor = ui.color;
            tempColor.a = 0f;
            ui.color = tempColor;
        }
    }
}
