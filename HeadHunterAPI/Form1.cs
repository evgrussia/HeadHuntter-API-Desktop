using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HHLibrary;

namespace HeadHunterAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        HHModel model = new HHModel();

        private void SearchButton_Click(object sender, EventArgs e)
        {
            
            List<Vacancy> vacancies = model.JsonParceString(model.RequestGet("https://api.hh.ru/vacancies?text="+SearchBox.Text));
            DataJson.Rows.Clear();
            label1.Text = vacancies.Count()+" вакансий всего";
            foreach (Vacancy v in vacancies)
            {
                DataGridViewRow row = (DataGridViewRow)DataJson.Rows[0].Clone();
                row.Cells[0].Value = v.Area;
                row.Cells[1].Value = v.Name;
                row.Cells[2].Value = v.SalaryFrom;
                row.Cells[3].Value = v.SalaryTo;
                row.Cells[4].Value = v.EmployerName;
                row.Cells[5].Value = v.AddressStreet;
                row.Cells[6].Value = v.Info;
                DataJson.Rows.Add(row);
            }
        }
    }
}
