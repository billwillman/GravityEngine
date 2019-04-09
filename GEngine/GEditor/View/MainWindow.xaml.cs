﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Interop;
using Microsoft.Win32;
using GWinformLib;
using GEditor.View;

namespace GEditor
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private GWinformLib.Viewport viewport = new GWinformLib.Viewport();

        private Outliner outliner = new Outliner();

        private FileBrowser fileBrowser = new FileBrowser();

        Properties_SceneObject properties;

        public object WinInterop { get; private set; }

        public MainWindow()
        {
            //this.SourceInitialized += new EventHandler(win_SourceInitialized);
            InitializeComponent();
            //viewport.TopLevel = false;
            viewport.BorderStyle = BorderStyle.None;
            viewportHost.Child = viewport;
            FileBrowserPanel.Children.Add(fileBrowser);
            fileBrowser.SetMainWindow(this);
            OutlinerPanel.Children.Add(outliner);
            outliner.SetMainWindow(this);
        }
        
        /*
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            this.win_SourceInitialized(this, e);
        }

        void win_SourceInitialized(object sender, EventArgs e)
        {
            HwndSource hwndSource = PresentationSource.FromVisual(this) as HwndSource;
            if (hwndSource != null)
                hwndSource.AddHook(new HwndSourceHook(WndProc));
        }
        */
        
        protected virtual IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            /*
            switch (msg)
            {
                case Microsoft.Win32.WM_SIZEING:
                    break;
            }
            */
            //IGCore.MsgProc(hwnd, msg, wParam, lParam);

            return IntPtr.Zero;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IntPtr hwnd = viewport.Handle;
            double h = viewport.Height;
            double w = viewport.Width;
            IGRenderer.InitD3D(hwnd, w, h);

            //HwndSource hwndSource = HwndSource.FromHwnd(hwnd);
            //HwndSource hwndSource = PresentationSource.FromVisual(this) as HwndSource;
            //if (hwndSource != null)
                //hwndSource.AddHook(new HwndSourceHook(WndProc));

            IGRenderer.Run();
        }

        void StartMainWindorMessageLoop()
        {
            //Window a = new Window();
            //a.Dispacher.Invoke(DispatcherPriority.Normal, (Action)delegate () { a.Show(); });

            //ViewportGrid.Children.Add();

            //HwndSource hwndSource = HwndSource.FromHwnd(hwnd);
            //HwndSource hwndSource = PresentationSource.FromVisual(this) as HwndSource;
            //if (hwndSource != null)
            //hwndSource.AddHook(new HwndSourceHook(WndProc));

            /*
            GEditor.View.Viewport viewport = new GEditor.View.Viewport();
            Dispatcher.Invoke((Action)(() =>
            {
                ViewportGrid.Children.Add(viewport);
            }));
            */

            //System.Windows.Threading.Dispatcher.Run();

        }

        void CreateViewport()
        {
            
        }

        public void GetSceneObjectProperties(string objName)
        {
            PropertiesPanel.Children.Clear();
            properties = new Properties_SceneObject();
            properties.SetMainWindow(this);
            properties.SetObjectName(objName);
            PropertiesPanel.Children.Add(properties);
            properties.GetSceneObjectProperties();
        }
    }
}