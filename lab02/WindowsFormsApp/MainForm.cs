using GammingLibrary;
using System;
using System.Windows.Forms;
using PolynomMethodLibrary;
using CardanoGridLibrary;
using System.Linq;

namespace WindowsFormsApp
{
    public enum EncodingType
    {
        Гаммирование,
        Метод_полиномов,
        Решетка_Кардано
    }

    public partial class MainForm : Form
    {
        Gamming gamming;
        PolynomMethod polynomMethod;
        CardanoGrid cardanoGrid;

        public MainForm()
        {
            InitializeComponent();

            listBox.Items.Add(EncodingType.Гаммирование);
            listBox.Items.Add(EncodingType.Метод_полиномов);
            listBox.Items.Add(EncodingType.Решетка_Кардано);

            listBox.SelectedItem = listBox.Items[0];

            keyTB.Text = "А";

            gamming = new Gamming(keyTB.Text);
            polynomMethod = new PolynomMethod();
            cardanoGrid = new CardanoGrid();
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
                        case EncodingType.Гаммирование:
                            gamming.Key = keyTB.Text;
                            message = gamming.Decryption(message);
                            break;
                        case EncodingType.Метод_полиномов:
                            int[] numbers = keyTB.Text.Split(' ').Select(s => int.Parse(s)).ToArray();

                            polynomMethod.N = numbers[0];
                            polynomMethod.P = numbers[1];

                            message = polynomMethod.Decryption(message);
                            break;
                        case EncodingType.Решетка_Кардано:
                            message = cardanoGrid.Decryption(message);
                            break;
                    }
                }
                else
                {
                    message = EncryptionMessageTB.Text;

                    switch (encodingType)
                    {
                        case EncodingType.Гаммирование:
                            gamming.Key = keyTB.Text;
                            message = gamming.Encryption(message);
                            break;
                        case EncodingType.Метод_полиномов:
                            int[] numbers = keyTB.Text.Split(' ').Select(s => int.Parse(s)).ToArray();

                            polynomMethod.N = numbers[0];
                            polynomMethod.P = numbers[1];

                            message = polynomMethod.Encryption(message);
                            break;
                        case EncodingType.Решетка_Кардано:
                            message = cardanoGrid.Encryption(message);
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
