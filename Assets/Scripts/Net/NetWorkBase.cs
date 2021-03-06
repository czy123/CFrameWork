using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System;

//网络模块基类
namespace CFramework.Network
{
    public abstract class NetWorkBase :INetWork
    {
        const string TAG = "NetWorkBase----------->";

        //当前网络名称
        public string netName {
            get;
        }

        //当前使用的tcp
        public TcpClient tcpClient
        {
            get;
        }

        //当前是否连接
        public bool isConnect
        {
            get;
        }

        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <param name="serverIp">服务器Ip</param>
        /// <param name="serverPort">服务器端口</param>
        public void Connect(string serverIp, ushort serverPort)
        {
            if (serverIp == "" || serverPort == 0)
            {
                Debug.Log(TAG + "服务器地址或端口错误" + string.Format("ip:%s port: %d", serverIp, serverPort));
            }
        }

        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <param name="serverIp">服务器Ip</param>
        /// <param name="serverPort">服务器端口</param>
        /// <param name="isIpv6">是否使用ipv6 默认ipv4</param>
        public void Connect(string serverIp, ushort serverPort, bool isIpv6 = false)
        {

        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close()
        {

        }

        /// <summary>
        /// 向服务器发送数据
        /// </summary>
        /// <typeparam name="T">消息包类型</typeparam>
        /// <param name="package">消息包具体数据</param>
        public void Send<T>(T package) where T : Packet
        {

        }

    }
}

