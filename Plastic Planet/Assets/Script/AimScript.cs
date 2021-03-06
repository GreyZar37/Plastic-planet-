using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AimScript : MonoBehaviour
{
    public GameManager gameManager;

    public float throwSpeed;
    public static float returnSpeed;
    float drag;

    public GameObject CmVcam;
    public GameObject raft;

    public static bool tooHeavy;

    public Transform hookPosition;

    public static bool thrown;
    bool notEnoughRope;

    public static float ropeLength;


    Rigidbody2D rb;


    Vector2 startPos;
    Vector2 endPos;

    public AudioClip throwHook;
    public AudioSource audioSource;
   

    LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource.GetComponent<AudioSource>();

        ropeLength = gameManager.ropeLength;
        drag = gameManager.Strength - ShootHook.trashWeight;
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, hookPosition.position);

        throwSpeed = gameManager.Strength;
        
        if (Input.GetKeyDown(KeyCode.Space) && thrown == true)
        {
            ropeLength = 0;
        }
      

        shoot();
        rotateHook();
    }

    void rotateHook()
    {
        if(thrown == false)
        {
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y <= -1.2f)
            {
                Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion roatation = Quaternion.AngleAxis(Mathf.Clamp(angle, -160.5f, -10.5f), Vector3.forward);

                transform.rotation = Quaternion.Slerp(transform.rotation, roatation, 1);
            }
        }
  
    }

    void shoot()
    {

        drag = gameManager.Strength - ShootHook.trashWeight;


        tooHeavy = drag < 0.4f;
   

        if (tooHeavy == false)
        {
            returnSpeed = drag; 
        }
        else
        {
            returnSpeed = gameManager.Strength;
            ropeLength = 0;
        }
        


        if (Input.GetMouseButtonDown(0) && thrown == false && SellTrash.inShop == false && gameManager.gamePaused == false)
        {
            lineRenderer.enabled = true;
            audioSource.PlayOneShot(throwHook);
            CmVcam.GetComponent<CinemachineVirtualCamera>().Follow = gameObject.transform;
            ShootHook.currentItem = "";
           
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPos = transform.position;
            thrown = true;
        }



        if (thrown == true && notEnoughRope == false)
        {


            rb.velocity = transform.right * throwSpeed;
           
            if ((startPos - (Vector2)transform.position).magnitude >= ropeLength)
            {
                notEnoughRope = true;
                rb.velocity = endPos.normalized * throwSpeed * 0;
            }
        }
       
        if(notEnoughRope == true)
        {
            rb.velocity = -transform.right * returnSpeed;
            if (Mathf.Abs(transform.position.y - startPos.y) <= 0.1f)
            {
                CmVcam.GetComponent<CinemachineVirtualCamera>().Follow = raft.transform;
                lineRenderer.enabled = false;
                notEnoughRope = false;
                ShootHook.trashWeight = 0;

                thrown = false;
                ShootHook.currentItem = "";
                ropeLength = gameManager.ropeLength;
            }
        }

        if (thrown == false)
        {
            transform.position = hookPosition.position;
        }


      
    }

   

}
