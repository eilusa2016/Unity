
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
/// <summary>
/// 播放人物的动画的类
/// </summary>
public class PlayerGirlMoveAnimation : MonoBehaviour {


    public static PlayerGirlMoveAnimation _instance;
    private Animator anim;
    private Rigidbody rigdbody;
    private void Awake()
    {
        _instance = this;
        anim = GetComponent<Animator>();
        rigdbody= GetComponent<Rigidbody>();
    }



    private void Update()
    {
        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float y = CrossPlatformInputManager.GetAxis("Vertical");
        if (Mathf.Abs(y) < 0.001f) {
            rigdbody.velocity = Vector3.zero;
        }
        PlayerMove(x, y);

    }
    
    public void PlayerMove(float x,float y)
    {
       // print("Mathf.Abs(rigdbody.velocity.magnitude)=" + Mathf.Abs(rigdbody.velocity.magnitude));
        //判断是否有速度
        if (Mathf.Abs(rigdbody.velocity.magnitude) > 0|| Mathf.Abs(y) > 0|| Mathf.Abs(x) > 0)
        {
            anim.SetBool("canRun", true);
        }
        else
        {
            anim.SetBool("canRun", false);
        }

        //if (Mathf.Abs(y) > 0)
        //{
        //    anim.SetBool("canRun", true);
        //}
        //else
        //{
        //    anim.SetBool("canRun", false);
        //}

    }
    /// <summary>
    /// 人物移动
    /// 方法闲置
    /// </summary>
    /// <param name="rigidbody">人物身上的钢体</param>
    public void PlayerMove(Rigidbody rigidbody) {
            //判断是否有速度
            if (Mathf.Abs(rigidbody.velocity.magnitude) > 0.01f)
            {
                anim.SetBool("canRun", true);
            }
            else {
                anim.SetBool("canRun", false);
            }
        }


}
