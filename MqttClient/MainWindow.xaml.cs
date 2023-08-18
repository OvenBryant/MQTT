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

using System.Net;
using System.Net.Sockets;
using MQTTnet;
using MQTTnet.Client;
using NLE.Device.ZigBee;
using System.Windows.Threading;

namespace MqttClient
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        IMqttClient client;
        ZigBeeSeries zig;
        public MainWindow()
        {
            InitializeComponent();

            zig = new ZigBeeSeries();
            zig.DataReceived += Zig_DataReceived;

            client = new MqttFactory().CreateMqttClient();
            client.ApplicationMessageReceived += Client_ApplicationMessageReceived;
            client.Connected += Client_Connected;
            client.Disconnected += Client_Disconnected;
            //textBox_IP.Text = Dns.GetHostAddresses(Dns.GetHostName())
            //   .Where(t => t.AddressFamily.Equals(AddressFamily.InterNetwork))
            //   .First()
            //   .ToString();
            textBox_IP.Text = "127.0.0.1";
            textBox_Port.Text = "1883";

            ChangeIsEndabled(false);
        }

        private void ChangeIsEndabled(bool b)
        {
            Dispatcher.Invoke(() =>
            {
                button_Connect.IsEnabled = !b;
                button_DisConnect.IsEnabled = b;
                button_Publish.IsEnabled = b;
                button_Subscribe.IsEnabled = b;
                button_Unsubscribe.IsEnabled = b;
            });
        }

        private void Zig_DataReceived(object sender, ZigBeeDataEventArgs e)
        {
            message = new MqttApplicationMessage()
            {
                Topic = "temp",
                Payload = Encoding.UTF8.GetBytes(e.Data.Value1.ToString())
            };
            client.PublishAsync(message);
        }

        private void Client_Disconnected(object sender, MqttClientDisconnectedEventArgs e)
        {
            MessageBox.Show("已断开");
            ChangeIsEndabled(false);
        }

        private void Client_Connected(object sender, MqttClientConnectedEventArgs e)
        {
            MessageBox.Show("true");
            zig.Connect("COM200", 38400);
            ChangeIsEndabled(true);
        }

        private void Client_ApplicationMessageReceived(object sender, MqttApplicationMessageReceivedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                listBox_Record.Items.Add($"" +
                    $"主题：{e.ApplicationMessage.Topic}" +
                    $"内容：{Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
            });
        }

        IMqttClientOptions options;
        private void button_Connect_Click(object sender, RoutedEventArgs e)
        {
            options = new MqttClientOptionsBuilder()
                .WithTcpServer(textBox_IP.Text, int.Parse(textBox_Port.Text))
                .Build();
            client.ConnectAsync(options);
        }

        MqttApplicationMessage message;
        private void button_Publish_Click(object sender, RoutedEventArgs e)
        {
            message = new MqttApplicationMessage()
            {

                Topic = textBox_Title.Text,
                Payload = Encoding.UTF8.GetBytes(textBox_Content.Text)
            };
            client.PublishAsync(message);
        }

        private void button_Subscribe_Click(object sender, RoutedEventArgs e)
        {
            client.SubscribeAsync(textBox_Title.Text);
        }

        private void button_Unsubscribe_Click(object sender, RoutedEventArgs e)
        {
            client.UnsubscribeAsync(textBox_Title.Text);
        }

        private void button_DisConnect_Click(object sender, RoutedEventArgs e)
        {
            zig.Close();
            client.DisconnectAsync();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            listBox_Record.Items.Clear();
        }
    }
}
