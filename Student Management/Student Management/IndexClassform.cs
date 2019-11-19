using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Management
{
    public partial class IndexClassform : Form
    {
        private ClassManagement Business;
        public IndexClassform()
        {
            InitializeComponent();
            this.Business = new ClassManagement();
            this.Load += IndexClassform_Load;
            this.btnCreate.Click += btnCreate_Click;
            this.btndelete.Click += btndelete_Click;
            this.grdclasses.DoubleClick += grdclasses_DoubleClick;
        }

        void btnCreate_Click(object sender, EventArgs e)
        {
            var createForm = new CreateClassForm();
            createForm.ShowDialog();
            this.LoadAllClasses();
        }

        void grdclasses_DoubleClick(object sender, EventArgs e)
        {
            
        }

        void btndelete_Click(object sender, EventArgs e)
        {
            if (this.grdclasses.SelectedRows.Count == 1)
            {
                if(MessageBox.Show("Do you want to delete this?","Confirm",
                   MessageBoxButtons.YesNo)== System.Windows.Forms.DialogResult.Yes)
                {
                    var @class = (Class)this.grdclasses.SelectedRows[0].DataBoundItem;
                    this.Business.DeleteClass(@class.id);
                    MessageBox.Show("Delete class successfully.");
                    this.LoadAllClasses();
                }
            }
        }

        void IndexClassform_Load(object sender, EventArgs e)
        {
            
        }


        void grdClasses_DoubleClick(object sender, EventArgs e)
        {
            if(this.grdclasses.SelectedRows.Count == 1)
            {
                var @class = (Class)this.grdclasses.SelectedRows[0].DataBoundItem;

                var updateForm = new UpdateClassform(@class.id);
                updateForm.ShowDialog();
                this.LoadAllClasses();
            }
        }
        private void LoadAllClasses()
        {
            var classes = this.Business.GetClasses();
            this.grdclasses.DataSource = classes;
        }


    }
}