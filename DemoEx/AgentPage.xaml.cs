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
    /// Логика взаимодействия для AgentPage.xaml
    /// </summary>
    public partial class AgentPage : Page
    {
       
        public AgentPage()
        {
            InitializeComponent();
            var _currentAgent = ExdemoEntities.GetContext().Agent.ToList();
            LViewAgent.ItemsSource = _currentAgent;

            var allTypes = ExdemoEntities.GetContext().AgentType.ToList();
            allTypes.Insert(0, new AgentType
            {
                Title = "Все типы"
            });

            CbType.ItemsSource = allTypes;
            CbType.SelectedIndex = 0;

        }


        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ExdemoEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                LViewAgent.ItemsSource = ExdemoEntities.GetContext().Agent.ToList();
            }
        }

       
        private void CbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxbPageNumber_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void GoNextPageButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GoPrevButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LViewAgent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddPage(null));
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var agentsForRemoving = LViewAgent.SelectedItems.Cast<Agent>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {agentsForRemoving.Count()} элементов?","Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ExdemoEntities.GetContext().Agent.RemoveRange(agentsForRemoving);
                    ExdemoEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    LViewAgent.ItemsSource = ExdemoEntities.GetContext().Agent.ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
