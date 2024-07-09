using Microsoft.Win32;
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

namespace TyapRgrWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty AlphabetProperty;
        public static readonly DependencyProperty StartSymbolProperty;
        public static readonly DependencyProperty EndSymbolProperty;
        public static readonly DependencyProperty MProperty;
        public static readonly DependencyProperty StartStateProperty;
        public static readonly DependencyProperty EndStateProperty;


        public string Alphabet
        {
            get { return (string)GetValue(AlphabetProperty); }
            set { SetValue(AlphabetProperty, value); }
        }
        public string StartSymbol
        {
            get { return (string)GetValue(StartSymbolProperty); }
            set { SetValue(StartSymbolProperty, value); }
        }
        public string EndSymbol
        {
            get { return (string)GetValue(EndSymbolProperty); }
            set { SetValue(EndSymbolProperty, value); }
        }
        public string M
        {
            get { return (string)GetValue(MProperty); }
            set { SetValue(MProperty, value); }
        }
        public string StartState
        {
            get { return (string)GetValue(StartStateProperty); }
            set { SetValue(StartStateProperty, value); }
        }

        public string EndState
        {
            get { return (string)GetValue(EndStateProperty); }
            set { SetValue(EndStateProperty, value); }
        }

        static MainWindow()
        {
            AlphabetProperty = DependencyProperty.Register(
           "Alphabet",
           typeof(string),
            typeof(MainWindow));

            StartSymbolProperty = DependencyProperty.Register(
           "StartSymbol",
           typeof(string),
           typeof(MainWindow));
            EndSymbolProperty = DependencyProperty.Register(
          "EndSymbol",
          typeof(string),
          typeof(MainWindow));
            MProperty = DependencyProperty.Register(
           "M",
           typeof(string),
           typeof(MainWindow));

            StartStateProperty = DependencyProperty.Register(
           "StartState",
           typeof(string),
           typeof(MainWindow));

            EndStateProperty = DependencyProperty.Register(
          "EndState",
          typeof(string),
          typeof(MainWindow));


        }
        public MainWindow()
        {
            InitializeComponent();
            clear();
            def();
            DataContext = this;
        }

        bool gr=true;
        private void ButtonBuild(object sender, RoutedEventArgs a)
        {
           
            List<string> list;
            var vm = new ViewModel();
            try
            {
               vm.GetRul(Alphabet, M, StartSymbol, EndSymbol, StartState, EndState,gr);
            }

            catch (AlfException)
            {
                MessageBox.Show("Каждый знак алфавита является маленькой буквой или цифрой");
                return;
            }
            catch (AlfSizeException)
            {
                MessageBox.Show("Алфавит включает до 20 символов");
                return;
            }
            catch (StartSymbolNotBelongException)
            {
                MessageBox.Show("Символы в начальной цепочке не принадлежат алфавиту");
                return;
            }
            catch (EndSymbolNotBelongException)
            {
                MessageBox.Show("Символы в конечной цепочке не принадлежат алфавиту");
                return;
            }
            catch (StartSymbolSizeException)
            {
                MessageBox.Show("Размер начальной цепочки не больше 10");
                return;
            }
            catch (EndSymbolSizeException)
            {
                MessageBox.Show("Размер конечной цепочки не больше 10");
                return;
            }
            catch (MultiplicitySizeException)
            {
                MessageBox.Show("Кратность не меньше 1 и не больше 10");
                return;
            }
            catch (RangeException)
            {
                MessageBox.Show("Диапазон размера цепочек указан неверно. Максимальное значение 10.");
                return;
            }
            catch (Exception e) { MessageBox.Show(e.Message); return; }

            var rw = new RulWindow();
            rw.Owner = this;
            rw.list.ItemsSource = vm.list;
            rw.Show();
            var cw = new RulWindow();
            cw.Owner = this;
            cw.list.ItemsSource = vm.listC;
            cw.Show();
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            var s = pressed.Content.ToString();
            if (s == "ПЛ")
                gr = true;
            else
                gr = false;
        }
        void clear()
        {

            Alphabet = "";
            StartSymbol = "";

            EndSymbol = "";
            M = "";
            StartState = "";
            EndState = "";
            rb1.IsChecked = true;
        }
        void def()
        {

            Alphabet = "a,b";
            StartSymbol = "aa";

            EndSymbol = "bb";
            M = "2";
            StartState = "1";
            EndState = "2";
        }
        private void ButtonClear(object sender, RoutedEventArgs a)
        {
            clear();
    }
        private void ButtonSave(object sender, RoutedEventArgs a)
        {
            string FilePath = "";
            try
            {


                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = ".json"; // Default file extension
                saveFileDialog.Filter = "Json files (*.json)|*.json"; // Filter files by extension
                if (saveFileDialog.ShowDialog() == true)
                {
                    FilePath = saveFileDialog.FileName;

                }
            }
            catch {
                MessageBox.Show("Не удалось открыть файл!");
                return;
            }
            if(String.IsNullOrEmpty(FilePath))
            {
                MessageBox.Show("Не удалось открыть файл!");
                return;
            }
            try
            {
                ViewModel.jsonToFile(FilePath, Alphabet, M, StartSymbol, EndSymbol, StartState, EndState, gr);
            }
            catch
            {
                MessageBox.Show("Не удалось открыть файл!");
                return;
            }

        }
        private void ButtonLoad(object sender, RoutedEventArgs a)
        {
            string FilePath = "";
            try
            {
                var dialog = new Microsoft.Win32.OpenFileDialog();

                dialog.DefaultExt = ".json"; // Default file extension
                dialog.Filter = "Json files (*.json)|*.json"; // Filter files by extension

                // Show open file dialog box
                bool? result = dialog.ShowDialog();

                // Process open file dialog box results
                if (result == true)
                {
                    // Open document
                    FilePath = dialog.FileName;
                }
            }
            catch
            {
                MessageBox.Show("Не удалось открыть файл!");
                return;
            }
            if (String.IsNullOrEmpty(FilePath))
            {
                MessageBox.Show("Не удалось открыть файл!");
                return;
            }

            Data d=null;
            try
            {
                d = ViewModel.jsonOfFile(FilePath);
            }
            catch
            {
                MessageBox.Show("Не удалось открыть файл!");
                return;
            }
            if(d == null)
            {
                MessageBox.Show("Загрузка не выполнена!");
                return;
            }

            Alphabet = d.Alphabet;
            StartSymbol = d.StartSymbol;

            EndSymbol = d.EndSymbol;
            M = d.M;
            StartState = d.StartState;
            EndState = d.EndState;
            if(d.right)
                rb1.IsChecked = true;
            else
                rb2.IsChecked = true;
        }
        private void ButtonFile(object sender, RoutedEventArgs a)
        {

            List<string> list;
            var vm = new ViewModel();
            try
            {
                vm.GetRul(Alphabet, M, StartSymbol, EndSymbol, StartState, EndState, gr);
            }

            catch (AlfException)
            {
                MessageBox.Show("Каждый знак алфавита является маленькой буквой или цифрой");
                return;
            }
            catch (AlfSizeException)
            {
                MessageBox.Show("Алфавит включает до 20 символов");
                return;
            }
            catch (StartSymbolNotBelongException)
            {
                MessageBox.Show("Символы в начальной цепочке не принадлежат алфавиту");
                return;
            }
            catch (EndSymbolNotBelongException)
            {
                MessageBox.Show("Символы в конечной цепочке не принадлежат алфавиту");
                return;
            }
            catch (StartSymbolSizeException)
            {
                MessageBox.Show("Размер начальной цепочки не больше 10");
                return;
            }
            catch (EndSymbolSizeException)
            {
                MessageBox.Show("Размер конечной цепочки не больше 10");
                return;
            }
            catch (MultiplicitySizeException)
            {
                MessageBox.Show("Кратность не меньше 1 и не больше 10");
                return;
            }
            catch (RangeException)
            {
                MessageBox.Show("Диапазон размера цепочек указан неверно. Максимальное значение 10.");
                return;
            }
            catch (Exception e) { MessageBox.Show(e.Message); return; }


            string FilePath = "";
            try
            {


                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = ".txt"; // Default file extension
                saveFileDialog.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension
                if (saveFileDialog.ShowDialog() == true)
                {
                    FilePath = saveFileDialog.FileName;

                }
            }
            catch
            {
                MessageBox.Show("Не удалось открыть файл!");
                return;
            }
            if (String.IsNullOrEmpty(FilePath))
            {
                MessageBox.Show("Не удалось открыть файл!");
                return;
            }
            try
            {
                vm.resToFile(FilePath, Alphabet, M, StartSymbol, EndSymbol);
            }
            catch
            {
                MessageBox.Show("Не удалось открыть файл!");
                return;
            }


        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Даськова Любовь Ип-013");
        }
        private void MenuItem_Click2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Написать программу, которая по предложенному описанию языка построит регулярную грамматику (ЛЛ или ПЛ – по заказу пользователя),\r\nзадающую этот язык, и позволит сгенерировать с её помощью все цепочки языка в заданном диапазоне длин. Предусмотреть возможность\r\nпоэтапного отображения на экране процесса генерации цепочек. Варианты задания языка:\r\n(4) Алфавит, начальная и конечная подцепочки и кратность длины\r\nвсех цепочек языка.\r\n");
        }
    }
}