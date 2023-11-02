using UnityEngine;

public class MainCameraControl : MonoBehaviour 
{
    public float targetWidth = 1920f;
    public float targetHeight = 1080f;

    private void Start()
    {
        // 获取相机组件
        Camera mainCamera = this.gameObject.GetComponent<Camera>();

        // 计算目标视口的宽高比
        float targetAspect = targetWidth / targetHeight;

        // 获取默认视口的宽高比
        float defaultAspect = mainCamera.aspect;

        // 计算相机高度的缩放比例
        float scaleHeight = targetAspect / defaultAspect;

        // 根据缩放比例调整相机的高度
        this.transform.position = new Vector3(this.transform.position.x, (float) (this.transform.position.y * scaleHeight), this.transform.position.z);
    }
}