using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using FMODUnity;
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


    public AnimationClip[] idles;

    public StudioEventEmitter footsteps;
    public StudioEventEmitter jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        Controller = GetComponent<CharacterController>();
        overrideController = new AnimatorOverrideController(anim.runtimeAnimatorController);
    }

    // Update is called once per frame
    void Update()
    {

        groundedPlayer = Controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if (footsteps.IsPlaying() == false && groundedPlayer)
                footsteps.Play();

            Move();
        }


        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            Debug.Log("nani");
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

        }



        if (Input.GetButtonDown("Jump") && ground == true)
        {
            Debug.Log("jump");
            anim.SetBool("viool", false);
            anim.SetBool("backjump", true);
            ground = false;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * (gravityValue / 5));
            if (jumpSound.IsPlaying() == false)
                jumpSound.Play();
        }
        else if (Input.GetButtonDown("Jump") && dubblejump == true)
        {
            dubblejump = false;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * (gravityValue / 5));
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
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
            //this.GetComponent<SpriteRenderer>().sprite = sprites[3];

            anim.SetBool("frontmovement", false);
            anim.SetBool("backmovement", false);
            anim.SetBool("sidemovement", true);
            anim.SetBool("viool", false);
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {

            anim.SetBool("sidemovement", false);
            anim.SetBool("backmovement", false);
            anim.SetTrigger("anim");
            anim.SetBool("frontmovement", true);
            anim.SetBool("viool", false);
            //this.GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {

            anim.SetBool("frontmovement", false);
            anim.SetBool("sidemovement", false);
            anim.SetBool("viool", false);
            anim.SetBool("backmovement", true);
            //this.GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {

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
}
