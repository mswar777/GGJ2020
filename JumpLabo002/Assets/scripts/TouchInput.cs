﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var info = JpUtil.Touch.GetTouch();
        if (info != JpUtil.TouchInfo.None)
        {
            Debug.Log("Touch " + info.ToString());
        }
    }
}

namespace JpUtil
{
    public static class Touch
    {
#if UNITY_EDITOR
        public const bool IsEditor = true;
#else
        public const bool IsEditor = false;
#endif
        private static Vector3 TouchPosition = Vector3.zero;

        /// <summary>
        /// タッチ情報を取得(エディタと実機を考慮)
        /// </summary>
        /// <returns>タッチ情報。タッチされていない場合は null</returns>
        public static TouchInfo GetTouch()
        {
            if (IsEditor)
            {
#if UNITY_EDITOR
                if (Input.GetKeyDown(KeyCode.Space)){ return TouchInfo.Began; }
                if (Input.GetKey(KeyCode.Space))    { return TouchInfo.Moved; }
                if (Input.GetKeyUp(KeyCode.Space))  { return TouchInfo.Ended; }
                
                if (Input.GetMouseButtonDown(0)) { return TouchInfo.Began; }
                if (Input.GetMouseButton(0))     { return TouchInfo.Moved; }
                if (Input.GetMouseButtonUp(0))   { return TouchInfo.Ended; }
#endif                
            }
            else
            {
#if !UNITY_EDITOR                
                if (Input.touchCount > 0)
                {
                    return (TouchInfo)((int)Input.GetTouch(0).phase);
                } 
#endif                
            }
            return TouchInfo.None;
        }

        /// <summary>
        /// タッチポジションを取得(エディタと実機を考慮)
        /// </summary>
        /// <returns>タッチポジション。タッチされていない場合は (0, 0, 0)</returns>
        public static Vector3 GetTouchPosition()
        {
            if (IsEditor)
            {
#if UNITY_EDITOR                
                TouchInfo touch = JpUtil.Touch.GetTouch();
                if (touch != TouchInfo.None) { return Input.mousePosition; }
#endif
            }
            else
            {
#if !UNITY_EDITOR
                if (Input.touchCount > 0)
                {
                    var touch = Input.GetTouch(0);
                    TouchPosition.x = touch.position.x;
                    TouchPosition.y = touch.position.y;
                    return TouchPosition;
                }
#endif                
            }
            return Vector3.zero;
        }

        /// <summary>
        /// タッチワールドポジションを取得(エディタと実機を考慮)
        /// </summary>
        /// <param name='camera'>カメラ</param>
        /// <returns>タッチワールドポジション。タッチされていない場合は (0, 0, 0)</returns>
        public static Vector3 GetTouchWorldPosition(Camera camera)
        {
            return camera.ScreenToWorldPoint(GetTouchPosition());
        }
    }

    /// <summary>
    /// タッチ情報。UnityEngine.TouchPhase に None の情報を追加拡張。
    /// </summary>
    public enum TouchInfo
    {
        /// <summary>
        /// タッチなし
        /// </summary>
        None = 99,

        // 以下は UnityEngine.TouchPhase の値に対応
        /// <summary>
        /// タッチ開始
        /// </summary>
        Began = 0,
        /// <summary>
        /// タッチ移動
        /// </summary>
        Moved = 1,
        /// <summary>
        /// タッチ静止
        /// </summary>
        Stationary = 2,
        /// <summary>
        /// タッチ終了
        /// </summary>
        Ended = 3,
        /// <summary>
        /// タッチキャンセル
        /// </summary>
        Canceled = 4,
    }
}
