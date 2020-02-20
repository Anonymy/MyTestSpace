using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.IO;
using System.Drawing;

namespace ItemsControlDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        private ObservableCollection<ImageModel> m_AddCollaction;
        public MainWindow()
        {
            InitializeComponent();
            m_AddCollaction = new ObservableCollection<ImageModel>();
            this.lsPic.ItemsSource = m_AddCollaction;
        }

        /// <summary>
        /// 导入图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "图像文件(*.jpg;*.jpeg;*jpe;*jfif;*.bmp;*.dib;*.gif;*.png;*.ico;*.jp2;*.j2k;*.img;*.cur;*.wmf;*.esf)|*.jpg;*.jpeg;*jpe;*jfif;*.bmp;*.dib;*.gif;*.png;*.ico;*.jp2;*.j2k;*.img;*.cur;*.wmf;*.esf";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    ImageModel model = new ImageModel();
                    model.ImageName = open.SafeFileName;
                    model.IsChecked = false;
                    model.ImageSource = ImagePathToSource(open.FileName);
                    m_AddCollaction.Add(model);
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("点击。");
        }

        private void btnCheckStatus_Click(object sender, RoutedEventArgs e)
        {

        }
        public  ImageSource ImagePathToSource(string strPath)
        {
            try
            {
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(strPath);
                MemoryStream stream = new MemoryStream();
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                ImageSourceConverter iDetConverter = new ImageSourceConverter();
                return (ImageSource)iDetConverter.ConvertFrom(stream);
            }
            catch (System.Exception ex)
            {
            }
            return null;
        }
    }

    public class ImageModel
    {
        private string _ImageName;
        public string ImageName
        {
            get
            {
                return _ImageName;
            }
            set
            {
                _ImageName = value;
            }
        }

        private ImageSource _ImageSource;
        public ImageSource ImageSource
        {
            get { return _ImageSource; }
            set
            {
                _ImageSource = value;
            }
        }

        private bool _IsChecked;
        public bool IsChecked
        {
            get { return _IsChecked; }
            set
            {
                _IsChecked = value;
            }
        }
        
    }
}
