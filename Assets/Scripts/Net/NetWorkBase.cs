using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;

//网络模块基类
namespace CFramework.Network
{
    public interface NetWorkBase
    {
        //当前网络名称
        string netName {
            get;
        }

        //当前使用的tcp
        TcpClient tcpClient
        {
            get;
        }

        //当前是否连接
        bool isConnect
        {
            get;
        }


        
    }
}

