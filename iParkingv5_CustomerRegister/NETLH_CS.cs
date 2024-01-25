using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5_CustomerRegister
{
    public partial class BRNETLH
    {
        public static UInt16 _ErrFlag = 0;

        public int Version { get { return 100; } }

        public const ushort CHAR_XALG_SIZE = 810;

        const int CMD_RT_OK = 0x0000;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct PARA_TABLE
        {
            public UInt32 dwProductSN;              //产品序列号
            public UInt32 dwFingerNum;              //指纹数量
            public UInt32 dwDeviceAddress;          //设备地址
            public UInt32 dwCommPassword;           //通信密码
            public UInt32 dwComBaudRate;            //串口波特率
            public UInt16 wCmosExposeTimer;         //CMOS曝光时间
            public byte cDetectSensitive;         //探测手指灵敏度20到100可调
            public byte cSecurLevel;              //指纹搜索安全级别
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public byte[] cManuFacture;         //生产厂商
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public byte[] cproductModel;        //产品型号
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public byte[] cSWVersion;           //软件版本
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] cReserve;
        };

        #region DLL 常规USB

        //extern BOOL WINAPI ConfigCommParameterUDisk(UINT32 _DeviceAdd, UINT32 _Password); 
        [DllImport("NETLH_E.dll", EntryPoint = "ConfigCommParameterUDisk", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        extern static Int32 ConfigCommParameterUDisk(UInt32 _DeviceAdd, UInt32 _Password);

        //void WINAPI CommClose(VOID);
        [DllImport("NETLH_E.dll", EntryPoint = "CommClose", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        extern static void CommClose();

        //BOOL WINAPI CreatBmp(char* _pFilePath, UINT8* _pImage, UINT32 _xLen, UINT32 _yLen)
        [DllImport("NETLH_E.dll", EntryPoint = "CreatBmp", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        extern static Int32 CreatBmp([In] byte[] _pFilePath, [In] byte[] _pImage, UInt32 _xLen, UInt32 _yLen);

        /// <summary>
        /// Retrieves the fingerprint image corrected by the algorithm
        /// </summary>
        /// <param name="_DetectDn"></param>
        /// <param name="_ErrFlag"></param>
        /// <returns></returns>
        [DllImport("NETLH_E.dll", EntryPoint = "CmdGetRedressImage", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        extern static Int32 CmdGetRedressImage(byte _DetectDn, ref UInt16 _ErrFlag);

        /// <summary>
        /// Generate a feature file based on the most recently acquired fingerprint image
        /// </summary>
        /// <param name="iBuffer"></param>
        /// <param name="_ErrFlag"></param>
        /// <returns></returns>
        [DllImport("NETLH_E.dll", EntryPoint = "CmdGenChar", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        extern static Int32 CmdGenChar(UInt32 iBuffer, ref UInt16 _ErrFlag);

        /// <summary>
        /// Compare the feature files generated twice in the eAlg algorithm to see if they belong to the same fingerprint;
        /// compare the feature files generated three times in the xAlg algorithm to see if they belong to the same fingerprint
        /// </summary>
        /// <param name="_RetScore"></param>
        /// <param name="_ErrFlag"></param>
        /// <returns></returns>
        [DllImport("NETLH_E.dll", EntryPoint = "CmdMergeChar", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        extern static Int32 CmdMergeChar(ref UInt16 _RetScore, ref UInt16 _ErrFlag);

        // extern BOOL WINAPI CmdStoreChar(UINT16 m_Addr, UINT16 *_RetMbIndex, UINT16 *_RetScore, UINT16 *_ErrFlag);
        [DllImport("NETLH_E.dll", EntryPoint = "CmdStoreChar", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        extern static Int32 CmdStoreChar(UInt16 m_Addr, ref UInt16 _RetMbIndex, ref UInt16 _RetScore, ref UInt16 _ErrFlag);

        //CmdStoreCharDirect 
        // extern BOOL WINAPI CmdStoreChar(UINT16 m_Addr, UINT16 *_RetMbIndex, UINT16 *_RetScore, UINT16 *_ErrFlag);
        [DllImport("NETLH_E.dll", EntryPoint = "CmdStoreCharDirect", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        extern static Int32 CmdStoreCharDirect(UInt16 m_Addr, ref UInt16 _RetMbIndex, ref UInt16 _RetScore, ref UInt16 _ErrFlag);

        // BOOL WINAPI CmdGetMBIndex(UINT8 *gMBIndex , UINT16 gMBIndexStart, UINT16 gMBIndexNum, UINT16 *_ErrFlag)
        [DllImport("NETLH_E.dll", EntryPoint = "CmdGetMBIndex", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        extern static Int32 CmdGetMBIndex([Out] byte[] MBIndex, UInt16 MBIndexStart, UInt16 MBIndexNum, ref UInt16 _ErrFlag);

        // extern BOOL WINAPI CmdSearchChar(UINT32 iBuffer,UINT16 *_RetMbIndex,UINT16 *_RetScore,UINT16 *_ErrFlag);
        [DllImport("NETLH_E.dll", EntryPoint = "CmdSearchChar", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        extern static Int32 CmdSearchChar(UInt32 iBuffer, ref UInt16 _RetMbIndex, ref UInt16 _RetScore, ref UInt16 _ErrFlag);

        //extern BOOL WINAPI CmdDelChar(UINT16 m_Addr, UINT16* _ErrFlag);
        [DllImport("NETLH_E.dll", EntryPoint = "CmdDelChar", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        extern static Int32 CmdDelChar(UInt16 m_Addr, ref UInt16 _ErrFlag);

        [DllImport("NETLH_E.dll", EntryPoint = "CmdUpLoadRedressImage", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        extern static Int32 CmdUpLoadRedressImage([Out] byte[] _ImageBuf);

        [DllImport("NETLH_E.dll", EntryPoint = "CmdUpLoadRedressImageHW", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        extern static Int32 CmdUpLoadRedressImageHW([Out] byte[] _ImageBuf, UInt32 _ImageW, UInt32 _ImageH);

        //BOOL WINAPI CmdEraseProgram(UINT16 *_ErrFlag);
        [DllImport("NETLH_E.dll", EntryPoint = "CmdEraseProgram", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        extern static Int32 CmdEraseProgram(ref UInt16 _ErrFlag);

        //extern BOOL WINAPI CmdDeviceReset(UINT16* _ErrFlag);
        [DllImport("NETLH_E.dll", EntryPoint = "CmdDeviceReset", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        extern static Int32 CmdDeviceReset(ref UInt16 _ErrFlag);

        // extern BOOL WINAPI CmdReadParaTable(PARA_TABLE *_ParaTable ,UINT16 *_ErrFlag);
        [DllImport("NETLH_E.dll", EntryPoint = "CmdReadParaTable", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        extern static Int32 CmdReadParaTable(ref PARA_TABLE _ParaTable, ref UInt16 _ErrFlag);

        //extern BOOL WINAPI CmdEmptyChar(UINT16 *_ErrFlag);
        [DllImport("NETLH_E.dll", EntryPoint = "CmdEmptyChar", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        extern static Int32 CmdEmptyChar(ref UInt16 _ErrFlag);

        //extern BOOL WINAPI CmdReadCharDirect(UINT32 m_Addr, UINT8* _FingerChar, UINT32 _CharSize, UINT16* _ErrFlag);
        /// <summary>
        /// Đọc thông tin vân tay
        /// </summary>
        /// <param name="m_Addr"></param>
        /// <param name="_FingerChar"></param>
        /// <param name="_CharSize"></param>
        /// <param name="_ErrFlag"></param>
        /// <returns></returns>
        [DllImport("NETLH_E.dll", EntryPoint = "CmdReadCharDirect", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        extern static Int32 CmdReadCharDirect(UInt32 m_Addr, [Out] byte[] _FingerChar, UInt32 _CharSize, ref UInt16 _ErrFlag);

        // extern BOOL WINAPI CmdStoreCharDirect(UINT32 m_Addr, UINT8* _FingerChar, UINT32 _CharSize, UINT16* _ErrFlag);
        [DllImport("NETLH_E.dll", EntryPoint = "CmdStoreCharDirect", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        extern static Int32 CmdStoreCharDirect(UInt32 m_Addr, [In] byte[] _FingerChar, UInt32 _CharSize, ref UInt16 _ErrFlag);

        // extern BOOL WINAPI CmdReadCharDirect_xAlg(UINT32 m_Addr, UINT8 *_FingerChar, UINT16 *_ErrFlag);
        [DllImport("NETLH_E.dll", EntryPoint = "CmdReadCharDirect_xAlg", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        extern static Int32 CmdReadCharDirect_xAlg(UInt32 m_Addr, [Out] byte[] _FingerChar, ref UInt16 _ErrFlag);

        #endregion 常规USB


        public static object BytesToStuct(byte[] bytes, Type type)
        {
            // byte[] 转结构体
            //得到结构体的大小
            int size = Marshal.SizeOf(type);
            //byte数组长度小于结构体的大小
            if (size > bytes.Length)
            {
                //返回空
                return null;
            }
            //分配结构体大小的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将byte数组拷到分配好的内存空间
            Marshal.Copy(bytes, 0, structPtr, size);
            //将内存空间转换为目标结构体
            object obj = Marshal.PtrToStructure(structPtr, type);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            //返回结构体
            return obj;
        }
        public static byte[] StructToBytes(object data, Type _type)
        {
            //计算对象长度
            int iAryLen = Marshal.SizeOf(_type);
            //根据长度定义一个数组
            byte[] databytes = new byte[iAryLen];

            //在非托管内存中分配一段iAryLen大小的空间
            IntPtr ptr = Marshal.AllocHGlobal(iAryLen);
            //将托管内存的东西发送给非托管内存上
            Marshal.StructureToPtr(data, ptr, true);
            //将bytes组数Copy到Ptr对应的空间中
            Marshal.Copy(ptr, databytes, 0, iAryLen);
            //释放非托管内存
            Marshal.FreeHGlobal(ptr);
            return databytes;
        }

        // 协议的设备地址
        private UInt32 deviceAdd = 0xffffffff;
        public UInt32 DeviceAdd
        {
            get => deviceAdd; set => deviceAdd = value;
        }

        // 协议的密码
        private UInt32 password = 0xffffffff;
        public UInt32 Password
        {
            get => password; set => password = value;
        }


        private char GetARandomChar(Random random)
        {
            char c = '?';

            while ((c > '9' && c < 'A') || (c > 'Z' && c < 'a'))
            {
                c = (char)(char)random.Next('0', 'z');
            }

            return c;
        }

        public char[] Byte2Char(byte[] a)
        {
            char[] b = new char[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                b[i] = (char)a[i];
            }
            return b;
        }
        public byte[] Char2Byte(char[] a)
        {
            byte[] b = new byte[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                b[i] = (byte)a[i];
            }
            return b;
        }


        static public bool Open()
        {
            Int32 res = ConfigCommParameterUDisk(0xffffffff, 0xffffffff);
            if (res == 1)
            {
                return true;
            }
            else
                return false;
        }

        static public void Close()
        {
            CommClose();
        }

        /// <summary>
        /// Generate a feature file based on the most recently acquired fingerprint image
        /// </summary>
        /// <param name="iBuffer"></param>
        /// <returns></returns>
        static public bool CmdGenChar(UInt32 iBuffer)
        {
            Int32 res = CmdGenChar(iBuffer, ref _ErrFlag);
            if (res == 1 && _ErrFlag == 0)
                return true;
            else
                return false;
        }
        //Int32 CmdMergeChar(ref UInt16 _RetScore, ref //UInt16 _ErrFlag);
        static public bool CmdMergeChar()
        {
            UInt16 _RetScore = 0;
            Int32 res = CmdMergeChar(ref _RetScore, ref _ErrFlag);
            if (res == 1 && _ErrFlag == 0)
                return true;
            else
                return false;
        }
        // extern static Int32 CmdStoreChar(UInt16 m_Addr, ref UInt16 _RetMbIndex, ref UInt16 _RetScore, ref //UInt16 _ErrFlag);
        static public bool CmdStoreChar(UInt16 m_Addr)
        {
            UInt16 _RetScore = 0;
            UInt16 _RetMbIndex = 0;
            Int32 res = CmdStoreChar(m_Addr, ref _RetMbIndex, ref _RetScore, ref _ErrFlag);
            if (res == 1 && _ErrFlag == 0)
                return true;
            else
            {
                res = CmdStoreChar(m_Addr, ref _RetMbIndex, ref _RetScore, ref _ErrFlag);
                if (res == 1 && _ErrFlag == 0)
                    return true;
                else
                {
                    return false;
                }
            }
        }
        static public bool CmdStoreCharDirect(UInt16 m_Addr)
        {
            UInt16 _RetScore = 0;
            UInt16 _RetMbIndex = 0;
            Int32 res = CmdStoreCharDirect(m_Addr, ref _RetMbIndex, ref _RetScore, ref _ErrFlag);
            if (res == 1 && _ErrFlag == 0)
                return true;
            else
                return false;
        }
        //static Int32 CmdSearchChar(UInt32 iBuffer, ref UInt16 _RetMbIndex, ref UInt16 _RetScore, ref //UInt16 _ErrFlag);
        static public bool CmdSearchChar(UInt32 iBuffer)
        {
            UInt16 _RetScore = 0;
            UInt16 _RetMbIndex = 0;
            Int32 res = CmdSearchChar(iBuffer, ref _RetMbIndex, ref _RetScore, ref _ErrFlag);
            if (res == 1 && _ErrFlag == 0)
                return true;
            else
                return false;
        }
        static public bool CmdSearchChar(UInt32 iBuffer, ref UInt16 _RetMbIndex)
        {
            //UInt16 _ErrFlag = 0;
            UInt16 _RetScore = 0;
            Int32 res = CmdSearchChar(iBuffer, ref _RetMbIndex, ref _RetScore, ref _ErrFlag);
            if (res == 1 && _ErrFlag == 0)
                return true;
            else
                return false;
        }

        //  extern static Int32 CmdDelChar(UInt16 m_Addr, ref //UInt16 _ErrFlag);
        static public bool CmdDelChar(UInt16 m_Addr)
        {
            //UInt16 _ErrFlag = 0;
            Int32 res = CmdDelChar(m_Addr, ref _ErrFlag);
            if (res == 1 && _ErrFlag == 0)
                return true;
            else
            {
                res = CmdDelChar(m_Addr, ref _ErrFlag);
                if (res == 1 && _ErrFlag == 0)
                    return true;
                else
                    return false;
            }
        }

        // extern static Int32 CmdGetMBIndex([Out] byte[] MBIndex, UInt16 MBIndexStart, UInt16 MBIndexNum, ref //UInt16 _ErrFlag);
        static public bool CmdReadParaTable(ref PARA_TABLE _ParaTable)
        {
            //UInt16 _ErrFlag = 0;
            Int32 res = CmdReadParaTable(ref _ParaTable, ref _ErrFlag);
            if (res == 1 && _ErrFlag == 0)
                return true;
            else
                return false;
        }

        // extern static Int32 CmdGetMBIndex([Out] byte[] MBIndex, UInt16 MBIndexStart, UInt16 MBIndexNum, ref //UInt16 _ErrFlag);
        static public bool CmdGetMBIndex([Out] byte[] MBIndex)
        {
            //UInt16 _ErrFlag = 0;
            Int32 res = CmdGetMBIndex(MBIndex, 0, 100, ref _ErrFlag);
            if (res == 1 && _ErrFlag == 0)
                return true;
            else
                return false;
        }

        // CmdEmptyChar
        static public bool CmdEmptyChar()
        {
            //UInt16 _ErrFlag = 0;
            Int32 res = CmdEmptyChar(ref _ErrFlag);
            if (res == 1 && _ErrFlag == 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Đọc thông tin vân tay
        /// </summary>
        /// <param name="m_Addr"></param>
        /// <param name="_FingerChar"></param>
        /// <param name="_CharSize"></param>
        /// <returns></returns>
        static public bool GetFingerData(UInt32 m_Addr, [Out] byte[] _FingerChar, UInt32 _CharSize)
        {
            //UInt16 _ErrFlag = 0;
            Int32 res = CmdReadCharDirect(m_Addr, _FingerChar, _CharSize, ref _ErrFlag);
            if (res == 1 && _ErrFlag == 0)
                return true;
            else
                return false;
        }

        // extern static Int32 CmdStoreCharDirect(UInt32 m_Addr, [In] byte[] _FingerChar, UInt32 _CharSize, ref //UInt16 _ErrFlag);
        static public bool CmdStoreCharDirect(UInt32 m_Addr, [In] byte[] _FingerChar, UInt32 _CharSize)
        {
            //UInt16 _ErrFlag = 0;
            Int32 res = CmdStoreCharDirect(m_Addr, _FingerChar, _CharSize, ref _ErrFlag);
            if (res == 1 && _ErrFlag == 0)
                return true;
            else
                return false;
        }

        static public bool CreatImageBMP(string _ImageName, [In] byte[] _pImage, UInt32 _xLen, UInt32 _yLen)
        {
            Int32 res = CreatBmp(System.Text.Encoding.Default.GetBytes(_ImageName), _pImage, _xLen, _yLen);
            if (res == 1)
                return true;
            else
                return false;
        }
        static public bool GetRedressImage()
        {
            //UInt16 _ErrFlag = 0xffff;
            Int32 res = CmdGetRedressImage(0, ref _ErrFlag);
            if (res == 1 && _ErrFlag == 0)
                return true;
            else
                return false;
        }
        static public bool GetRedressImage(ref UInt16 _Err)
        {
            //UInt16 _ErrFlag = 0xffff;
            Int32 res = CmdGetRedressImage(0, ref _ErrFlag);
            _Err = _ErrFlag;
            if (res == 1)
                return true;
            else
                return false;
        }
        static private bool _UploadImage(string _ImageName, [Out] byte[] _pImage, UInt32 ImageW, UInt32 ImageH)
        {
            bool savefile = _ImageName != string.Empty;
            byte[] inputbuf;
            if (!savefile)
            {
                if (_pImage != null && _pImage.Length < ImageW * ImageH)
                    return false;
                inputbuf = _pImage;
            }
            else
            {
                if (_pImage == null)
                {
                    inputbuf = new byte[ImageW * ImageH];
                }
                else
                {
                    if (_pImage.Length < ImageW * ImageH)
                        return false;
                    inputbuf = _pImage;
                }
            }
            Int32 res = CmdUpLoadRedressImageHW(inputbuf, ImageW, ImageH);
            if (res == 1)
            {
                if (savefile)
                {
                    CreatImageBMP(_ImageName, inputbuf, ImageW, ImageH);
                }
                return true;
            }
            else
                return false;
        }
        static public bool UploadImage(string _ImageName, [Out] byte[] _pImage, UInt32 ImageW, UInt32 ImageH)
        {
            return _UploadImage(_ImageName, _pImage, ImageW, ImageH);
        }

        static public bool UploadImage()
        {
            byte[] inputbuf = null;
            Int32 res = CmdUpLoadRedressImage(inputbuf);
            if (res == 1)
            {
                return true;
            }
            else
                return false;
        }
        static public bool UploadImage(string _ImageName, UInt32 ImageW, UInt32 ImageH)
        {
            return _UploadImage(_ImageName, null, ImageW, ImageH);
        }
        static public bool UploadImage([Out] byte[] _pImage, UInt32 ImageW, UInt32 ImageH)
        {
            return _UploadImage(string.Empty, _pImage, ImageW, ImageH);
        }
        static public bool UploadImage(UInt32 ImageW, UInt32 ImageH)
        {
            return _UploadImage(string.Empty, null, ImageW, ImageH);
        }

        enum EmError
        {
            /// <summary>
            /// Command Executed Successfully or OK
            /// </summary>
            CMD_RT_OK = 0,
            /// <summary>
            /// Data Packet Reception Error
            /// </summary>
            CMD_RT_PACKGE_ERR = 1,
            /// <summary>
            /// Device Address Error
            /// </summary>
            CMD_RT_DEVICE_ADDRESS_ERR = 2,
            /// <summary>
            /// Communication Password Error
            /// </summary>
            CMD_RT_COM_PASSWORD_ERR = 3,
            /// <summary>
            /// No Finger on the Sensor*
            /// </summary>
            CMD_RT_NO_FINGER = 4,
            /// <summary>
            /// Failed to Obtain Image from Sensor
            /// </summary>
            CMD_RT_GET_IMAGE_FAILE = 5,
            /// <summary>
            /// Feature Generation Failed
            /// </summary>
            CMD_RT_GEN_CHAR_ERR = 6,
            /// <summary>
            /// Fingerprint Mismatch
            /// </summary>
            CMD_RT_FINGER_MATCH_ERR = 7,
            /// <summary>
            /// Fingerprint Not Found
            /// </summary>
            CMD_RT_FINGER_SEARCH_FAILE = 8,
            /// <summary>
            /// Feature Merge Failed
            /// </summary>
            CMD_RT_MERGE_TEMPLET_FAILE = 9,
            /// <summary>
            /// Template Storage Address Exceeds Fingerprint Database Range
            /// </summary>
            CMD_RT_ADDRESS_OVERFLOW = 10,
            /// <summary>
            /// Error Reading Template from Fingerprint Database
            /// </summary>
            CMD_RT_READ_TEMPLET_ERR = 11,
            /// <summary>
            /// Upload Feature Failed
            /// </summary>
            CMD_RT_UP_TEMPLET_ERR = 12,
            /// <summary>
            /// Upload Image Failed
            /// </summary>
            CMD_RT_UP_IMAGE_FAILE = 13,
            /// <summary>
            /// Delete Template Failed
            /// </summary>
            CMD_RT_DELETE_TEMPLET_ERR = 14,
            /// <summary>
            /// Clear Fingerprint Database Failed
            /// </summary>
            CMD_RT_CLEAR_TEMPLET_LIB_ERR = 15,
            /// <summary>
            /// Residual Fingerprint or Finger Not Removed from Sensor Window for Long Time
            /// </summary>
            CMD_RT_FINGER_NOT_MOVE = 16,
            /// <summary>
            /// No Valid Template at the Specified Position
            /// </summary>
            CMD_RT_NO_TEMPLET_IN_ADDRESS = 17,
            /// <summary>
            /// Duplicate Fingerprint, Fingerprint Already Registered in FLASH
            /// </summary>
            CMD_RT_CHAR_REPEAT = 18,
            /// <summary>
            /// No Fingerprint Template at This Address
            /// </summary>
            CMD_RT_MB_NOT_EXIST_IN_ADDRESS = 19,
            /// <summary>
            /// Template Index Length Overflow
            /// </summary>
            CMD_RT_GET_MBINDEX_OVERFLOW = 20,
            /// <summary>
            /// Set Baud Rate Failed
            /// </summary>
            CMD_RT_SET_BAUD_RATE_FAILE = 21,
            /// <summary>
            /// Erase Program Flag Failed
            /// </summary>
            CMD_RT_ERASE_FLAG_FAILE = 22,
            /// <summary>
            /// System Reset Failed
            /// </summary>
            CMD_RT_SYSTEM_RESET_FAILE = 23,
            /// <summary>
            /// Operation FLASH Error
            /// </summary>
            CMD_RT_OPERATION_FLASH_ERR = 24,
            /// <summary>
            /// Notepad Address Overflow
            /// </summary>
            CMD_RT_NOTE_BOOK_ADDRESS_OVERFLOW = 24,
            /// <summary>
            /// Parameter Setting Error
            /// </summary>
            CMD_RT_PARA_ERR = 25,
            /// <summary>
            /// Command Not Found
            /// </summary>
            CMD_RT_NO_CMD = 26,
        }
        public static string GetLastErrorMessage()
        {
            switch ((EmError)_ErrFlag)
            {
                case EmError.CMD_RT_OK:
                    return "OK";
                case EmError.CMD_RT_PACKGE_ERR:
                    return "Data Packet Reception Error";
                case EmError.CMD_RT_DEVICE_ADDRESS_ERR:
                    return "Device Address Error";
                case EmError.CMD_RT_COM_PASSWORD_ERR:
                    return "Communication Password Error";
                case EmError.CMD_RT_NO_FINGER:
                    return "No Finger on the Sensor";
                case EmError.CMD_RT_GET_IMAGE_FAILE:
                    return "Failed to Obtain Image from Sensor";
                case EmError.CMD_RT_GEN_CHAR_ERR:
                    return "Feature Generation Failed";
                case EmError.CMD_RT_FINGER_MATCH_ERR:
                    return "Fingerprint Mismatch";
                case EmError.CMD_RT_FINGER_SEARCH_FAILE:
                    return "Fingerprint Not Found";
                case EmError.CMD_RT_MERGE_TEMPLET_FAILE:
                    return "Feature Merge Failed";
                case EmError.CMD_RT_ADDRESS_OVERFLOW:
                    return "Template Storage Address Exceeds Fingerprint Database Range";
                case EmError.CMD_RT_READ_TEMPLET_ERR:
                    return "Error Reading Template from Fingerprint Database";
                case EmError.CMD_RT_UP_TEMPLET_ERR:
                    return "Upload Feature Failed";
                case EmError.CMD_RT_UP_IMAGE_FAILE:
                    return "Upload Image Failed";
                case EmError.CMD_RT_DELETE_TEMPLET_ERR:
                    return "Delete Template Failed";
                case EmError.CMD_RT_CLEAR_TEMPLET_LIB_ERR:
                    return "Clear Fingerprint Database Failed";
                case EmError.CMD_RT_FINGER_NOT_MOVE:
                    return "Residual Fingerprint or Finger Not Removed from Sensor Window for Long Time";
                case EmError.CMD_RT_NO_TEMPLET_IN_ADDRESS:
                    return "No Valid Template at the Specified Position";
                case EmError.CMD_RT_CHAR_REPEAT:
                    return "Vân tay đã được đăng ký";
                case EmError.CMD_RT_MB_NOT_EXIST_IN_ADDRESS:
                    return "No Fingerprint Template at This Address";
                case EmError.CMD_RT_GET_MBINDEX_OVERFLOW:
                    return "Template Index Length Overflow";
                case EmError.CMD_RT_SET_BAUD_RATE_FAILE:
                    return "Set Baud Rate Failed";
                case EmError.CMD_RT_ERASE_FLAG_FAILE:
                    return "Erase Program Flag Failed";
                case EmError.CMD_RT_SYSTEM_RESET_FAILE:
                    return "System Reset Failed";
                case EmError.CMD_RT_OPERATION_FLASH_ERR:
                    return "Operation FLASH Error";
                case EmError.CMD_RT_PARA_ERR:
                    return "Parameter Setting Error";
                case EmError.CMD_RT_NO_CMD:
                    return "Command Not Found";
                default:
                    return string.Empty;
            }
        }
    }
}
