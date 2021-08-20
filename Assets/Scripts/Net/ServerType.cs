using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CFramework.Network
{
    /// <summary>
    /// �����������
    /// </summary>
    public enum ServerType
    {
        TCP = 0,

        /// <summary>
        /// ͬ������tcp �������
        /// </summary>
        TCPWITHSYNC = 1,

        KCP = 2,

        UDP = 3
    }
}


