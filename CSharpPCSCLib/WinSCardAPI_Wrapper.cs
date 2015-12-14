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
    /// The winscard.dll (PC/SC = Personal Computer / Smart Card) PInvoke wrapper class.
    /// Please see also the Platform SDK documentation for descriptions of  native functions.
    /// Note: Not all of the WinSCard Win32 interface has been implemented here yet.
    /// </summary>
    partial class WinSCardAPIWrapper
    {
        #region Native WinScard API Wrapper

        /// <summary>
        /// The SCardEstablishContext function establishes the resource manager context (the scope) 
        /// within which database operations are performed.
        /// </summary>
        /// <param name="dwScope">Scope of the resource manager context..</param>
        /// <param name="pvReserved1">Reserved for future use and must be IntPtr.Zero.</param>
        /// <param name="pvReserved2">Reserved for future use and must be IntPtr.Zero.</param>
        /// <param name="phContext">A handle to the established resource manager context.</param>
        /// <returns></returns>
        [DllImport("winscard.dll")]
        public static extern int SCardEstablishContext(  uint dwScope, 
                                                         IntPtr pvReserved1, 
                                                         IntPtr pvReserved2,
                                                         out IntPtr phContext );

        /// <summary>
        /// The SCardReleaseContext function closes an established resource manager context, 
        /// freeing any resources allocated under that context, including SCARDHANDLE objects 
        /// and memory allocated using the SCARD_AUTOALLOCATE length designator.
        /// </summary>
        /// <param name="hContext">Handle that identifies the resource manager context. 
        /// The resource manager context is set by a previous call to SCardEstablishContext.</param>
        /// <returns>
        /// If the function succeeds, the function returns SCARD_S_SUCCESS. 
        /// If the function fails, it returns an error code. 
        /// </returns>
        [DllImport("WinScard.dll")]
        public static extern int SCardReleaseContext( IntPtr hContext );


        /// <summary>
        /// The SCardConnect function establishes a connection (using a specific resource manager context) 
        /// between the calling application and a smart card contained by a specific reader. 
        /// If no card exists in the specified reader, an error is returned.
        /// </summary>
        /// <param name="hContext">
        /// A handle that identifies the resource manager context.</param>
        /// <param name="cReaderName">The name of the reader that contains the target card.</param>
        /// <param name="dwShareMode">A flag that indicates whether other applications may form connections to the card.</param>
        /// <param name="dwPrefProtocol">
        /// A bitmask of acceptable protocols for the connection. Possible values may be combined with the OR operation.</param>
        /// <param name="phCard">A handle that identifies the connection to the smart card in the designated reader.</param>
        /// <param name="pdwActiveProtocol">
        /// A flag that indicates the established active protocol.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns SCARD_S_SUCCESS. 
        /// If the function fails, it returns an error code. 
        /// </returns>
        [DllImport("WinScard.dll")]
        public static extern int SCardConnect( IntPtr hContext,
                                               string cReaderName,
                                               uint dwShareMode,
                                               uint dwPrefProtocol,
                                               out IntPtr phCard,
                                               out uint pdwActiveProtocol );

        /// <summary>
        /// The SCardDisconnect function terminates a connection previously opened between the calling 
        /// application and a smart card in the target reader.
        /// </summary>
        /// <param name="hCard">Reference value obtained from a previous call to SCardConnect.</param>
        /// <param name="dwDisposition">Action to take on the card in the connected reader on close.</param>
        /// <returns>
        /// If the function succeeds, the function returns SCARD_S_SUCCESS. 
        /// If the function fails, it returns an error code. 
        /// </returns>
        [DllImport("WinScard.dll")]
        public static extern int SCardDisconnect( IntPtr hCard, uint dwDisposition );


        /// <summary>
        /// The SCardReconnect function reestablishes an existing connection between the calling application and 
        /// a smart card. This function moves a card handle from direct access to general access, or acknowledges 
        /// and clears an error condition that is preventing further access to the card.
        /// </summary>
        /// <param name="hCard">
        /// Reference value obtained from a previous call to SCardConnect.</param>
        /// <param name="dwShareMode">
        /// A flag that indicates whether other applications may form connections to the card.
        /// </param>
        /// <param name="dwPrefProtocol">
        /// A bitmask of acceptable protocols for the connection. Possible values may be combined with the OR operation.
        /// </param>
        /// <param name="dwInitialization">
        /// Type of initialization that should be performed on the card.
        /// </param>
        /// <param name="pdwActiveProtocol">
        /// Flag that indicates the established active protocol.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns SCARD_S_SUCCESS. 
        /// If the function fails, it returns an error code. 
        /// </returns>
        [DllImport("WinScard.dll")]
        public static extern int SCardReconnect( IntPtr hCard,
                                                 uint dwShareMode,
                                                 uint dwPrefProtocol,
                                                 uint dwInitialization,
                                                 out uint pdwActiveProtocol );

        /// <summary>
        /// The SCardListReaders function provides the list of readers within a set of named reader groups, eliminating duplicates.
        /// </summary>
        /// <param name="hContext">
        /// Handle that identifies the resource manager context for the query.
        /// The resource manager context can be set by a previous call to SCardEstablishContext.
        /// This parameter cannot be NULL.</param>
        /// <param name="mszGroups">
        /// Names of the reader groups defined to the system, as a multi-string.
        /// Use a NULL value to list all readers in the system (that is, the SCard$AllReaders group).
        /// </param>
        /// <param name="mszReaders">Multi-string that lists the card readers within the supplied reader groups.</param>
        /// <param name="pcchReaders">Length of the mszReaders buffer in characters. </param>
        /// <returns>
        /// If the function succeeds, the function returns SCARD_S_SUCCESS. 
        /// If the function fails, it returns an error code. 
        /// </returns>
        [DllImport( "WinScard.dll" )]
        public static extern int SCardListReaders( IntPtr hContext,
                                                   string mszGroups,
                                                   [MarshalAs( UnmanagedType.LPArray,
                                                   ArraySubType = UnmanagedType.LPWStr )] 
                                                   byte[] mszReaders,
                                                   ref int pcchReaders );

        
        /// <summary>
        /// The SCardGetStatusChange function blocks execution until the current 
        /// availability of the cards in a specific set of readers changes.
        /// </summary>
        /// <param name="hContext">
        /// Handle that identifies the resource manager context for the query.
        /// The resource manager context can be set by a previous call to SCardEstablishContext.
        /// This parameter cannot be NULL.</param>
        /// <param name="dwTimeout">
        /// The maximum amount of time, in milliseconds, to wait for an action. 
        /// A value of zero causes the function to return immediately. 
        /// A value of INFINITE causes this function never to time out.
        /// </param>
        /// <param name="rgReaderStates">
        /// An array of SCARD_READERSTATE structures that specify the readers to watch, 
        /// and that receives the result. To be notified of the arrival of a new smart card reader, 
        /// set the szReader member of a SCARD_READERSTATE structure to "\\\\?PnP?\\Notification", 
        /// and set all of the other members of that structure to zero. Important  Each member of 
        /// each structure in this array must be initialized to zero and then set to specific values 
        /// as necessary. If this is not done, the function will fail in situations that involve 
        /// remote card readers.
        /// </param>
        /// <param name="cReaders">
        /// The number of elements in the rgReaderStates array.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns SCARD_S_SUCCESS. 
        /// If the function fails, it returns an error code. 
        /// </returns>
        [DllImport( "WinScard.DLL" )]
        public static extern int SCardGetStatusChange( IntPtr hContext,
                                                       uint dwTimeout,
                                                       [In, Out] SCARD_READERSTATE[] rgReaderStates,
                                                       uint cReaders );


        /// <summary>
        /// The SCardTransmit function sends a service request to the smart card and expects to receive data back from the card.
        /// </summary>
        /// <param name="hCard">A reference value returned from the SCardConnect function.</param>
        /// <param name="pioSendPci">
        /// A pointer to the protocol header structure for the instruction.
        /// This buffer is in the format of an SCARD_IO_REQUEST structure,
        /// followed by the specific protocol control information (PCI).
        /// </param>
        /// <param name="pbSendBuffer">A pointer to the actual data to be written to the card. </param>
        /// <param name="cbSendLength">The length, in bytes, of the pbSendBuffer parameter.</param>
        /// <param name="pioRecvPci">
        /// Pointer to the protocol header structure for the instruction, followed by a buffer
        /// in which to receive any returned protocol control information (PCI) specific to the
        /// protocol in use. This parameter can be NULL if no PCI is returned.
        /// </param>
        /// <param name="pbRecvBuffer">Pointer to any data returned from the card.</param>
        /// <param name="pcbRecvLength">
        /// Supplies the length, in bytes, of the pbRecvBuffer parameter and receives the actual
        /// number of bytes received from the smart card.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns SCARD_S_SUCCESS. 
        /// If the function fails, it returns an error code. 
        /// </returns>
        [DllImport( "WinScard.dll" )]
        public static extern int SCardTransmit( IntPtr hCard,
                                                ref SCARD_IO_REQUEST pioSendPci,
                                                byte[] pbSendBuffer,
                                                int cbSendLength,
                                                IntPtr pioRecvPci,
                                                byte[] pbRecvBuffer,
                                                ref int pcbRecvLength );






        /// <summary>
        /// The SCardControl function gives you direct control of the reader. 
        /// You can call it any time after a successful call to SCardConnect and 
        /// before a successful call to SCardDisconnect. The effect on the state 
        /// of the reader depends on the control code.
        /// </summary>
        /// <param name="hCard">Reference value returned from SCardConnect.</param>
        /// <param name="dwControlCode"></param>
        /// <param name="lpInBuffer"></param>
        /// <param name="nInBufferSize"></param>
        /// <param name="lpOutBuffer"></param>
        /// <param name="nOutBufferSize"></param>
        /// <param name="lpBytesReturned"></param>
        /// <returns>
        /// If the function succeeds, the function returns SCARD_S_SUCCESS. 
        /// If the function fails, it returns an error code. 
        /// </returns>
        [DllImport( "WinScard.dll" )]
        public static extern int SCardControl( IntPtr hCard,
                                               uint dwControlCode,
                                               byte[] lpInBuffer,
                                               int nInBufferSize,
                                               byte[] lpOutBuffer,
                                               int nOutBufferSize,
                                               ref int lpBytesReturned );




        /// <summary>
        /// The SCardFreeMemory function releases memory that has been returned 
        /// from the resource manager using the SCARD_AUTOALLOCATE length designator.
        /// </summary>
        /// <param name="hContext">
        /// Handle that identifies the resource manager context for the query.
        /// </param>
        /// <param name="pvMem">
        /// Memory block to be released.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns SCARD_S_SUCCESS. 
        /// If the function fails, it returns an error code. 
        /// </returns>
        [DllImport("WinScard.dll")]
        public static extern int SCardFreeMemory( IntPtr hContext, IntPtr pvMem );


        /// <summary>
        /// The SCardGetAttrib function gets the current reader attributes.
        /// It does not affect the state of the reader, driver, or card.
        /// </summary>
        /// <param name="hContext">
        /// Handle that identifies the resource manager context for the query.
        /// </param>
        /// <param name="dwAttrId">
        /// Identifier for the attribute to get.
        /// </param>
        /// <param name="resultBuffer">
        /// The result buffer.
        /// </param>
        /// <param name="resultLength">
        /// Length of the result.
        /// </param>
        /// <returns></returns>
        [DllImport("winscard.dll", SetLastError = true)]
        public static extern int SCardGetAttrib( IntPtr hContext,
                                                 uint dwAttrId,
                                                 [Out] byte[] resultBuffer,
                                                 ref int resultLength);



        #endregion

    }
}