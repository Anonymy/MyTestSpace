using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace PlayerFunction
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var time1 = DateTime.Now.ToString("yyyy/MM/dd");
        }
    }
    public enum EmPlayerFunction :long
    {
        [Description("上端信息栏可见")]
        InfoPanelVisible = 1 << 0,
        [Description("下端控制栏可见")]
        ToolPanelVisible = 1 << 1,
        [Description("关闭按钮可见")]
        CloseButtonVisible = 1 << 2,
        [Description("播放/停止按钮隐藏")]
        btnStopRealPlayHidden = 1 << 3,
        [Description("截图按钮隐藏")]
        btnSnapHidden = 1 << 4,
        [Description("录像按钮隐藏")]
        btnLocalRecordHidden = 1 << 5,
        [Description("标签按钮隐藏")]
        btnBookmarkHidden = 1 << 6,
        [Description("快速回放按钮隐藏")]
        btnQuickPlaybackHidden = 1 << 7,
        [Description("数字放大按钮隐藏")]
        btnDigitalZoomHidden = 1 << 8,
        [Description("添加到收藏夹隐藏")]
        btnAddFavoriteHidden = 1 << 9,
        [Description("添加到日常巡查隐藏")]
        btnAddTumlnHidden = 1 << 10,
        [Description("全屏播放隐藏")]
        btnFullScreenHidden = 1 << 11,
        [Description("云台控制隐藏")]
        btnPTZHidden = 1 << 12,
        [Description("清晰度控制隐藏")]
        btnVideoQualityHidden = 1 << 13,
        [Description("语音对讲隐藏")]
        btnVoiceTransHidden = 1 << 14,
        [Description("画面比例切换隐藏")]
        btnDisplayScaleHidden = 1 << 15,
        [Description("[右键]云台")]
        RightMenuPTZ = 1 << 16,
        [Description("[右键]录像播放")]
        RightMenuRecord = 1 << 17,
        [Description("[右键]一键上报")]
        RightMenuReport = 1 << 18,
        [Description("[右键]地图定位")]
        RightMenuMapLocation = 1 << 19,
        [Description("[右键]全屏播放")]
        RightMenuFullScreen = 1 << 20,
        [Description("[右键]视频推送")]
        RightMenuVideoPush = 1 << 21,
        [Description("[右键]云台强制退出")]
        RightMenuPTZCoerceExit = 1 << 22,
        [Description("[右键]一键上墙")]
        RightMenuTVWall = 1 << 23,
        [Description("[右键]开始解码")]
        RightMenuStartDecode = 1 << 24,
        [Description("[右键]停止解码")]
        RightMenuStopDecode = 1 << 25,
        [Description("[右键]电视墙预览")]
        RightMenuTVWallRlay = 1 << 26,
        [Description("[右键]设置为默认屏幕")]
        RightMenuDefaultScreen = 1 << 27,
        [Description("[右键]设置为活动屏幕")]
        RightMenuActivityScreen = 1 << 28,
        [Description("[右键]录像回放，播放")]
        RightMenuRecordPlay = 1 << 29,
        [Description("[右键]录像回放，暂停")]
        RightMenuRecordStop = 1 << 30,
        [Description("[右键]截图")]
        RightMenuScreenShot = 1 << 31,
        [Description("[右键]实时追踪")]
        RightMenuTrack = 1 << 32,
        [Description("[右键]快速定位")]
        RightMenuFastLocation =(long) 1 << 33,
        [Description("录像回放上一帧隐藏")]
        btnLastFrameHidden =(long) 1 << 34,
        [Description("录像回放下一帧隐藏")]
        btnNextFrameHidden = 1 << 35,
        [Description("录像回放倒放隐藏")]
        btnBackPlayHidden = 1 << 36,
        [Description("录像回放正放隐藏")]
        btnFrontPlayHidden = 1 << 37,
        [Description("录像回放快退隐藏")]
        btSpeedDownHidden = 1 << 38,
        [Description("录像回放快进隐藏")]
        btSpeedUpHidden = 1 << 39,
        [Description("录像回放静音隐藏")]
        btnAudioCtlHidden = 1 << 40,
        [Description("录像回放下载隐藏")]
        btnDownloadHidden = 1 << 41,
    }
}
