using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoEx
{
    /// <summary>
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        private Agent _currentAgent = new Agent();
        public AddPage( Agent selectedAgent)
        {
            InitializeComponent();
            DataContext = _currentAgent;
            CbType.ItemsSource = ExdemoEntities.GetContext().AgentType.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentAgent.Title))
                errors.AppendLine("Укажите название компании!");
            if (string.IsNullOrWhiteSpace(_currentAgent.Address))
                errors.AppendLine("Укажите адрес!");
            if (string.IsNullOrWhiteSpace(_currentAgent.INN))
                errors.AppendLine("Укажите название ИНН!");
            if (string.IsNullOrWhiteSpace(_currentAgent.KPP))
                errors.AppendLine("Укажите название КПП!");
            if (string.IsNullOrWhiteSpace(_currentAgent.DirectorName))
                errors.AppendLine("Укажите ФИО директора!");
            if (string.IsNullOrWhiteSpace(_currentAgent.Phone))
                errors.AppendLine("Укажите номер телефона!");
            if (string.IsNullOrWhiteSpace(_currentAgent.Email))
                errors.AppendLine("Укажите email!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentAgent.ID== 0)
                ExdemoEntities.GetContext().Agent.Add(_currentAgent);
            try
            {
                ExdemoEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
