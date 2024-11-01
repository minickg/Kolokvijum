using BusinessLayer;
using DataLayer.Models;
using System;
using System.Windows.Forms;

namespace Kolokvijum
{
    public partial class ShopApp : Form
    {
        private readonly ProductBusiness productBusiness = new ProductBusiness();

        public ShopApp()
        {
            InitializeComponent();
        }

        private void ShopApp_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            listBoxProducts.Items.Clear();
            foreach (Product product in productBusiness.GetProducts())
            {
                string itemData = string.Format("{0}. {1}", product.Id, product.Name);
                listBoxProducts.Items.Add((itemData));

                listBoxProducts.Items.Add("${product.id}, { product.Name}"); // jednostavnije
            }
        }

        private void buttonInsertProduct_Click(object sender, EventArgs e)
        {
            Product product = new Product()
            {
                Name = textBoxName.Text,
                Description = textBoxDescription.Text,
                ExpireyDate = dateTimePickerProduct.Value
            };
            productBusiness.InsertProduct(product);

            RefreshList();

            textBoxName.Text = string.Empty;
            textBoxDescription.Text = string.Empty;
            dateTimePickerProduct.Value = DateTime.Now;
        }
    }
}