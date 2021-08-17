using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System;

namespace CFramework.Network
{
    public class NetManager : MonoBehaviour
    {
        //Dictionary<string>
        const string TAG = "NetManager----------->";
       
        //tcp
        public TcpClient tcpClient;

        private string serverip;
        private ushort serverport;
        private bool isipv6;


        public NetManager()
        {

        }

        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <param name="serverIp">服务器Ip</param>
        /// <param name="serverPort">服务器端口</param>
        /// <param name="isIpv6">是否使用ipv6</param>
        public void Connect(string serverIp,ushort serverPort,bool isIpv6 = false)
        {
            if(serverIp == "" || serverPort == 0)
            {
                Debug.Log(TAG + "服务器地址或端口错误" + string.Format("ip:%s port: %d", serverIp, serverPort));
            }

            this.serverip = serverIp;
            this.serverport = serverPort;
            this.isipv6 = isIpv6;

            try
            {

                if (isIpv6)
                {
                    tcpClient = new TcpClient(AddressFamily.InterNetworkV6);
                }
                else 
                {
                    tcpClient = new TcpClient(AddressFamily.InterNetwork);
                }

                //ip地址
                IPAddress iPAddress = IPAddress.Parse(serverIp);

                tcpClient.NoDelay = true;
                //异步连接，连接回调AsyncReceive
                IAsyncResult result = tcpClient.BeginConnect(iPAddress,serverPort, AsyncReceive, tcpClient);

            }
            catch (SocketException e)
            {

            }
       
        }

        void AsyncReceive(IAsyncResult async)
        {

        }

        /// <summary>
        /// 服务器重连
        /// </summary>
        public void ReConnect()
        {
            Connect(serverip, serverport, isipv6);
        }

        /// <summary>
        /// 关闭服务器连接
        /// </summary>
        public void Closed()
        {
            tcpClient.Close();
        }

        //获取连接状态
        public bool IsConnect()
        {
            if(tcpClient != null)
            {
                return tcpClient.Connected;
            }
            return false;
        }

    }
}

