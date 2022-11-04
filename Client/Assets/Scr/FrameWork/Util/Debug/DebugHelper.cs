#define OPEN_DEBUG_MODE
#define Working_Debugger
#if UNITY_STANDALONE

#endif
using System;
using UnityEngine;
using UnityEngine.Assertions;
namespace GameFrameWork.DebugTools
{
    /// <summary>
    /// debug用的对外的
    /// </summary>
    public class DebugHelper
    {
        /// <summary>
        /// 配置
        /// </summary>
        public static DebugManagerConfig s_config = new DebugManagerConfig() { m_bShowFPS = true,m_bSaveLog = true, m_bDebugWork = true, m_bShowDebugWindow = true };
        /// <summary>
        /// 是否工作
        /// </summary>
        public static bool DebugWork
        {
            get => s_config.m_bDebugWork;
            set 
            {
                s_config.m_bDebugWork = value;
                Debug.unityLogger.logEnabled = value;
            }
        }
        /// <summary>
        /// 是否显示界面
        /// </summary>
        public static bool ShowWindow
        {
            get => s_config.m_bDebugWork ? s_config.m_bShowDebugWindow:false;
            set => s_config.m_bSaveLog = value;
        }
        /// <summary>
        /// 是否保存log日志
        /// </summary>
        public static bool SaveLog
        {
            get {
#if UNITY_IOS || UNITY_IPHONE
                return false;
#else
                return s_config.m_bDebugWork? s_config.m_bSaveLog: false;
#endif
            }
            
            set => s_config.m_bSaveLog = value;
        }

        public static bool SendLog
        {
            get => s_config.m_bDebugWork ? s_config.m_bSendLog : false;
            set => s_config.m_bSendLog = value;
        }
        /// <summary>
        /// 是否显示fps
        /// </summary>
        public static bool ShowFPS
        {
            //get => s_config.m_bDebugWork ? s_config.m_bShowFPS : false;
            //set
            //{
            //    if (!s_config.m_bDebugWork) return;
            //    s_config.m_bShowFPS = value;
            //    DebugManager.Instance.ShowFPSTip(value);
            //}
            get => s_config.m_bShowFPS;
            set {
                s_config.m_bShowFPS = value;
                DebugManager.Instance.ShowFPSTip(value); 
            }
        }

        public static void Log(string str, DebugTypeEnum type = DebugTypeEnum.Base)
        {

            if (!DebugWork)
                return;

            if (string.IsNullOrEmpty(str))
                return;

            //if (Application.isPlaying)
            {
                if (ShowWindow)
                    DebugManager.GetInstance().AddData(type, str);
                if (SendLog)
                {

                }
                if (SaveLog)
                    DebugManager.Instance.m_logFile.AddLog(str);
            }
            Debug.Log(type.ToString() + " time = " + System.DateTime.Now.ToString() + " log :   " + str);
        }
        /// <summary>
        /// 为了防止在外面组装string，控制不了
        /// </summary>
        /// <param name="strFunc"></param>
        /// <param name="type"></param>
        public static void Log(Func<string> strFunc, DebugTypeEnum type = DebugTypeEnum.Base)
        {

            if (!DebugWork)
                return;
            string str = string.Empty;
            if (strFunc != null)
                str = strFunc();
            else
                return;
            Log(str, type);
        }

        public static void LogWarning(string str, DebugTypeEnum type = DebugTypeEnum.Base)
        {

            if (!DebugWork)
                return;

            if (string.IsNullOrEmpty(str))
                return;

            if (ShowWindow)
                DebugManager.GetInstance().AddData(type, str);
            if (SendLog)
            {

            }
            if (SaveLog)
                DebugManager.Instance.m_logFile.AddLog(str);
            Debug.LogWarning(type.ToString() + " time = " + System.DateTime.Now.ToString() + " log :   " + str);
        }

        public static void LogWarning(Func<string> strFunc, DebugTypeEnum type = DebugTypeEnum.Base)
        {

            if (!DebugWork)
                return;
            string str = string.Empty;
            if (strFunc != null)
                str = strFunc();
            else
                return;

            LogWarning(str, type);
           
        }

        public static void LogColor(string str,string color )
        {
            if (!DebugWork)
                return;

            if (string.IsNullOrEmpty(str))
                return;

            if (ShowWindow)
                DebugManager.GetInstance().AddData( DebugTypeEnum.Base, str);
            if (SendLog)
            {

            }
            if (SaveLog)
                DebugManager.Instance.m_logFile.AddLog(str);
            Debug.Log(string.Format("<color={2}> time ={0}   log :   </color> {1}", System.DateTime.Now.ToString() ,str, color));
        }

        public static void LogColor(Func<string> strFunc, string color)
        {
            if (!DebugWork)
                return;

            string str = string.Empty;
            if (strFunc != null)
                str = strFunc();
            else
                return;

            LogColor(str, color);
        }

        public static void LogError(string str, DebugTypeEnum type = DebugTypeEnum.Base)
        {
            if (!DebugWork)
                return;

            if (string.IsNullOrEmpty(str))
                return;
            if (ShowWindow)
                DebugManager.GetInstance().AddData(type, str);
            if (SaveLog)
                DebugManager.Instance.m_logFile.AddLog(str);
            Debug.LogError(type.ToString() + " time = " + System.DateTime.Now.ToString() + " log :   " + str);
        }

        public static void LogError(Func<string> strFunc, DebugTypeEnum type = DebugTypeEnum.Base)
        {
            if (!DebugWork)
                return;

            string str = string.Empty;
            if (strFunc != null)
                str = strFunc();
            else
                return;
            LogError(str, type);
        }

        public static void DebugManagerInit()
        {
            if (!DebugWork)
                return;
            if (ShowWindow)
                DebugManager.GetInstance().CreateDebugWindow();
        }
    }
}


