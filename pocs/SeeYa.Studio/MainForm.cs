namespace SeeYa.Studio;

public partial class MainForm : Form
{
   public MainForm()
   {
      InitializeComponent();
   }

   private void MainForm_Load(object sender, EventArgs e)
   {
      Location = AppSettings.Default.MainForm_Location;
      Size = AppSettings.Default.MainForm_Size;
   }

   private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
   {
       AppSettings.Default.MainForm_Location = Location;
       AppSettings.Default.MainForm_Size = Size;
   }
}
