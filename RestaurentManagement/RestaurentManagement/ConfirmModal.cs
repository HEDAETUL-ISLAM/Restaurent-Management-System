using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurentManagement
{
    public partial class ConfirmModal : Form
    {
        public double Price;

        public ConfirmModal(double totalPrice)
        {
            InitializeComponent();
            this.Price = totalPrice;
            if(totalPrice == 0)
            {
                ConfirmButton.Visible = false;
            }
        }
        OrderModal orderModal = new OrderModal();
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfirmModal_Load(object sender, EventArgs e)
        {
            TotalPriceLabel.Text = Price.ToString();
        }

        

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (DiscountComboBox.Text.Length == 0 || VatComboBox.Text.Length == 0) {
                MessageBox.Show("Please fill properly ...");
            }
            else
            {
                double discount = Double.Parse(DiscountComboBox.Text);
                double vat = Double.Parse(VatComboBox.Text);
                double totalPrice = (Price - discount) + (((Price - discount) * vat) / 100);
                //MessageBox.Show(vat.ToString()+discount.ToString()+ Price.ToString() + totalPrice.ToString());
                Voucher voucher = new Voucher(Price, discount, vat, totalPrice);
                voucher.Show();
                this.Visible = false;
            }
            
        }
    }
}
