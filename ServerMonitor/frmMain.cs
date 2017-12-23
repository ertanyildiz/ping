using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerMonitor
{
    public partial class frmMain : Form
    {
        private int columnCount = 4;


        /// <summary>
        /// device list
        /// </summary>
        public List<Device> Devices { get; set; }


        /// <summary>
        /// Ping result status
        /// </summary>
        public enum Status
        {
            Failed,
            Success
        }
        public frmMain()
        {
            InitializeComponent();
            timer1.Interval = 30000;
            timer1.Start();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblPingText.Text = "";
            CreateTable();
            SendPing();

        }
        /// <summary>
        /// Create buttons and place them in Table Layout Panel control.
        /// Set each button's tag to a device object.
        /// </summary>
        private void CreateTable()
        {
            var deviceList = new List<Device>();
            deviceList.Add(new Device() {Id = 1, Ip ="192.168.1.1", Label = "Main Server", Status = Status.Success });
            deviceList.Add(new Device() {Id = 2, Ip ="192.168.1.2", Label = "Web Server", Status = Status.Success });
            deviceList.Add(new Device() {Id = 3, Ip ="192.168.3.1", Label = "Camera 1", Status = Status.Success });
            deviceList.Add(new Device() {Id = 4, Ip ="192.168.3.2", Label = "Camera 2", Status = Status.Success });
            deviceList.Add(new Device() {Id = 5, Ip ="192.168.2.74", Label = "My Computer", Status = Status.Success });


            Devices = deviceList;

            tableLayoutPanelDevices.Controls.Clear();
            tableLayoutPanelDevices.RowStyles.Clear();
            tableLayoutPanelDevices.ColumnStyles.Clear();
            tableLayoutPanelDevices.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanelDevices.ColumnCount = deviceList.Count < 0 ? 1 : deviceList.Count;

            tableLayoutPanelDevices.RowCount = 1;
            for (int i = 0; i < 20; i++)
            {
                tableLayoutPanelDevices.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            }

            tableLayoutPanelDevices.RowStyles.Add(new RowStyle(SizeType.Percent, 20));

            foreach (var device in deviceList)
            {
                
                var myButton = new Button();
                myButton.Text = device.Label;
                myButton.Name = $"b_{device.Id}";
                myButton.Tag = device;
                myButton.Click += b_Click;
                myButton.Dock = DockStyle.Fill;
                myButton.FlatStyle = FlatStyle.Popup;
                myButton.BackColor = Color.BurlyWood;
                myButton.Font = new Font(myButton.Font.FontFamily, 16);
                tableLayoutPanelDevices.Controls.Add(myButton);
            }
            
        }

        void b_Click(object sender, EventArgs e)
        {
            var pingNumber = 1;
            
            var b = sender as Button;
            Device device = null;
            var backColor = b.BackColor;
            try
            {
                device = (Device)b.Tag;
                b.Tag = device;
                b.BackColor = Color.DarkOrange;
                var sor = MessageBox.Show($"Send ping to device? ({device.Label})", "", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (sor == DialogResult.Yes)
                {
                    var ping = Ping(device.Ip, pingNumber);
                    if (ping)
                    {
                        b.BackColor = Color.GreenYellow;
                        return;
                    }
                    b.BackColor = Color.Red;
                    var notification = new NotifyIcon()
                    {
                        Visible = true,
                        Icon = SystemIcons.Exclamation,
                        BalloonTipTitle = "Failed",
                        BalloonTipText = device.Label,
                    };

                    notification.ShowBalloonTip(3000);


                    notification.Dispose();
                }
                else
                {
                    b.BackColor = backColor;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        /// <summary>
        /// Send ping to given ip adress.
        /// </summary>
        /// <param name="ip">Ip adress of the host.</param>
        /// <param name="pingNumber">Number of ping sending.</param>
        /// <returns></returns>
        public bool Ping(string ip, int pingNumber)
        {

            var pingable = false;
            using (Ping pinger = new Ping())
            {
                try
                {
                    for (int i = 0; i < pingNumber; i++)
                    {
                        PingReply reply = pinger.Send(ip);
                        if (reply != null) pingable = reply.Status == IPStatus.Success;
                        if (!pingable) continue;
                        break;

                    }

                }
                catch (PingException)
                {
                }
            }
            return pingable;
        }


        /// <summary>
        /// Call SendPing method when timer ticks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            SendPing();
        }
        /// <summary>
        /// Check each devices in the Devices. Send ping to each devices.
        /// Set the button color to ping result (yellow or red).
        /// </summary>
        private async void SendPing()
        {
            lblPingText.Text = "Sending ping...";
            if (Devices.Count > 0)
            {
                foreach (var device in Devices)
                {
                    if (device == null) continue;

                    var btnControls = Controls.Find($"b_{device.Id}", true);
                    var btn = btnControls[0];
                    btn.BackColor = Color.Gold;
                    var tempText = btn.Text;
                    btn.Text = "...";
                    Task<bool> task = Task.Run(() => Ping(device.Ip, 1));
                    device.Status = await task ? Status.Success : Status.Failed;
                    btn.BackColor = device.Status == Status.Success ? Color.GreenYellow : Color.Red;
                    btn.Tag = device;
                    btn.Text = tempText;
                }
            }

            lblPingText.Text = $"Latest ping sent date: {DateTime.Now.ToString("HH:mm")}";
        }
    
    }

    public class Device
    {
        public string Ip { get; set; }
        public int Id { get; set; }
        public string Label { get; set; }
        public frmMain.Status Status { get; set; }

    }
}
