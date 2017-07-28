using Mono.Data.Sqlite;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
/// <summary>
/// 游戏人物的移动和视觉的调整
/// </summary>
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]
public class GamePersonMove : MonoBehaviour {

    private float x;
    private float y;
    public float moveSpeed = 5.0f;
    public float speedAcceleration = 2.0f;
    public float playerMoveRoateSpeed = 4f;
    private Rigidbody _rigidbody;
    private CharacterController chController;
    void Start () {
       
        try
        {
            chController = GetComponent<CharacterController>();
            _rigidbody = GetComponent<Rigidbody>();
        }
        catch (System.Exception)
        {
            _rigidbody = null;
        }
    }
	
	// Update is called once per frame
	void Update () {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        PlayerMoves();
    }

    Vector3 jumpDirection;
    bool isGround = true;
    /// <summary>
    /// 角色移动
    /// </summary>
    void PlayerMoves() {
        x=CrossPlatformInputManager.GetAxis("Horizontal");
        y=CrossPlatformInputManager.GetAxis("Vertical");
       
        
        if (Mathf.Abs(x) > 0.1f || Mathf.Abs(y) > 0.1f) {
            if (PlayerAutoNav._instance!=null)
            PlayerAutoNav._instance.StopNav();
        }
        PersonJump();
        if (Mathf.Abs(y) > 0) {
            //可以移动
            float move = moveSpeed;
            //计算前后左右的移动距离
            Vector3 moveDir = (Vector3.forward * y) + (Vector3.right * x);
            //是否有加速
            if (Input.GetKey(KeyCode.LeftShift))
            {

                move *= speedAcceleration;
            }
            //(1) charactor Controller的移动方式
            moveDir = transform.TransformDirection(moveDir* move);
            chController.Move(moveDir.normalized * move * Time.deltaTime);
            // Debug.Log("movespeed="+ move);
            //(2)自己控制的移动
            // transform.Translate(moveDir.normalized * move * Time.deltaTime, Space.Self);  
        }

        //人物的转向
        if (Mathf.Abs(x) < 30) {
            //Vector3 ff = new Vector3(x*0.5f, 0, y);
            //transform.rotation = Quaternion.LookRotation(ff);
            transform.Rotate(transform.up, x * playerMoveRoateSpeed);
        }
       
    }

    /// <summary>
    /// 和地面的collider发生碰撞
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Terrain") {
            isGround = true;//是否落地
            isSecondJump = false;
           // print("落地了");
        }
    }




    private bool isSecondJump=false;
    private int jumpCount = 0;
    public float gravity = 20f;
    public float jumpHigh = 20f;
    private Vector3 moveDirection = Vector3.zero;
    /// <summary>
    /// 跳跃
    /// </summary>
    void PersonJump() {
     
        //跳跃
        if (Input.GetKeyDown(KeyCode.Space))
        {           
            if (_rigidbody != null)
            {
                moveDirection.y = jumpHigh;
                isGround = false;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        //其实这个也可以用来做人物的移动
        chController.Move(moveDirection * Time.deltaTime);
    }


}
