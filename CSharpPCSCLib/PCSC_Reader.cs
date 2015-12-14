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
using GS.SCard;
using GS.SCard.Const;

namespace GS.PCSC
{
    using System.Linq;

    public partial class PCSCReader
    {
        /// <summary>
        /// Stores the actual smartcard reader name.
        /// </summary>
        private string readerName;

        /// <summary>
        /// WinScard Functions.
        /// </summary>
        public GS.SCard.WinSCard SCard;


        /// <summary>
        /// Initializes a new instance of the <see cref="PCSCReader"/> class.
        /// </summary>
        public PCSCReader()
        {
            this.SCard = new GS.SCard.WinSCard();
            readerName = null;
        }

        /// <summary>
        /// Establishes the smart card resourete manager context and provides the list of readers.
        /// </summary>
        public void Connect()
        {
            Connect( null );
        }

        /// <summary>
        /// Establishes the smart card resourete manager context and provides the list of readers.
        /// </summary>
        /// <param name="dwScope">Scope of the resource manager context.</param>
        public void Connect(SCARD_SCOPE dwScope)
        {
            Connect(null, dwScope);
        }

        /// <summary>
        /// Establishes the smart card resourete manager context and selectes the specified reader.
        /// </summary>
        /// <param name="szReader">
        /// The name of the reader that contains the target card.
        /// </param>
        public void Connect( string szReader )
        {
            Connect( szReader, SCARD_SCOPE.System );
        }

        /// <summary>
        /// Establishes the smart card resourete manager context and selectes the specified reader.
        /// </summary>
        /// <param name="szReader">
        /// The name of the reader that contains the target card.
        /// </param>
        /// <param name="dwScope">Scope of the resource manager context.</param>
        public void Connect(string szReader, SCARD_SCOPE dwScope)
        {
            try
            {
                this.SCard.EstablishContext( dwScope );

                if (!string.IsNullOrEmpty( szReader ))
                {
                    this.readerName = szReader;
                    return;
                }

                this.SCard.ListReaders();

                this.readerName = this.SCard.ReaderNames.First(name => name.Contains("PICC"));
            }
            catch (WinSCardException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Activates the card.
        /// </summary>
        public void ActivateCard()
        {
            ActivateCard(SCARD_SHARE_MODE.Exclusive, SCARD_PROTOCOL.Tx); 
        }

        /// <summary>
        /// Activates the card.
        /// </summary>
        /// <param name="dwPrefProtocol">
        /// A bitmask of acceptable protocols for the connection. Possible values may be combined with the OR operation.
        /// </param>
        public void ActivateCard(SCARD_PROTOCOL dwPrefProtocol)
        {
            ActivateCard( SCARD_SHARE_MODE.Exclusive, dwPrefProtocol );
        }

        /// <summary>
        /// Activates the card.
        /// </summary>
        /// <param name="dwShareMode">
        /// A flag that indicates whether other applications may form connections to the card.
        /// </param>
        /// <param name="dwPrefProtocol">
        /// A bitmask of acceptable protocols for the connection. Possible values may be combined with the OR operation.
        /// </param>
        public void ActivateCard(SCARD_SHARE_MODE dwShareMode, SCARD_PROTOCOL dwPrefProtocol)
        {
            try
            {
                this.SCard.WaitForCardPresent(this.readerName);
                                
                this.SCard.Connect( this.readerName, dwShareMode, dwPrefProtocol );
            }
            catch (WinSCardException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Disconnects the an established connection to a smart card and closes 
        /// an established resource manager context, freeing any resources allocated 
        /// under that context.
        /// </summary>
        public void Disconnect()
        {
            Disconnect(SCARD_DISCONNECT.Unpower);
        }

        /// <summary>
        /// Disconnects the an established connection to a smart card and closes 
        /// an established resource manager context, freeing any resources allocated 
        /// under that context.
        /// </summary>
        /// <param name="disposition">Action to take on the card in the connected reader on close.</param>
        public void Disconnect(SCARD_DISCONNECT disposition)
        {
            try
            {
                this.SCard.Disconnect(disposition);
                this.SCard.ReleaseContext();
                this.readerName = null;
            }
            catch (WinSCardException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
