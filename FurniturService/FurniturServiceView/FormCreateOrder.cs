using FurnitureServiceBusinessLogic.BindingModels;
using FurnitureServiceBusinessLogic.BusinessLogics;
using FurnitureServiceBusinessLogic.ViewModels;
using System;
using System.Windows.Forms;
using Unity;

namespace FurniturServiceView
{
    public partial class FormCreateOrder : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly FurnitureLogic _logicF;
        private readonly OrderLogic _logicO;
        public FormCreateOrder(FurnitureLogic logiFP, OrderLogic logicO)
        {
            InitializeComponent();
            _logicF = logiFP;
            _logicO = logicO;
        }
        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {

                // продумать логику
                var list = _logicF.Read(null);
                if (list != null)
                {
                    comboBoxFurniture.DisplayMember = "FurnitureName";
                    comboBoxFurniture.ValueMember = "Id";
                    comboBoxFurniture.DataSource = list;
                    comboBoxFurniture.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка create order load ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void CalcSum()
        {
            if (comboBoxFurniture.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxFurniture.SelectedValue);
                    FurnitureViewModel furniture = _logicF.Read(new FurnitureBindingModel { Id = id })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * furniture?.Price ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void TextBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void ComboBoxFurniture_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxFurniture.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logicO.CreateOrder(new CreateOrderBindingModel
                {
                    FurnituretId = Convert.ToInt32(comboBoxFurniture.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
