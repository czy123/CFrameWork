using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;

//����ģ�����
namespace CFramework.Network
{
    public interface NetWorkBase
    {
        //��ǰ��������
        string netName {
            get;
        }

        //��ǰʹ�õ�tcp
        TcpClient tcpClient
        {
            get;
        }

        //��ǰ�Ƿ�����
        bool isConnect
        {
            get;
        }


        
    }
}

