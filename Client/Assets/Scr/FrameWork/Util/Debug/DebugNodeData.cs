//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.19408
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------
using UnityEngine;
using System;

namespace GameFrameWork.DebugTools
{
    internal class DebugNodeData
    {
        private string m_data;
        private System.DateTime m_time;
        public DebugNodeData(string data)
        {
            m_data = data;
            m_time = System.DateTime.Now.ToLocalTime();
        }
        public override string ToString()
        {
            return string.Format("{0}  {1}", m_time.ToLongDateString(), m_data);
        }
    }
}


