using System;
using System.Collections.Generic;
using System.IO;
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

namespace Recrange
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var byteImage = GetImageByte(this.ScreenshotImage.Source);
        
            System.Drawing.Image image = (System.Drawing.Image)(BytesToImage(byteImage));
            var startPoint = new Point(image.Width * 0.0730994152046784, image.Height * 0.130890052356021);
            var endPoint = new Point(image.Width * 0.219298245614035, image.Height * 0.392670157068063);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
            System.Drawing.Color color = System.Drawing.Color.FromArgb(1, 1, 1);
            System.Drawing.Pen mypen = new System.Drawing.Pen(color, 4);//设置画笔的颜色及宽度
            g.DrawRectangle(mypen, (int)startPoint.X, (int)startPoint.Y, (int)(endPoint.X - startPoint.X), (int)(endPoint.Y - startPoint.Y));
            byteImage =imageToByte(image);
            BitmapImage BitImage = new BitmapImage();
            BitImage.BeginInit();
            BitImage.StreamSource = new MemoryStream(byteImage);
            BitImage.EndInit();
            ScreenshotImage.Source = BitImage;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
         
               // Rectangle rectange = new Rectangle();
               // Color color=new Color();
               //  color.R=1;
               // color.G=1;
               // color.B=1;
               //rectange.Stroke = new SolidColorBrush(color);
               //rectange.StrokeThickness = 20;
               // Canvas.SetLeft(rectange, 20);
               // Canvas.SetTop(rectange, 20);

               // rectange.Width = 200;
               // rectange.Height = 200;
               // Button btn = new Button();
               // btn.Width = 75;
               // btn.Height = 45;
               // this.videocanvas.Children.Add(btn);
                Rectangle rectangle = new Rectangle();
                rectangle.Stroke = Brushes.Red;
                rectangle.StrokeThickness = 2;
                rectangle.Height = 100;
                rectangle.Width = 100;
                Canvas.SetLeft(rectangle, 50);
                Canvas.SetTop(rectangle, 50);
                this.videocanvas.Children.Add(rectangle);
                Console.WriteLine(" this.videocanvas 起点：（" + (50 / this.videocanvas.ActualWidth) + "、" + (50 / this.videocanvas.ActualHeight)+"）");
                Console.WriteLine(" this.videocanvas 终点：（" + (150 / this.videocanvas.ActualWidth) + "、" + (150 / this.videocanvas.ActualHeight) + "）");
                //_paraShapes.MaxTarget = _shap.Recrange.Rectange;
        }

        public  byte[] GetImageByte(ImageSource iSource)
        {
            byte[] bt = null;
            try
            {
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create((BitmapSource)iSource));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    bt = ms.ToArray();
                }
            }
            catch (System.Exception ex)
            {
            }
            return bt;
        }
        public System.Drawing.Image BytesToImage(byte[] buffer)
        {
            try
            {
                if (buffer == null) return null;
                MemoryStream ms = new MemoryStream(buffer);
                System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                return image;
            }
            catch (System.Exception ex)
            {
              
            }
            return null;
        }
        public  byte[] imageToByte(System.Drawing.Image image)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            var byteImage = GetImageByte(this.ScreenshotImage.Source);

            System.Drawing.Image image = (System.Drawing.Image)(BytesToImage(byteImage));
            var startPoint = new Point(image.Width * 0.0730994152046784, image.Height * 0.130890052356021);
            var endPoint = new Point(image.Width * 0.219298245614035, image.Height * 0.392670157068063);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
            System.Drawing.Color color = System.Drawing.Color.Red;
            System.Drawing.Pen mypen = new System.Drawing.Pen(color, 8);//设置画笔的颜色及宽度
            mypen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;//恢复实线
          
            mypen.EndCap = System.Drawing.Drawing2D.LineCap.Custom;//定义线尾的样式为箭头
            System.Drawing.Drawing2D.AdjustableArrowCap lineCap = new System.Drawing.Drawing2D.AdjustableArrowCap(6, 6, true);
            mypen.CustomEndCap = lineCap;
            g.DrawLine(mypen, 10, 30, 400, 800);
            byteImage = imageToByte(image);
            BitmapImage BitImage = new BitmapImage();
            BitImage.BeginInit();
            BitImage.StreamSource = new MemoryStream(byteImage);
            BitImage.EndInit();
            ScreenshotImage.Source = BitImage;
        }
    }
}
