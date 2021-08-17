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
        /// ���ӷ�����
        /// </summary>
        /// <param name="serverIp">������Ip</param>
        /// <param name="serverPort">�������˿�</param>
        /// <param name="isIpv6">�Ƿ�ʹ��ipv6</param>
        public void Connect(string serverIp,ushort serverPort,bool isIpv6 = false)
        {
            if(serverIp == "" || serverPort == 0)
            {
                Debug.Log(TAG + "��������ַ��˿ڴ���" + string.Format("ip:%s port: %d", serverIp, serverPort));
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

                //ip��ַ
                IPAddress iPAddress = IPAddress.Parse(serverIp);

                tcpClient.NoDelay = true;
                //�첽���ӣ����ӻص�AsyncReceive
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
        /// ����������
        /// </summary>
        public void ReConnect()
        {
            Connect(serverip, serverport, isipv6);
        }

        /// <summary>
        /// �رշ���������
        /// </summary>
        public void Closed()
        {
            tcpClient.Close();
        }

        //��ȡ����״̬
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

