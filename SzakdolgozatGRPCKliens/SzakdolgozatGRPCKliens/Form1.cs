using Grpc.Core;
using Grpc.Net.Client;
using MiFare;
using MiFare.Classic;
using MiFare.Devices;
using MiFare.PcSc;

using System.Diagnostics;
using System.Text;
using SzakdolgozatGRPCKliens;
namespace SzakdolgozatGRPCKliens
{
    public partial class Form1 : Form
    {
        GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:7165");
        SzakdolgozatGreeter.SzakdolgozatGreeterClient client;

        private SmartCardReader reader;
        private MiFareCard card;
        string localCardID;
        public Form1()
        {
            InitializeComponent();
            GetDevices();
        }

        List<DoorInformation> doors = new List<DoorInformation>();
        private async void Form1_Load(object sender, EventArgs e)
        {
            client = new SzakdolgozatGreeter.SzakdolgozatGreeterClient(channel);
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

            }
        }

        private async void GetDevices()
        {
            try
            {
                reader = await CardReader.FindAsync();
                if (reader == null)
                {
                    //label1.Text = "No Readers Found";
                    return;
                }

                reader.CardAdded += CardAdded;
                reader.CardRemoved += CardRemoved;
            }
            catch (Exception e)
            {
                //label1.Text = "Exception: " + e.Message;
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
                //label1.Text = "CardAdded Exception: " + ex.Message;
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
                //label1.Text = ("Connected to card\r\nPC/SC device class: " + cardIdentification.PcscDeviceClass.ToString() + "\r\nCard name: " + cardIdentification.PcscCardName.ToString());

                if (cardIdentification.PcscDeviceClass == MiFare.PcSc.DeviceClass.StorageClass
                     && (cardIdentification.PcscCardName == CardName.MifareStandard1K || cardIdentification.PcscCardName == CardName.MifareStandard4K))
                {
                    var uid = await localCard.GetUid();
                    localCardID = (BitConverter.ToString(uid));
                }                
            }
            catch (Exception e)
            {
                //label1.Text = ("HandleCard Exception: " + e.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = localCardID;
            if(localCardID != "" && doorListComboBox.Text != "")
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

            }


        }

        private void EnterDoor()
        {
            try
            {
                DoorInformation tmp = doors.Find(x => x.DoorName == doorListComboBox.SelectedItem.ToString());
                label2.Text = tmp.DoorName;
                DoorEvent tmpEvent = new DoorEvent();
                tmpEvent.CardID = localCardID;
                tmpEvent.DoorID = tmp.DoorID;
                tmpEvent.DoorName = tmp.DoorName;

                Result res = client.Enter(tmpEvent);
                label2.Text = res.ToString();

            }
            catch
            {

            }
        }
        private void ExitDoor()
        {
            try
            {
                DoorInformation tmp = doors.Find(x => x.DoorName == doorListComboBox.SelectedItem.ToString());
                label2.Text = tmp.DoorName;
                DoorEvent tmpEvent = new DoorEvent();
                tmpEvent.CardID = localCardID;
                tmpEvent.DoorID = tmp.DoorID;
                tmpEvent.DoorName = tmp.DoorName;

                Result res = client.Exit(tmpEvent);
                label2.Text = res.ToString();
            }
            catch
            {

            }
        }
    }
}