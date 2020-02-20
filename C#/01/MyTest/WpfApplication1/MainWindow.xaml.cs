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

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        List<TestClass> lsclass = new List<TestClass>();
        List<string> lsstring = new List<string>();
        
        public MainWindow()
        {
            InitializeComponent();
            TestClass class1=new TestClass();
            class1.ID=1;
            class1.Name="aaa";
            lsclass.Add(class1);

            TestClass class2 = new TestClass();
            class2.ID = 2;
            class2.Name = "bbb";
            lsclass.Add(class2);

            TestClass class3 = new TestClass();
            class3.ID = 3;
            class3.Name = "ccc";
            lsclass.Add(class3);


            Func<TestClass, bool> expression = c => c.ID ==1;
            lsclass = lsclass.Where(expression).ToList();
        }
      
      
     }

    public class TestClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
