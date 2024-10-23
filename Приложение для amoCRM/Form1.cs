using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Telegram;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Telegram.Bot;
using System.IO;
using System.Text;


namespace Приложение_для_amoCRM
{
    public partial class Form1 : Form
    {
        public async void sendNot(string mes, int days)
        {
            List<Task> todayTasks = new List<Task>();
            foreach (var task in Task.tasks)
            {
                if (DateTime.Today.AddDays(days) == Convert.ToDateTime(task.date))
                {
                    todayTasks.Add(task);
                }
            }
            string message = mes;
            foreach (var contact in contacts)
            {
                List<Task> contactTasks = new List<Task>();
                foreach (var task in todayTasks)
                {
                    if (task.owner.Contains(contact.number) && task.owner.Contains(contact.first_name) && task.owner.Contains(contact.last_name))
                        contactTasks.Add(task);
                }
                if (contactTasks.Count > 0)
                {
                    message += contact.last_name + "\n";
                    foreach (var task in contactTasks)
                    {
                        message += task.theTask + "\n";
                    }
                    message += contact.number + "\n";
                    message += "\n";
                }
            }
            var bot = new TelegramBotClient("7946086349:AAHYLVwHJyAJkj3GOSL_LjcIMuTlzx8ZNnA");
            await bot.SendTextMessageAsync("801122040", message);
        }

        class Contact()
        {
            public string first_name;
            public string last_name;
            public string login;
            public string password;
            public string number;
        }
        List<Contact> contacts = new List<Contact>();
        public void loadTasks()
        {
            if (File.Exists("Tasks.txt"))
            {
                Task.tasks.Clear();
                listBox2.Items.Clear();
                StreamReader sr = File.OpenText("Tasks.txt");
                while (!sr.EndOfStream)
                {
                    Task task = new Task();
                    string[] task1 = sr.ReadLine().Split('~');
                    task.owner = task1[0];
                    task.date = task1[1];
                    task.theTask = task1[2];
                    Task.tasks.Add(task);
                    listBox2.Items.Add("Ответственный: " + task.owner + " Выполнить до: " + task.date + " Задача: " + task.theTask);
                }
                sr.Close();
            }
            else
                MessageBox.Show("Отсутствует файл с записанными задачами");
        }
        public void loadContacts()
        {
            if (File.Exists("Contacts.txt"))
            {
                contacts.Clear();
                listBox1.Items.Clear();
                StreamReader sr = File.OpenText("Contacts.txt");
                while (!sr.EndOfStream)
                {
                    Contact contact = new Contact();
                    string[] contact1 = sr.ReadLine().Split('~');
                    contact.first_name = contact1[0];
                    contact.last_name = contact1[1];
                    contact.login = contact1[2];
                    contact.password = contact1[3];
                    contact.number = contact1[4];
                    contacts.Add(contact);
                    listBox1.Items.Add($"{contact.first_name} {contact.last_name} | {contact.number}");
                }
                sr.Close();
            }
            else
                MessageBox.Show("Отсутствует файл с записанными контактами");
        }
        public void goOut(Panel panel, System.Windows.Forms.Button button)
        {
            if (panel.Visible == false && panel.Enabled == false)
            {
                panel.Visible = true;
                panel.Enabled = true;
                for (int i = 0; i < 11; i++)
                {
                    panel.Location = new Point(panel.Location.X + 15, button.Location.Y);
                    Thread.Sleep(25);
                }
            }
            else
            {
                for (int i = 0; i < 11; i++)
                {
                    panel.Location = new Point(panel.Location.X - 15, button.Location.Y);
                    Thread.Sleep(25);
                }
                panel.Visible = false;
                panel.Enabled = false;
            }
        }


