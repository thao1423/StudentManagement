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
    public partial class UpdateClassform : Form
    {
        private int CLassId;
        private ClassManagement Business;
        public UpdateClassform(int id)
        {
            InitializeComponent();
            this.CLassId = id;
            this.Business = new ClassManagement();
            this.btnSave.Click += btnSave_Click;
            this.btnCancel.Click += btnCancel_Click;
            this.Load += UpdateClassform_Load;
        }

        void UpdateClassform_Load(object sender, EventArgs e)
        {
            var oldClass = this.Business.GetClass(this.CLassId);
            this.txtName.Text = oldClass.Name;
            this.txtDescription.Text = oldClass.Description;
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            var name = this.txtName.Text;
            var descript = this.txtDescription.Text;
            this.Business.Editclass(this.CLassId, name, description);
            MessageBox.Show("Update class successfully.");
        }
    }
}
