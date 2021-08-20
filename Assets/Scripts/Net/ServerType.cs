using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CFramework.Network
{
    /// <summary>
    /// 网络服务类型
    /// </summary>
    public enum ServerType
    {
        TCP = 0,

        /// <summary>
        /// 同步接收tcp 网络服务
        /// </summary>
        TCPWITHSYNC = 1,

        KCP = 2,

        UDP = 3
    }
}


