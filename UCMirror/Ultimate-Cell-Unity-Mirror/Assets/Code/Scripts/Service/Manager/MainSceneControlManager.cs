﻿using Common;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneControlManager : MonoBehaviour
{
    [Header("固定加载场景")]
    [SerializeField] public SceneReference[] sceneToLoads;

    private BroadcastClass broadcastClass;

    private void Start()
    {
        // 加载固定加载场景
        LoadSceneAdditive(sceneToLoads);
    }

    /// <summary>
    ///  加载指定的几个场景，在Mian场景下
    /// </summary>
    /// <param name="sceneToLoads"></param>
    public void LoadSceneAdditive(SceneReference[] sceneToLoads)
    {
        foreach (var sceneName in sceneToLoads)
        {
            try
            {
                SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            }
            catch (Exception e)
            {
                Debug.Log("场景：" + sceneName + "不存在， 请检查 File -> BuildSettings -> Scenes in Build 中是否存在该场景" + e);
            }
        }
    }


    /// <summary>
    /// 加载PVE场景
    /// </summary>
    public void LoadMainFightScene()
    {
        broadcastClass.Reload();

        ABManager.Instance.UnLoadAll();

        SceneManager.LoadScene("MainFightScene");

        Time.timeScale = 1.0f;
    }

    /// <summary>
    /// 加载主界面
    /// </summary>
    public void LoadMainBasicScene()
    {
        this.ClearAllDOTweenAnimations();

        ABManager.Instance.UnLoadAll();

        SceneManager.LoadScene("MainBasicScene");

        Time.timeScale = 1.0f;
    }

    /// <summary>
    /// 加载登陆界面
    /// </summary>
    public void LoadLoginScene()
    {
        broadcastClass.Reload();

        ABManager.Instance.UnLoadAll();

        SceneManager.LoadScene("MianLoginScene");

    }

    /// <summary>
    /// 加载玩家对战场景
    /// </summary>
    public void LoadMainFightScene(int info)
    {
        broadcastClass.Reload();

        ABManager.Instance.UnLoadAll();

        SceneManager.LoadScene("MainFightScene");

        Time.timeScale = 1.0f;
    }

    void ClearAllDOTweenAnimations()
    {
        // 停止并清空所有DOTween动画
        DOTween.KillAll();

        // 清空DOTween的缓存对象
        DOTween.Clear(true);

        // 重置DOTween的时间缩放因子
        DOTween.timeScale = 1f;
    }

}
