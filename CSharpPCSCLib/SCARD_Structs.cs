/*
Copyright (c) 2011, Gerhard H. Schalk, www.smartcard-magic.net
All rights reserved.

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the 
documentation and/or other materials provided with the distribution.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT 
HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT 
LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON 
ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.*/
using System;
using System.Runtime.InteropServices;

namespace GS.SCard
{
    /// <summary>
    /// The SCARD_IO_REQUEST structure begins a protocol control information structure.
    /// Any protocol-specific information then immediately follows this structure.
    /// The entire length of the structure must be aligned with the underlying hardware
    /// architecture word size. For example, in Win32 the length of any PCI information
    /// must be a multiple of four bytes so that it aligns on a 32-bit boundary.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SCARD_IO_REQUEST
    {
        /// <summary>
        /// Protocol in use.
        /// </summary>
        public UInt32 dwProtocol;

        /// <summary>
        /// Length, in bytes, of the SCARD_IO_REQUEST structure plus any following PCI-specific information.
        /// </summary>
        public UInt32 cbPciLength;
    }

    /// <summary>
    /// The SCARD READERSTATE structure is used by functions for tracking smart cards within readers.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct SCARD_READERSTATE
    {
        /// <summary>
        /// A pointer to the name of the reader being monitored.
        /// Set the value of this member to "\\\\?PnP?\\Notification" 
        /// and the values of all other members to zero to be notified of the arrival of a new smart card reader.
        /// </summary>
        public string m_szReader;

        /// <summary>
        /// Not used by the smart card subsystem. This member is used by the application.
        /// </summary>
        public IntPtr m_pvUserData;

        /// <summary>
        /// Current state of the reader, as seen by the application. This field can take on any of the following values, in combination, as a bitmask. 
        /// </summary>
        public UInt32 m_dwCurrentState;

        /// <summary>
        /// Current state of the reader, as known by the smart card resource manager. This field can take on any of the following values, in combination, as a bitmask. 
        /// </summary>
        public UInt32 m_dwEventState;

        /// <summary>
        /// Number of bytes in the returned ATR.
        /// </summary>
        public UInt32 m_cbAtr;

        /// <summary>
        /// ATR of the inserted card, with extra alignment bytes.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] m_rgbAtr;
    }

}
