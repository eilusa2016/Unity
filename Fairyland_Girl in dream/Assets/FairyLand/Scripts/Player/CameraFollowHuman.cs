using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
/// <summary>
/// 摄像机跟随主角
/// （最简单的就是放在人物的物体下面）
/// </summary>
public class CameraFollowHuman : MonoBehaviour {

    public static CameraFollowHuman _instance;
    public Transform target;//需要跟随的目标
    //需要跟随的摄像机
    public Transform _camera;
    /// <summary>
    /// 转动的速度
    /// </summary>
    public float rotSpeed=4.0f;
    public bool isXaxisReverse = false;//x轴是否反向
    public bool isYaxisReverse = true;//y轴是否反向
    private float xAxis;//鼠标x移动距离
    private float yAxis;//鼠标y轴移动具体
    public float MinimumX = -90F;//绕x轴旋转角度，低头极限
    public float MaximumX = 90F;//绕x轴旋转角度，抬头极限

    Vector3 offset;//摄像机和人物之间的偏移
    private float distance;
    public float height = 3.0f;//摄像机的高度
    public Transform LookAtPos;
    private void Awake()
    {
        _instance = this;
    }

    void Start () {
        offset = _camera.position - target.position;
        distance =Mathf.Abs(_camera.position.z - target.position.z);
        height = Mathf.Abs(_camera.position.y - target.position.y);
    }
	
	/// <summary>
    /// update后调用
    /// 目标移动停止后调用该函数
    /// </summary>
	void LateUpdate() {
        ///上面的写法问题比较大   不是很好  旋转什么的  不好调整
        ///
        _camera.position = target.position + offset;
        if (Input.GetKey(KeyCode.C)) {
            //看向角色的正前方  还没有完善好。。。。。。？？？
            //需要参照物  跟随人物移动的参照物
            //摄像机朝向目标
           //  camera.LookAt(target);
        }
        Rotate();
        Scale();
    }

    /// <summary>
    /// 缩放
    /// </summary>
    private void Scale()
    {
        float dis = offset.magnitude;
        dis += CrossPlatformInputManager.GetAxis("Mouse ScrollWheel") * 5;
      //  Debug.Log("dis=" + dis);
        if (dis < 10 || dis > 60)
        {
            return;
        }
        offset = offset.normalized * dis;
    }
    //左右上下移动
    private float camHeight;
    private void Rotate()
    {
        xAxis = 0f;
        yAxis = 0f;
        if (Input.GetMouseButton(1))
        {
            xAxis = CrossPlatformInputManager.GetAxis("Mouse X");
            yAxis = CrossPlatformInputManager.GetAxis("Mouse Y");
        }
        CameraRotate(xAxis, yAxis);
    }


   
    /// <summary>
    /// 相机跟随
    /// </summary>
    /// <param name="h"></param>
    /// <param name="v"></param>
    void CameraRotate(float h, float v) {

        camHeight = yAxis;
        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        xAxis = (h == 0f) ? x : xAxis;
        if (isXaxisReverse)
        {
            xAxis = -xAxis;
        }
        if (isYaxisReverse)
        {
            camHeight = -yAxis;
        }

        //Debug.Log("xAxis="+ xAxis);
        //第一个参数是绕着谁旋转  沿着那个轴旋转  最后一个是旋转距离
        _camera.RotateAround(target.position, Vector3.up, xAxis * rotSpeed);
        //但是垂直的旋转比较困难
        if (Mathf.Abs(yAxis) > 0.1f)
        {
            //这种当时有待调优  需要参照物   而且参照物需要绕着y轴自己旋转
           // _camera.RotateAround(target.position, Vector3.right, yAxis * rotSpeed);
            //y轴旋转
            _camera.position = Vector3.Lerp(_camera.position, _camera.position + (_camera.up * camHeight), Time.deltaTime * rotSpeed);
            Quaternion qu = Quaternion.Euler(camHeight, 0, 0);
            //旋转
           _camera.Rotate(ClampRotationAroundXAxis(qu).eulerAngles);
        }

        if (LookAtPos != null&& Mathf.Abs(xAxis) > 0.1f) {
            //水平围绕人物旋转的时候使用
            _camera.LookAt(LookAtPos);
        } 
        //  更新相对差值
        offset = _camera.position - target.position;
    }
    /// <summary>
    /// 计算俯视角度
    /// </summary>
    /// <param name="q"></param>
    /// <returns></returns>
    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;
        //Rad2Deg 弧度数转换为角度数
        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
        // 限制value的值在min和max之间
        angleX = Mathf.Clamp(angleX, MinimumX, MaximumX);
        //计算并返回以弧度为单位 f 指定角度的正切值
        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }
    /// <summary>
    /// 计算夹角
    /// </summary>
    /// <param name="from_"></param>
    /// <param name="to_"></param>
    /// <returns></returns>
    float angle_360(Vector3 from_, Vector3 to_)
    {
        Vector3 v3 = Vector3.Cross(from_, to_);
        if (v3.z > 0)
            return Vector3.Angle(from_, to_);
        else
            return 360 - Vector3.Angle(from_, to_);
    }

}
