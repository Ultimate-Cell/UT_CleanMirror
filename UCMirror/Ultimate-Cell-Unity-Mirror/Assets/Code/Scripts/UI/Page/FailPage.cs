using GameFrameWork;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailPage : MonoBehaviour
{

    #region �������

    [Header("Canvas")]
    public Canvas canvas;

    [Header("��ť")]
    public Button backBtn;

    [Header("�ı�")]
    public Text infoText;

    [Header("��Ч")]
    public ParticleSystem failEffect;

    #endregion

    #region ҵ���߼�

    public void Start()
    {
        #region ����߼�
        //������Ҫ��UI�趨ΪScreenSpace
        Camera uiCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Canvas canvas = this.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = uiCam;
        canvas.sortingOrder = 200;
        canvas.planeDistance = 5;
        canvas.sortingLayerName = "Flow";
        #endregion

        Animation anim = GetComponent<Animation>();
        anim.Play("A_Fail");

        //������
        BtnEvent.RigisterButtonClickEvent(backBtn.transform.gameObject, p => { ClickBackBtn(); });

        Invoke("PlayEffect", 0.5f);
    }

    void PlayEffect()
    {
        failEffect.Play();
    }

    void ClickAgainBtn()
    {

    }

    void ClickBackBtn()
    {

    }

    #endregion
}
