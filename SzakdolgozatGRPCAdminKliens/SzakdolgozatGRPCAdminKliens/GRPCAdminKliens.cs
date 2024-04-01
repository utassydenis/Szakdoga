using Grpc.Core;
using Grpc.Net.Client;
using System.Text;

namespace SzakdolgozatGRPCAdminKliens
{
    public partial class GRPCAdminKliens : Form
    {
        GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:7165");
        SzakdolgozatGreeter.SzakdolgozatGreeterClient client;
        string logFilePath = "C:\\Users\\utass\\Desktop\\Szakdoga\\SzakdolgozatGRPCAdminKliens\\SzakdolgozatGRPCAdminKliens\\Logs\\logFiles.txt";
        public GRPCAdminKliens()
        {
            InitializeComponent();
            client = new SzakdolgozatGreeter.SzakdolgozatGreeterClient(channel);
        }
        List<UserInformation> users = new List<UserInformation>();
        private void GRPCAdminKliensForm_Load(object sender, EventArgs e)
        {
            userLabel.Visible = false;
            startDateTimePicker.Enabled = false;
            endDateTimePicker.Enabled = false;
            refreshButton.Visible = true;
            setStartupVisibilities();
            changeDateTimeFormat();
            requestUserList();
            setupUserEventsDataGridView();
        }
        private void startDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (startDateCheckBox.Checked)
            {
                startDateTimePicker.Enabled = true;
            }
            else
            {
                startDateTimePicker.Enabled = false;
            }
        }
        private void endDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (endDateCheckBox.Checked)
            {
                endDateTimePicker.Enabled = true;
            }
            else
            {
                endDateTimePicker.Enabled = false;
            }
        }
        private void submitButton_Click(object sender, EventArgs e)
        {
            if (userIDComboBox.SelectedItem != null)
            {
                populateUserEventsDataGridView();
            }
            else
            {
                MessageBox.Show("Select a user");
            }
        }
        private void changeDateTimeFormat()
        {
            startDateTimePicker.Format = DateTimePickerFormat.Custom;
            startDateTimePicker.CustomFormat = "yyyy'-'MM'-'dd";
            endDateTimePicker.Format = DateTimePickerFormat.Custom;
            endDateTimePicker.CustomFormat = "yyyy'-'MM'-'dd";
        }
        private DatedUserInformation setupDatedUserInformation()
        {
            DatedUserInformation tmpDatedUserInformation = new DatedUserInformation();
            tmpDatedUserInformation.UserInfo = users.Find(x => x.UserName == userIDComboBox.SelectedItem);
            tmpDatedUserInformation.StartTime = "";
            tmpDatedUserInformation.EndTime = "";
            if (startDateTimePicker.Enabled)
            {
                tmpDatedUserInformation.StartTime = startDateTimePicker.Text + " 23:59:59";
            }
            if (endDateTimePicker.Enabled)
            {
                tmpDatedUserInformation.EndTime = endDateTimePicker.Text + " 23:59:59";
            }
            return tmpDatedUserInformation;
        }
        private async void requestUserList()
        {
            try
            {
                using (var call = client.ListUsers(new Empty { }))
                {
                    while (await call.ResponseStream.MoveNext())
                    {
                        UserInformation tmp = call.ResponseStream.Current;
                        if (tmp.UserId == 00)
                        {
                            MessageBox.Show("Az adatbázist nem lehetett elérni.", "Error");
                            refreshButton.Visible = true;
                        }
                        else
                        {
                            users.Add(tmp);
                            userIDComboBox.Items.Add(tmp.UserName);
                            startDateCheckBox.Visible = true;
                            startDateTimePicker.Visible = true;
                            endDateCheckBox.Visible = true;
                            endDateTimePicker.Visible = true;
                            submitButton.Visible = true;
                            refreshButton.Visible = false;
                            userIDComboBox.Visible = true;
                            userLabel.Visible = true;
                        }
                    }
                }
            }
            catch (RpcException ex)
            {
                popUpMessage();
                File.AppendAllText(logFilePath, ex.Message + " A GRPC szervert nem lehetett elérni. " + ",Time:" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "\n", Encoding.UTF8);
            }
        }
        private void setupUserEventsDataGridView()
        {
            userEventsdataGridView.AllowUserToAddRows = false;

            userEventsdataGridView.ColumnCount = 7;
            userEventsdataGridView.Columns[0].Name = "Username";
            userEventsdataGridView.Columns[1].Name = "User ID";
            userEventsdataGridView.Columns[2].Name = "Card ID";
            userEventsdataGridView.Columns[3].Name = "Door ID";
            userEventsdataGridView.Columns[4].Name = "Door name";
            userEventsdataGridView.Columns[5].Name = "Event";
            userEventsdataGridView.Columns[6].Name = "Event time";
            userEventsdataGridView.AutoResizeColumns();
            userEventsdataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private async void populateUserEventsDataGridView()
        {
            try
            {
                userEventsdataGridView.Rows.Clear();
                using (var call = client.ListUserActivity(setupDatedUserInformation()))
                {
                    while (await call.ResponseStream.MoveNext())
                    {
                        UserActivity activity = call.ResponseStream.Current;
                        string[] row = new string[] {activity.UserInfo.UserName,activity.UserInfo.UserId.ToString(),
                                activity.DoorEvent.CardInformation.CardID,activity.DoorEvent.DoorInfo.DoorID.ToString(),activity.DoorEvent.DoorInfo.DoorName,
                                activity.EventType,activity.EventTime};
                        userEventsdataGridView.Rows.Add(row);
                    }
                }
            }
            catch (RpcException ex)
            {
                popUpMessage();
                File.AppendAllText(logFilePath, ex.Message + " A GRPC szervert nem lehetett elérni. " + ",Time:" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "\n", Encoding.UTF8);
            }
        }
        private void setStartupVisibilities()
        {
            startDateCheckBox.Visible = false;
            startDateTimePicker.Visible = false;
            endDateCheckBox.Visible = false;
            endDateTimePicker.Visible = false;
            userIDComboBox.Visible = false;
            submitButton.Visible = false;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            requestUserList();
        }
        private void popUpMessage()
        {
            MessageBox.Show("A GRPC szervert nem lehetett elérni. Nézze meg a log fájlt.", "Error");
        }
    }
}