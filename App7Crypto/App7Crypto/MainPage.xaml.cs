using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Crypto;

namespace App7Crypto
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void button_Clicked(object sender, EventArgs e)
        {
            var strEncrypt = this.entry.Text.ToStringEncrypt();
            var strbEncrypt = this.entry.Text.ToByteEncrypt();
      
            this.entryBinaryEncrypt.Text = Convert.ToBase64String(strbEncrypt);
            this.entryStringEncrypt.Text = strEncrypt;

            var strDecrypt = strEncrypt.ToStringEncrypt();
            var strbDecrypt = strbEncrypt.ToByteEncrypt();

            this.entryStringDecrypt.Text= Convert.ToString(strDecrypt);
            this.entryBinaryDecrypt.Text = strbDecrypt;

        }
    }
}
