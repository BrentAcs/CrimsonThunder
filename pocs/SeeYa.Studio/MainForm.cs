using SeeYa.Core;
using SeeYa.Core.Models;

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

      storiesToolStripComboBox.Items.AddRange(Globals.Repos.StoryRepo.GetAll().Result.ToArray());
      storiesToolStripComboBox.SelectedIndex = AppSettings.Default.MainForm_LastStoryIndex;

      RunStory();
   }

   private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
   {
      AppSettings.Default.MainForm_Location = Location;
      AppSettings.Default.MainForm_Size = Size;
      AppSettings.Default.MainForm_LastStoryIndex = storiesToolStripComboBox.SelectedIndex;
   }

   private void storiesToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
   {
      var test = storiesToolStripComboBox.SelectedIndex;
   }

   private void runStoryToolStripButton_Click(object sender, EventArgs e) => RunStory();

   private void RunStory()
   {
      var storyId = ((Story)storiesToolStripComboBox.SelectedItem).Id;

      var runnerForm = new RunnerForm();
      runnerForm.ShowDialog(this, storyId.ToString());

   }
}
