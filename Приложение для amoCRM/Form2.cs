using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Приложение_для_amoCRM
{
    public partial class Form2 : Form
    {
        ListBox currentList;
        public void loadTasks(Task item, Panel panel)
        {
            var listBox = createListBox(item);

            int y = (listBox.Height - 12) * panel.Controls.Count;
            panel.Controls.Add(listBox);
            listBox.Location = new Point(listBox.Location.X, 0 + y);
        }
        public void updatePanel(Panel panel)
        {
            int index = 0;
            foreach (ListBox item in panel.Controls)
            {
                int y = currentList.Height * index;
                item.Location = new Point(item.Location.X, 0 + y);
                index++;
            }
        }
        public ListBox createListBox(Task item)
        {
            ListBox listBox = new ListBox();
            listBox.Width = panel1.Width;
            listBox.HorizontalScrollbar = true;
            listBox.Items.Add(item.owner);
            listBox.Items.Add(item.date);
            listBox.Items.Add(item.theTask);
            listBox.Click += listBox_Click;
            return listBox;
        }
        public void listBox_Click(object? sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            currentList = listBox;
        }
        public Form2()
        {
            InitializeComponent();

            foreach (var item in Task.tasks)
            {
                if (Convert.ToDateTime(item.date).Date < DateTime.Today)
                {
                    loadTasks(item, panel1);
                }
                else if (Convert.ToDateTime(item.date).Date == DateTime.Today)
                {
                    loadTasks(item, panel2);
                }
                else if (Convert.ToDateTime(item.date).Date == DateTime.Today.AddDays(1))
                {
                    loadTasks(item, panel3);
                }
                else if (Convert.ToDateTime(item.date).Date > DateTime.Today.AddDays(1))
                {
                    loadTasks(item, panel4);
                }
            }
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            if (currentList != null)
            {
                int y = currentList.Height * panel2.Controls.Count;
                panel2.Controls.Add(currentList);
                updatePanel(panel1);
                updatePanel(panel3);
                updatePanel(panel4);
                currentList.Location = new Point(currentList.Location.X, 0 + y);

                for (int i = 0; i < Task.tasks.Count; i++)
                {
                    if (Task.tasks[i].owner.Contains(currentList.Items[0].ToString()))
                        if (Task.tasks[i].theTask.Contains(currentList.Items[2].ToString()))
                        {
                            Task.tasks[i].date = DateTime.Today.ToString();
                            currentList.Items[1] = Task.tasks[i].date;
                            StreamWriter sw = File.CreateText("Tasks.txt");

                            foreach (Task task in Task.tasks)
                            {
                                sw.WriteLine($"{task.owner}~{task.date}~{task.theTask}");
                            }

                            sw.Close();
                            break;
                        }
                }
                currentList = null;
            }
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            if (currentList != null)
            {
                int y = currentList.Height * panel3.Controls.Count;
                panel3.Controls.Add(currentList);
                updatePanel(panel1);
                updatePanel(panel2);
                updatePanel(panel4);
                currentList.Location = new Point(currentList.Location.X, 0 + y);

                for (int i = 0; i < Task.tasks.Count; i++)
                {
                    if (Task.tasks[i].owner.Contains(currentList.Items[0].ToString()))
                        if (Task.tasks[i].theTask.Contains(currentList.Items[2].ToString()))
                        {
                            Task.tasks[i].date = DateTime.Today.AddDays(1).ToString();
                            currentList.Items[1] = Task.tasks[i].date;
                            StreamWriter sw = File.CreateText("Tasks.txt");

                            foreach (Task task in Task.tasks)
                            {
                                sw.WriteLine($"{task.owner}~{task.date}~{task.theTask}");
                            }

                            sw.Close();
                            break;
                        }
                }
                currentList = null;
            }
        }
    }
}
