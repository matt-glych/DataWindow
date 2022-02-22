using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataWindow
{
    public partial class UsersView : Form, IUsersView
    {
        private Button btnAdd;
        private Button btnRemove;
        internal ListView gridUsers;


        public bool DisplayAdd;
        private GroupBox groupBox1;
        private Button btnRegister;
        private Label label2;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private Label label1;

        // controller
        UsersController _controller;



        public UsersView()
        {
            InitializeComponent();
                
            AddDetailsVisible(false);
        }

        // events sent to controller
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddDetailsVisible(true);
            _controller.AddNewUser();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _controller.RemoveUser();
            //AddDetailsVisible(false);
        }
        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            _controller.Save();
            AddDetailsVisible(false);

          

        }



        // form fields getters and setters
        public string FirstName
        {
            get { return txtFirstName.Text; }
            set { txtFirstName.Text = value; }
        }
        public string LastName
        {
            get { return txtLastName.Text; }
            set { txtLastName.Text = value; }
        }

        public void AddDetailsVisible(bool value)
        {
            groupBox1.Visible = value;
        }

        // add user to grid
        public void AddUserToGrid(User user)
        {
            ListViewItem parent;
            parent = gridUsers.Items.Add(user.ID);
            parent.SubItems.Add(user.FirstName);
            parent.SubItems.Add(user.LastName);
            parent.SubItems.Add(Enum.GetName(typeof(User.SexOfPerson), user.Sex));
        }
        // clear the grid
        public void ClearGrid()
        {
            // define columns in grid
            gridUsers.Columns.Clear();

            gridUsers.Columns.Add("Id", 150, HorizontalAlignment.Left);
            gridUsers.Columns.Add("First Name", 150, HorizontalAlignment.Left);
            gridUsers.Columns.Add("Lastst Name", 150, HorizontalAlignment.Left);
            gridUsers.Columns.Add("Sex", 50, HorizontalAlignment.Left);

            // Add rows to grid
            gridUsers.Items.Clear();
        }

        public string GetIdOfSelectedUserInGrid()
        {
            if (gridUsers.SelectedItems.Count > 0)
            {
                
                return this.gridUsers.SelectedItems[0].Text;
            }
                
            else
                return "";
        }

        public void RemoveUserFromGrid(User user)
        {
            ListViewItem rowToRemove = null;

            foreach (ListViewItem row in gridUsers.Items)
            {
                if(row.Text == user.ID)
                {
                    rowToRemove = row;
                }
            }

            if(rowToRemove != null)
            {
                gridUsers.Items.Remove(rowToRemove);
                gridUsers.Focus();
            }
        }

        public void SetController(UsersController controller)
        {
            _controller = controller;
        }

        public void SetSelectedUserInGrid(User user)
        {
            foreach (ListViewItem row in gridUsers.Items)
            {
                if (row.Text == user.ID)
                    row.Selected = true;
            }
        }

        public void UpdateGridWithChangedUser(User user)
        {
            ListViewItem rowToUpdate = null;

            foreach (ListViewItem row in gridUsers.Items)
            {
                if(row.Text == user.ID)
                {
                    rowToUpdate = row;
                }
            }

            if(rowToUpdate != null)
            {
                rowToUpdate.Text = user.ID;
                rowToUpdate.SubItems[1].Text = user.FirstName;
                rowToUpdate.SubItems[2].Text = user.LastName;
                rowToUpdate.SubItems[2].Text = Enum.GetName(typeof(User.SexOfPerson), user.Sex);
            }
        }


        private void InitializeComponent()
        {
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.gridUsers = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(443, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "New";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(443, 49);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // gridUsers
            // 
            this.gridUsers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridUsers.FullRowSelect = true;
            this.gridUsers.GridLines = true;
            this.gridUsers.HideSelection = false;
            this.gridUsers.Location = new System.Drawing.Point(0, 190);
            this.gridUsers.Name = "gridUsers";
            this.gridUsers.Size = new System.Drawing.Size(530, 285);
            this.gridUsers.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.gridUsers.TabIndex = 11;
            this.gridUsers.UseCompatibleStateImageBehavior = false;
            this.gridUsers.View = System.Windows.Forms.View.Details;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRegister);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtLastName);
            this.groupBox1.Controls.Add(this.txtFirstName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 172);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data:";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(6, 143);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 19;
            this.btnRegister.Text = "Save";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Last Name";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(6, 84);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(150, 20);
            this.txtLastName.TabIndex = 13;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(6, 40);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(150, 20);
            this.txtFirstName.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "First Name";
            // 
            // UsersView
            // 
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(530, 475);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gridUsers);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Name = "UsersView";
            this.Load += new System.EventHandler(this.UsersView_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void UsersView_Load(object sender, EventArgs e)
        {

        }
    }
}
