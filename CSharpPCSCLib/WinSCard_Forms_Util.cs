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
using System.Windows.Forms;

namespace GS.SCard
{
    public partial class WinSCard
    {
        /// <summary>
        /// Adds the list of readers to a ComboBox.
        /// </summary>
        /// <param name="comboBox">The combo box.</param>
        public void AddReaders(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Enabled = false;

            WinSCard pcscReader = new WinSCard();
            pcscReader.EstablishContext();
            pcscReader.ListReaders();
            if (pcscReader.ReaderNames != null)
            {
                comboBox.Items.AddRange( pcscReader.ReaderNames );
                comboBox.SelectedIndex = 0;

                if (pcscReader.ReaderNames.Length > 1)
                {
                    comboBox.Enabled = true;
                }
            }
            else
            {
                comboBox.Items.Add( "No PC/SC Reader found!" );
            }
            pcscReader.ReleaseContext();
        } 
    }
}
