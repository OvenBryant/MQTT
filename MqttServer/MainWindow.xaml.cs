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

using MQTTnet;
using MQTTnet.Server;
using System.Net;
using System.Net.Sockets;

namespace MqttServer
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        IMqttServer server;
        public MainWindow()
        {
            InitializeComponent();

            server = new MqttFactory().CreateMqttServer();
            server.ClientConnected += Server_ClientConnected;  // 连接
            server.ClientDisconnected += Server_ClientDisconnected;  // 断开
            server.ClientSubscribedTopic += Server_ClientSubscribedTopic; // 订阅主题
            server.ClientUnsubscribedTopic += Server_ClientUnsubscribedTopic;// 取消订阅主题
            server.Started += Server_Started;
            server.Stopped += Server_Stopped;


            //textBox_IP.Text = Dns.GetHostAddresses(Dns.GetHostName())
            //    .Where(t => t.AddressFamily.Equals(AddressFamily.InterNetwork))
            //    .First()
            //    .ToString();
            textBox_IP.Text = "127.0.0.1";
            // textBox_IP.Text = IPAddress.Any.ToString() ;
            textBox_Port.Text = "1883";
        }

        private void Server_Stopped(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                listBox.Items.Add(string.Format("服务器已停止"));
            });
        }

        private void Server_Started(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                listBox.Items.Add(string.Format("服务器已启动"));
            });
        }

        private void Server_ClientUnsubscribedTopic(object sender, MqttClientUnsubscribedTopicEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                listBox.Items.Add(string.Format("{0}已取消订阅{1}", e.ClientId, e.TopicFilter));
            });
        }

        private void Server_ClientSubscribedTopic(object sender, MqttClientSubscribedTopicEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                listBox.Items.Add(string.Format("{0}已订阅{1}", e.ClientId, e.TopicFilter.Topic));
            });
        }

        private void Server_ClientDisconnected(object sender, MqttClientDisconnectedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                listBox.Items.Add(e.ClientId + "已断开");
            });
        }

        private void Server_ClientConnected(object sender, MqttClientConnectedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                listBox.Items.Add(e.ClientId + "已连接");
            });
        }

        bool isStart = false;
        private void button_Switch_Click(object sender, RoutedEventArgs e)
        {
            isStart = !isStart;
            if (isStart)
            {
                button_Switch.Content = "关闭";
                IMqttServerOptions serverOptions = new MqttServerOptionsBuilder()
                    .WithDefaultEndpointBoundIPAddress(IPAddress.Parse(textBox_IP.Text))
                    .WithDefaultEndpointPort(int.Parse(textBox_Port.Text))
                    .Build();
                server.StartAsync(serverOptions);
            }
            else
            {
                button_Switch.Content = "开启";
                server.StopAsync();
            }
            textBox_IP.IsEnabled = !isStart;
            textBox_Port.IsEnabled = !isStart;
        }
    }
}
