using PolybiusSquareLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using СryptographyLibrary;

namespace WindowsFormsApp
{
    public enum EncodingType
    {
        Тайнопись,
        КвадратПолибия
    }

    public partial class MainForm : Form
    {
        Cryptography cryptography = new Cryptography();
        PolybiusSquare polybiusSquare = new PolybiusSquare();

        public MainForm()
        {
            InitializeComponent();

            listBox.Items.Add(EncodingType.Тайнопись);
            listBox.Items.Add(EncodingType.КвадратПолибия);

            listBox.SelectedItem = listBox.Items[0];
        }

        private void encodingButton_Click(object sender, EventArgs e)
        {
            try
            {
                var encodingType = listBox.SelectedItem;

                string message;
                if (EncryptionMessageTB.Text == "")
                {
                    message = DecryptionMessageTB.Text;

                    switch (encodingType)
                    {
                        case EncodingType.Тайнопись:
                            message = cryptography.Decryption(message);
                            break;
                        case EncodingType.КвадратПолибия:
                            message = polybiusSquare.Decryption(message);
                            break;
                    }
                }
                else
                {
                    message = EncryptionMessageTB.Text;

                    switch (encodingType)
                    {
                        case EncodingType.Тайнопись:
                            message = cryptography.Encryption(message);
                            break;
                        case EncodingType.КвадратПолибия:
                            message = polybiusSquare.Encryption(message);
                            break;
                    }
                }

                ResultTB.Text = message;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void DecryptionMessageTB_MouseDown(object sender, MouseEventArgs e)
        {
            EncryptionMessageTB.Text = "";
        }

        private void EncryptionMessageTB_MouseDown(object sender, MouseEventArgs e)
        {
            DecryptionMessageTB.Text = "";
        }
    }
}
