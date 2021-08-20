using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CFramework.Network
{
    /// <summary>
    /// ���紦��ӿ�
    /// </summary>
    public interface INetWork
    {
        //��ǰ��������
        string netName
        {
            get;
        }

        //��ǰ�Ƿ�����
        bool isConnect
        {
            get;
        }

        /// <summary>
        /// ���ӷ�����
        /// </summary>
        /// <param name="serverIp">������Ip</param>
        /// <param name="serverPort">�������˿�</param>
        void Connect(string serverIp, ushort serverPort);

        /// <summary>
        /// ���ӷ�����
        /// </summary>
        /// <param name="serverIp">������Ip</param>
        /// <param name="serverPort">�������˿�</param>
        /// <param name="isIpv6">�Ƿ�ʹ��ipv6 Ĭ��ipv4</param>
        void Connect(string serverIp, ushort serverPort, bool isIpv6 = false);

        /// <summary>
        /// �ر�����
        /// </summary>
        void Close();

        /// <summary>
        /// ���������������
        /// </summary>
        /// <typeparam name="T">��Ϣ������</typeparam>
        /// <param name="package">��Ϣ����������</param>
        void Send<T>(T package) where T : Packet;
    }
}

