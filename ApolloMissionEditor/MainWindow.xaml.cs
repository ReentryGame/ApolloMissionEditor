using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Controls.Primitives;
using Apollo.Mission;

namespace MercuryMissionEditor
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MissionDescription loadedMission = new MissionDescription();
        MissionCommand newCommand = new MissionCommand();

        public delegate Point GetPosition(IInputElement element);
        int rowIndexCmd = -1;
        int rowIndexGoals = -1;
        int rowIndexActy = -1;
        int currentActivity = 0;
        

        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            GoalGrid.MouseLeftButtonDown += GoalGrid_PreviewMouseLeftButtonDown;
            GoalGrid.Drop += GoalGrid_Drop;
            CommandGrid.MouseLeftButtonDown += CommandGrid_MouseLeftButtonDown;
            CommandGrid.Drop += CommandGrid_Drop;
            ActivityGrid.MouseLeftButtonDown += ActivityGrid_MouseLeftButtonDown;
            ActivityGrid.Drop += ActivityGrid_Drop;
        }

        private void ActivityGrid_Drop(object sender, DragEventArgs e)
        {
            if (rowIndexActy < 0)
                return;
            int index = this.GetCurrentRowIndex(e.GetPosition, ActivityGrid);
            if (index < 0)
                return;
            if (index == rowIndexActy)
                return;
            if (index == ActivityGrid.Items.Count - 1)
            {
                MessageBox.Show("Unable to drop this row");
                return;
            }
            var changedProduct = loadedMission.MissionActivities[currentActivity].Steps[rowIndexActy];
            loadedMission.MissionActivities[currentActivity].Steps.RemoveAt(rowIndexActy);
            loadedMission.MissionActivities[currentActivity].Steps.Insert(index, changedProduct);

            RefreshActivityGrid();
        }

        private void ActivityGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            rowIndexActy = GetCurrentRowIndex(e.GetPosition, ActivityGrid);
            if (rowIndexActy < 0)
                return;
            ActivityGrid.SelectedIndex = rowIndexActy;
            var selectedEmp = ActivityGrid.Items[rowIndexActy] as ActivityStep;
            if (selectedEmp == null)
                return;
            DragDropEffects dragdropeffects = DragDropEffects.Move;
            if (DragDrop.DoDragDrop(ActivityGrid, selectedEmp, dragdropeffects)
                                != DragDropEffects.None)
            {
                ActivityGrid.SelectedItem = selectedEmp;
            }
        }

        // https://www.c-sharpcorner.com/UploadFile/raj1979/drag-and-drop-datagrid-row-in-wpf/
        private void CommandGrid_Drop(object sender, DragEventArgs e)
        {
            if (rowIndexCmd < 0)
                return;
            int index = this.GetCurrentRowIndex(e.GetPosition, CommandGrid);
            if (index < 0)
                return;
            if (index == rowIndexCmd)
                return;
            if (index == CommandGrid.Items.Count - 1)
            {
                MessageBox.Show("Unable to drop this row");
                return;
            }
            var changedProduct = loadedMission.MissionCommands[rowIndexCmd];
            loadedMission.MissionCommands.RemoveAt(rowIndexCmd);
            loadedMission.MissionCommands.Insert(index, changedProduct);

            RefreshCommandGrid();
        }

        private void CommandGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            rowIndexCmd = GetCurrentRowIndex(e.GetPosition, CommandGrid);
            if (rowIndexCmd < 0)
                return;
            CommandGrid.SelectedIndex = rowIndexCmd;
            var selectedEmp = CommandGrid.Items[rowIndexCmd] as MissionCommand;
            if (selectedEmp == null)
                return;
            DragDropEffects dragdropeffects = DragDropEffects.Move;
            if (DragDrop.DoDragDrop(CommandGrid, selectedEmp, dragdropeffects)
                                != DragDropEffects.None)
            {
                CommandGrid.SelectedItem = selectedEmp;
            }
        }

        private void GoalGrid_Drop(object sender, DragEventArgs e)
        {
            if (rowIndexGoals < 0)
                return;
            int index = this.GetCurrentRowIndex(e.GetPosition, GoalGrid);
            if (index < 0)
                return;
            if (index == rowIndexGoals)
                return;
            if (index == GoalGrid.Items.Count - 1)
            {
                MessageBox.Show("Unable to drop this row");
                return;
            }
            var changedProduct = loadedMission.MissionGoals[rowIndexGoals];
            loadedMission.MissionGoals.RemoveAt(rowIndexGoals);
            loadedMission.MissionGoals.Insert(index, changedProduct);

            RefreshGoalGrid();
        }

        private void GoalGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            rowIndexGoals = GetCurrentRowIndex(e.GetPosition, GoalGrid);
            if (rowIndexGoals < 0)
                return;
            GoalGrid.SelectedIndex = rowIndexGoals;
            var selectedEmp = GoalGrid.Items[rowIndexGoals] as MissionGoals;
            if (selectedEmp == null)
                return;
            DragDropEffects dragdropeffects = DragDropEffects.Move;
            if (DragDrop.DoDragDrop(GoalGrid, selectedEmp, dragdropeffects)
                                != DragDropEffects.None)
            {
                GoalGrid.SelectedItem = selectedEmp;
            }
        }
        private bool GetMouseTargetRow(Visual theTarget, GetPosition position)
        {
            if (theTarget == null)
                return false;

            Rect rect = VisualTreeHelper.GetDescendantBounds(theTarget);
            Point point = position((IInputElement)theTarget);
            return rect.Contains(point);
        }

        private DataGridRow GetRowItem(int index, DataGrid dateGrid)
        {
            if (dateGrid.ItemContainerGenerator.Status
                    != GeneratorStatus.ContainersGenerated)
                return null;
            return dateGrid.ItemContainerGenerator.ContainerFromIndex(index)
                                                            as DataGridRow;
        }

        private int GetCurrentRowIndex(GetPosition pos, DataGrid dateGrid)
        {
            int curIndex = -1;
            for (int i = 0; i < dateGrid.Items.Count; i++)
            {
                DataGridRow itm = GetRowItem(i, dateGrid);
                if (GetMouseTargetRow(itm, pos))
                {
                    curIndex = i;
                    break;
                }
            }
            return curIndex;
        }

        private void tbID_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (CheckTextbox(textBox))
            {
                loadedMission.Id = int.Parse(textBox.Text);
            }
        }

        private void LaunchTimeChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            loadedMission.ScheduledLaunchTime = timeLaunchDateTime.Value ?? DateTime.Now;
        }

        private void tbTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (CheckTextbox(textBox))
            {
                loadedMission.Title = textBox.Text;
            }
        }

        private void tbDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (CheckTextbox(textBox))
            {
                loadedMission.Description = textBox.Text;
            }
        }

        private void tbMinBeforeLaunch_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (CheckTextbox(textBox))
            {
                loadedMission.MinutesBeforeLaunch = float.Parse(textBox.Text);
            }
        }

        private void checkStartInOrbit_Checked(object sender, RoutedEventArgs e)
        {
           CheckBox checkBox = sender as CheckBox;
            if(checkBox != null)
            {
                loadedMission.StartInOrbit = checkBox.IsChecked ?? false;
            }
        }

        private void Briefing_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (CheckTextbox(textBox))
            {
                loadedMission.BriefingText = textBox.Text;
            }
        }

        private void tbTargetAp_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (CheckTextbox(textBox))
            {
                loadedMission.TargetAp = float.Parse(textBox.Text);
            }
        }

        private void tbTargetPe_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (CheckTextbox(textBox))
            {
                loadedMission.TargetPe = float.Parse(textBox.Text);
            }
        }

        private void tbTargetInc_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (CheckTextbox(textBox))
            {
                loadedMission.Inclination = float.Parse(textBox.Text);
            }
        }

        private void timeToRetroMinutes_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb != null)
            {
                int index = cb.SelectedIndex;
                int action = 0;
                if(index == 0)
                {
                    action = 0;
                }
                newCommand.Action = (MissionCommand.ExecuteAction)action;
            }
        }

        private void tbTimestamp_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (CheckTextbox(textBox))
            {
                newCommand.Timestamp = float.Parse(textBox.Text);
            }
        }

        private void tbValue1_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (CheckTextbox(textBox))
            {
                newCommand.Value1 = float.Parse(textBox.Text);
            }
        }

        private void tbValue2_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (CheckTextbox(textBox))
            {
                newCommand.Value2 = float.Parse(textBox.Text);
            }
        }

        private void tbValue3_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (CheckTextbox(textBox))
            {
                newCommand.Value3 = float.Parse(textBox.Text);
            }
        }

        private void tbString1_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (CheckTextbox(textBox))
            {
                newCommand.String1 = textBox.Text;
            }
        }

        private void tbString2_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (CheckTextbox(textBox))
            {
                newCommand.String2 = textBox.Text;
            }
        }

        private void tbString3_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (CheckTextbox(textBox))
            {
                newCommand.String3 = textBox.Text;
            }
        }

        private void tbThreshold_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (CheckTextbox(textBox))
            {
                newCommand.ThresholdLimit = float.Parse(textBox.Text);
            }
        }

        private void tbMessage_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (CheckTextbox(textBox))
            {
                newCommand.Message = textBox.Text;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            loadedMission.AddCommand(newCommand);
            RefreshCommandGrid();
            ClearNewCommandFields();

            newCommand = new MissionCommand();
        }

        private void GridLoaded(object sender, RoutedEventArgs e)
        {
            RefreshLabel();
            RefreshCommandGrid();
        }

        void RefreshCommandGrid()
        {
            CommandGrid.ItemsSource = null;
            CommandGrid.ItemsSource = loadedMission.MissionCommands;
        }
        
        private void GoalGridLoaded(object sender, RoutedEventArgs e)
        {
            RefreshGoalGrid();
        }

        void RefreshGoalGrid()
        {
            GoalGrid.ItemsSource = null;
            GoalGrid.ItemsSource = loadedMission.MissionGoals;
        }

        bool CheckTextbox(TextBox textBox)
        {
            if (textBox != null)
                if (textBox.Text != null)
                    if (textBox.Text != "")
                        return true;
            return false;
        }
        private void btnExportJson_Click(object sender, RoutedEventArgs e)
        {
            int minutes = 0;
            int seconds = 0;

            if (CheckTextbox(timeToRetroMinutes))
            {
                minutes = int.Parse(timeToRetroMinutes.Text);
            }
            if (CheckTextbox(timeToRetroSeconds))
            {
                seconds = int.Parse(timeToRetroSeconds.Text);
            }

            TimeSpan ts = new TimeSpan(0, minutes, seconds);
            loadedMission.InitialTimeToRetrograde = ts;


            string fileText = JsonConvert.SerializeObject(loadedMission);

            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "JSON Files(*.json)|*.json|All(*.*)|*"
            };

            if (dialog.ShowDialog() == true)
            {
                File.WriteAllText(dialog.FileName, fileText);

                this.Title = "Apollo Mission Editor - " + dialog.FileName;
            }
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "JSON Files(*.json)|*.json|All(*.*)|*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string loadedJson = File.ReadAllText(openFileDialog.FileName);
                loadedMission = JsonConvert.DeserializeObject<MissionDescription>(loadedJson);
                RefreshFields();
                RefreshCommandGrid();
                RefreshGoalGrid();
                RefreshActivityGrid();
                RefreshActivity();
                RefreshLabel();

                this.Title = "Apollo Mission Editor - " + openFileDialog.FileName;
            }
        }

        void RefreshFields()
        {
            tbID.Text = loadedMission.Id.ToString();
            tbTitle.Text = loadedMission.Title;
            tbDescription.Text = loadedMission.Description;
            timeLaunchDateTime.Value = loadedMission.ScheduledLaunchTime;
            checkStartInOrbit.IsChecked = loadedMission.StartInOrbit;
            tbCoPilotName.Text = loadedMission.CommandModulePilot;
            tbLunarPilotName.Text = loadedMission.LunarModulePilot;
            tbMinBeforeLaunch.Text = loadedMission.MinutesBeforeLaunch.ToString();
            Briefing.Text = loadedMission.BriefingText;
            tbTargetAp.Text = loadedMission.TargetAp.ToString();
            tbTargetPe.Text = loadedMission.TargetPe.ToString();
            tbTargetInc.Text = loadedMission.Inclination.ToString();
            timeToRetroMinutes.Text = ((loadedMission.InitialTimeToRetrograde.Hours * 60) + loadedMission.InitialTimeToRetrograde.Minutes).ToString();
            timeToRetroSeconds.Text = loadedMission.InitialTimeToRetrograde.Seconds.ToString();
            tbLoadStateFile.Text = loadedMission.LoadState.ToString();
            cbDisableDefaultSFX.IsChecked = loadedMission.DisableDefaultAudioSFX;
            comboPayload.SelectedIndex = (int)loadedMission.Payload;
        }

        void ClearNewCommandFields()
        {
            cbAction.SelectedIndex = 0;
            comboPayload.SelectedIndex = 1;
            tbTimestamp.Text = "";
            tbValue1.Text = "";
            tbValue2.Text = "";
            tbValue3.Text = "";
            tbString1.Text = "";
            tbString2.Text = "";
            tbString3.Text = "";
            tbThreshold.Text = "";
            tbMessage.Text = "";
            tbLoadStateFile.Text = "";

            cbDisableDefaultSFX.IsChecked = false;
        }

        private void mi_moveUp_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ActivityGridLoaded(object sender, RoutedEventArgs e)
        {
            RefreshActivityGrid();
            RefreshActivity();
        }

        void RefreshActivityGrid()
        {
            ActivityGrid.ItemsSource = null;
            if(loadedMission.MissionActivities != null)
            {
                if(loadedMission.MissionActivities.Count > 0)
                {
                    ActivityGrid.ItemsSource = loadedMission.MissionActivities[currentActivity].Steps;
                }
            }
        }

        private void btnPrevActivit_Click(object sender, RoutedEventArgs e)
        {
            currentActivity--;
            if (currentActivity < 0)
                currentActivity = 0;
            RefreshActivity();
        }

        void RefreshLabel()
        {
            lblCurrentActivity.Content = "Activity: " +(currentActivity+1) +"/" + loadedMission.MissionActivities.Count;
        }

        void RefreshActivity()
        {
            if (loadedMission.MissionActivities.Count <= 0)
                return;

            tbActivityTitle.Text = loadedMission.MissionActivities[currentActivity].Title;
            tbActivityDescription.Text = loadedMission.MissionActivities[currentActivity].Description;
            tbActivityPoints.Text = loadedMission.MissionActivities[currentActivity].Points.ToString();
            tbActivityTimeLimit.Text = loadedMission.MissionActivities[currentActivity].TimeLimit.ToString();

            RefreshActivityGrid();
            RefreshLabel();
        }

        private void btnAddActivit_Click(object sender, RoutedEventArgs e)
        {
            currentActivity = 0;
            loadedMission.MissionActivities.Add(new MissionActivity());
            RefreshActivityGrid();
            RefreshLabel();
        }

        private void tbActivityTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(loadedMission.MissionActivities.Count > 0)
                loadedMission.MissionActivities[currentActivity].Title = tbActivityTitle.Text;
        }

        private void tbActivityPoints_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (loadedMission.MissionActivities.Count > 0)
            {
                if (tbActivityPoints.Text.Length > 0)
                {
                    int p;
                    if (int.TryParse(tbActivityPoints.Text, out p))
                        loadedMission.MissionActivities[currentActivity].Points = p;
                }
            }
        }

        private void tbActivityDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (loadedMission.MissionActivities.Count > 0)
                loadedMission.MissionActivities[currentActivity].Description = tbActivityDescription.Text;
        }

        private void btnNextActivit_Click(object sender, RoutedEventArgs e)
        {
            currentActivity++;
            if (currentActivity >= loadedMission.MissionActivities.Count)
                currentActivity = loadedMission.MissionActivities.Count - 1;
            RefreshActivity();
        }

        private void tbActivityTimeLimit_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (loadedMission.MissionActivities.Count > 0)
            {
                if(tbActivityTimeLimit.Text.Length > 0)
                {
                    int p;
                    if(int.TryParse(tbActivityTimeLimit.Text, out p))
                        loadedMission.MissionActivities[currentActivity].TimeLimit = p;
                }
            }
        }

        private void tbCoPilotName_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (CheckTextbox(textBox))
            {
                loadedMission.CommandModulePilot = textBox.Text;
            }
        }

        private void tbLunarPilotName_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (CheckTextbox(textBox))
            {
                loadedMission.LunarModulePilot = textBox.Text;
            }
        }

        private void tbLoadStateFile_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (CheckTextbox(textBox))
            {
                loadedMission.LoadState = textBox.Text;
            }
        }

        private void cbDisableDefaultSFX_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                loadedMission.DisableDefaultAudioSFX = checkBox.IsChecked ?? false;
            }
        }

        private void comboPayload_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb != null)
            {
                int index = cb.SelectedIndex;

                loadedMission.Payload = (MissionDescription.PayloadSelection)index;
            }
        }
    }
}