        public Form1()
        {
            InitializeComponent();
            panel2.Visible = false;
            panel2.Enabled = false;
            panel3.Visible = false;
            panel3.Enabled = false;
            panel4.Visible = false;
            panel4.Enabled = false;
            panel5.Visible = false;
            panel5.Enabled = false;
            panel6.Visible = false;
            panel6.Enabled = false;
            panel8.Visible = false;
            panel8.Enabled = false;
            panel7.Visible = false;
            panel7.Enabled = false;
            monthCalendar1.Visible = false;
            monthCalendar1.Enabled = false;
            button10.Visible = false;
            button10.Enabled = false;
            panel9.Visible = false;
            panel9.Enabled = false;
            button11.Visible = false;
            button11.Enabled = false;
            loadContacts();
            loadTasks();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            goOut(panel2, button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadTasks();
            goOut(panel3, button2);
            if (panel8.Visible == false)
            {
                panel8.Visible = true;
                panel8.Enabled = true;
            }
            else
            {
                panel8.Visible = false;
                panel8.Enabled = false;
            }
            comboBox1.Items.Clear();
            foreach (var item in listBox1.Items)
            {
                comboBox1.Items.Add(item);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadContacts();
            goOut(panel4, button3);
            if (button11.Visible == false)
            {
                button11.Visible = true;
                button11.Enabled = true;
            }
            else
            {
                button11.Visible = false;
                button11.Enabled = false;
                panel9.Visible = false;
                panel9.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            goOut(panel6, button5);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel7.Visible = true;
            panel7.Enabled = true;
            button10.Visible = true;
            button10.Enabled = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
            monthCalendar1.Enabled = true;
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (button9.Text != "Выбрать дату")
                {
                    if (comboBox1.SelectedIndex != -1)
                    {
                        var bot = new TelegramBotClient("7946086349:AAHYLVwHJyAJkj3GOSL_LjcIMuTlzx8ZNnA");
                        await bot.SendTextMessageAsync("801122040", $"Ответственный: {comboBox1.SelectedItem}\nВыполнить до: {button9.Text}\nЗадача: {textBox1.Text}");
                        MessageBox.Show("Задача отправлена");

                        StreamWriter sw = File.AppendText("Tasks.txt");
                        sw.WriteLine($"{comboBox1.SelectedItem}~{button9.Text}~{textBox1.Text}");
                        sw.Close();

                        loadTasks();
                        panel7.Visible = false;
                        panel7.Enabled = false;
                        button10.Visible = false;
                        button10.Enabled = false;
                    }
                    else
                        MessageBox.Show("Выберите ответственного");
                }
                else
                    MessageBox.Show("Выберите дату, до какого числа требуется выполнить задачу");
            }
            else
                MessageBox.Show("Введите описание задачи");
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            button9.Text = monthCalendar1.SelectionStart.ToString();
            monthCalendar1.Visible = false;
            monthCalendar1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            goOut(panel5, button4);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel9.Visible = true;
            panel9.Enabled = true;
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
                {
                    foreach (var q in textBox2.Text)
                    {
                        if (char.IsDigit(q))
                        {
                            MessageBox.Show("Ввод цифр не допускается в имени");
                            return;
                        }
                    }
                    foreach (var q in textBox3.Text)
                    {
                        if (char.IsDigit(q))
                        {
                            MessageBox.Show("Ввод цифр не допускается в фамилии");
                            return;
                        }
                    }
                    StreamWriter sw = File.AppendText("Contacts.txt");
                    sw.WriteLine($"{textBox3.Text}~{textBox2.Text}~{textBox4.Text}~{textBox5.Text}~{textBox6.Text}");
                    sw.Close();

                    loadContacts();
                    panel9.Visible = false;
                    panel9.Enabled = false;
                }
                else
                    MessageBox.Show("Заполните все поля");
            }
            catch
            {
                MessageBox.Show("Какая-то ошибка");
            }
        }

        private async void button13_Click(object sender, EventArgs e)
        {
            sendNot("Задачи на сегодня:\n", 1);
            sendNot("Задачи на завтра:\n", 2);
            sendNot("Задачи на после завтра:\n", 3);
            MessageBox.Show("Уведомление отправлено");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
