using Grpc.Core;
using Grpc.Net.Client;
using MiFare;
using MiFare.Classic;
using MiFare.Devices;
using MiFare.PcSc;
using System.Diagnostics;
using System.Text;

namespace SzakdolgozatGRPCKliens
{
    public partial class GRPCKliens : Form
    {
        GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:7165");
        SzakdolgozatGreeter.SzakdolgozatGreeterClient client;
        string logFilePath = "..\\..\\..\\LogFiles\\logFiles.txt";
        private SmartCardReader reader;
        private MiFareCard card;
        string localCardID = "";
        public GRPCKliens()
        {
            InitializeComponent();
            GetDevices();
        }
        List<DoorInformation> doors = new List<DoorInformation>();
        private async void GRPCKliensForm_Load(object sender, EventArgs e)
        {
            client = new SzakdolgozatGreeter.SzakdolgozatGreeterClient(channel);
            Bitmap image = new Bitmap("..\\..\\..\\Pictures\\ACS-ACR1255U-J1-Front.jpg");
            scannerPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            scannerPictureBox.Image = (Image)image;
            try
            {
                using (var call = client.ListDoors(new Empty { }))
                {
                    while (await call.ResponseStream.MoveNext())
                    {
                        DoorInformation tmp = call.ResponseStream.Current;
                        doors.Add(tmp);
                        doorListComboBox.Items.Add(tmp.DoorName);
                    }
                }
            }
            catch (RpcException ex)
            {
                File.AppendAllText(logFilePath, ex.Message + ",Time:" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "\n", Encoding.UTF8);
            }
        }
        #region Reader and card handling
        private async void GetDevices()
        {
            try
            {
                reader = await CardReader.FindAsync();
                if (reader == null)
                {
                    ClientDisplayLabel.Text = "No Readers Found";
                    return;
                }

                reader.CardAdded += CardAdded;
                reader.CardRemoved += CardRemoved;
            }
            catch (Exception e)
            {
                File.AppendAllText(logFilePath, e.Message + ",Time:" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "\n", Encoding.UTF8);
            }
        }
        private void CardRemoved(object sender, EventArgs e)
        {
            Debug.WriteLine("Card Removed");
            card?.Dispose();
            card = null;

        }
        private async void CardAdded(object sender, CardEventArgs args)
        {
            Debug.WriteLine("Card Added");
            try
            {
                await HandleCard(args);
            }
            catch (Exception ex)
            {
                File.AppendAllText(logFilePath, ex.Message + ",Time:" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "\n", Encoding.UTF8);
            }
        }
        private async Task HandleCard(CardEventArgs args)
        {
            try
            {
                card?.Dispose();
                card = args.SmartCard.CreateMiFareCard();
                var localCard = card;
                var cardIdentification = await localCard.GetCardInfo();
                if (cardIdentification.PcscDeviceClass == MiFare.PcSc.DeviceClass.StorageClass
                     && (cardIdentification.PcscCardName == CardName.MifareStandard1K || cardIdentification.PcscCardName == CardName.MifareStandard4K))
                {
                    var uid = await localCard.GetUid();
                    localCardID = (BitConverter.ToString(uid));
                }
            }
            catch (Exception e)
            {
                File.AppendAllText(logFilePath, e.Message + ",Time:" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "\n", Encoding.UTF8);
            }
        }
        #endregion
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (reader == null)
            {
                GetDevices();
            }
            if (localCardID != "" && doorListComboBox.Text != "")
            {
                if (enterExitComboBox.Text == "Enter")
                {
                    EnterDoor();
                    localCardID = "";
                }
                else if (enterExitComboBox.Text == "Exit")
                {
                    ExitDoor();
                    localCardID = "";
                }
                else if (enterExitComboBox.Text == "Enter/Exit")
                {
                    EnterExitDoor();
                    localCardID = "";
                }
            }
        }
        private DoorEvent SetupDoorEvent()
        {
            CardInformation tmpCardInformation = new CardInformation();
            tmpCardInformation.CardID = localCardID;
            DoorInformation tmpDoorInformation = doors.Find(x => x.DoorName == doorListComboBox.SelectedItem.ToString());
            DoorEvent tmpEvent = new DoorEvent();
            tmpEvent.CardID = tmpCardInformation;
            tmpEvent.DoorInfo = tmpDoorInformation;
            return tmpEvent;
        }
        private void EnterDoor()
        {
            try
            {
                Result res = client.Enter(SetupDoorEvent());
                ClientDisplayLabel.Text = res.Message.ToString();
            }
            catch (RpcException ex)
            {
                File.AppendAllText(logFilePath, ex.Message + ",Time:" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "\n", Encoding.UTF8);
            }
        }
        private void ExitDoor()
        {
            try
            {
                Result res = client.Exit(SetupDoorEvent());
                ClientDisplayLabel.Text = res.Message.ToString();
            }
            catch (RpcException ex)
            {
                File.AppendAllText(logFilePath, ex.Message + ",Time:" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "\n", Encoding.UTF8);
            }
        }
        private void EnterExitDoor()
        {
            try
            {
                Result res = client.EnterExit(SetupDoorEvent());
                ClientDisplayLabel.Text = res.Message.ToString();
            }
            catch (RpcException ex)
            {
                File.AppendAllText(logFilePath, ex.Message + ",Time:" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "\n", Encoding.UTF8);
            }
        }
    }
}