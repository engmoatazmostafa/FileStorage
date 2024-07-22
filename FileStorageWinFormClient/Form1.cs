using FileStorageWinFormClient.Services;

namespace FileStorageWinFormClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            AuthService service = new AuthService(httpClient, this.baseURLTxt.Text);
            this.tokenTxt.Text = service.LoginAsync(this.usernameTxt.Text, this.passwordTxt.Text).Result;
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set filter options for the dialog (optional)
            //openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            // Allow selecting multiple files (optional)
            openFileDialog.Multiselect = false;  // Set to true for multiple selection

            // Show the dialog
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                string filePath = openFileDialog.FileName;

                // Do something with the file path
                // Example: Display the path in a label
                filePathLbl.Text = $"Selected File: {filePath}";

                // You can now use the file path to open the file for reading, writing, etc.
                // ... your code to process the file ...
            }

        }

        private void baseURLTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
