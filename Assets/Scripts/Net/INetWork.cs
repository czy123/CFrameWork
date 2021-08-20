using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CFramework.Network
{
    /// <summary>
    /// 网络处理接口
    /// </summary>
    public interface INetWork
    {
        //当前网络名称
        string netName
        {
            get;
        }

        //当前是否连接
        bool isConnect
        {
            get;
        }

        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <param name="serverIp">服务器Ip</param>
        /// <param name="serverPort">服务器端口</param>
        void Connect(string serverIp, ushort serverPort);

        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <param name="serverIp">服务器Ip</param>
        /// <param name="serverPort">服务器端口</param>
        /// <param name="isIpv6">是否使用ipv6 默认ipv4</param>
        void Connect(string serverIp, ushort serverPort, bool isIpv6 = false);

        /// <summary>
        /// 关闭连接
        /// </summary>
        void Close();

        /// <summary>
        /// 向服务器发送数据
        /// </summary>
        /// <typeparam name="T">消息包类型</typeparam>
        /// <param name="package">消息包具体数据</param>
        void Send<T>(T package) where T : Packet;
    }
}

