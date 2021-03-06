﻿using DataAccess;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Models;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace StoreAutomationUI
{
    public partial class admin : MetroForm
    {
        public admin()
        {
            InitializeComponent();
            attributePanel.Dock = DockStyle.Fill;
            attributesetPanel.Dock = DockStyle.Fill;
            attributevaluePanel.Dock = DockStyle.Fill;
            provincePanel.Dock = DockStyle.Fill;
            districtPanel.Dock = DockStyle.Fill;
            employeePanel.Dock = DockStyle.Fill;
            departmentPanel.Dock = DockStyle.Fill;
            activityPanel.Dock = DockStyle.Fill;

            MetroPanel[] pa = new MetroPanel[8];
            pa[0] = attributePanel;
            pa[1] = attributesetPanel;
            pa[2] = attributevaluePanel;
            pa[3] = provincePanel;
            pa[4] = districtPanel;
            pa[5] = employeePanel;
            pa[6] = departmentPanel;
            pa[7] = activityPanel;

            foreach (MetroPanel myp in pa)
            {
                myp.BackColor = Color.White;
            }
            adminpanel();
        }

        private void admin_Load(object sender, EventArgs e)
        {

        }
        //=============================================================
        //======================= ATTRİBUTE ===========================
        //=============================================================
        private void metroTile7_Click(object sender, EventArgs e)
        {
            adminpanel();


        }

        private void adminpanel()
        {
            panelControl(0);

            string tableName = "attribute";



            string query = Queries.attribute2;
            DataSet ds = DbCommand.getDataSet(query, tableName);

            if (ds != null)
                attributeGrid.DataSource = ds.Tables[tableName];
            //attributeGrid.Columns[0].Width = 30;

        }

        //=============================================================
        //======================= ATTRIBUTE SET =======================
        //=============================================================
        private void metroTile8_Click(object sender, EventArgs e)
        {
            panelControl(1);
            string tableName = "attributeSet";

            attributeSetAttributesGrid.DataSource = null;

            string query = Queries.attributeSet2;
            DataSet ds = DbCommand.getDataSet(query, tableName);

            if (ds != null)
                attributesetGrid.DataSource = ds.Tables[tableName];

            attributesetGrid.Columns[0].Width = 30;
        }
        //=============================================================
        //======================= ATTRIBUTE VALUE =====================
        //=============================================================
        private void metroTile9_Click(object sender, EventArgs e)
        {
            panelControl(2);

            string tableName = "products";
            metroGrid4.DataSource = null;

            string query = Queries.attributeValues2;
            DataSet ds = DbCommand.getDataSet(query, tableName);

            if (ds != null)
                attributeValueGrid.DataSource = ds.Tables[tableName];

            attributeValueGrid.Columns[0].Width = 30;


        }
        //=============================================================
        //======================= PROVINCE ============================
        //=============================================================
        private void metroTile10_Click(object sender, EventArgs e)
        {
            panelControl(3);

            string tableName = "province";



            string query = Queries.province;
            DataSet ds = DbCommand.getDataSet(query, tableName);

            if (ds != null)
                provinceGrid.DataSource = ds.Tables[tableName];

            provinceGrid.Columns[0].Width = 30;
        }
        //=============================================================
        //======================= DISTRICT ============================
        //=============================================================
        private void metroTile11_Click(object sender, EventArgs e)
        {
            panelControl(4);
            string tableName = "district";
            metroGrid6.DataSource = null;

            string query = Queries.province;
            DataSet ds = DbCommand.getDataSet(query, tableName);

            if (ds != null)
                districtGrid.DataSource = ds.Tables[tableName];

            districtGrid.Columns[0].Width = 30;

        }
        //=============================================================
        //======================= EMPLOYEE ============================
        //=============================================================
        private void metroTile12_Click(object sender, EventArgs e)
        {
            panelControl(5);

            string tableName = "employee";


            string query = Queries.employee2;
            DataSet ds = DbCommand.getDataSet(query, tableName);

            if (ds != null)
                employeeGrid.DataSource = ds.Tables[tableName];

            employeeGrid.Columns[0].Width = 30;

        }
        //=============================================================
        //======================= DEPARTMENT ==========================
        //=============================================================
        private void metroTile13_Click(object sender, EventArgs e)
        {
            panelControl(6);

            string tableName = "department";


            string query = Queries.department;
            DataSet ds = DbCommand.getDataSet(query, tableName);

            if (ds != null)
                departmentGrid.DataSource = ds.Tables[tableName];

            departmentGrid.Columns[0].Width = 30;
        }

        void panelControl(int p)
        {
            bool[] panels = new bool[8];
            for (int i = 0; i < 8; i++)
                if (i == p)
                    panels[i] = true;
                else panels[i] = false;

            attributePanel.Visible = panels[0];
            attributesetPanel.Visible = panels[1];
            attributevaluePanel.Visible = panels[2];
            provincePanel.Visible = panels[3];
            districtPanel.Visible = panels[4];
            employeePanel.Visible = panels[5];
            departmentPanel.Visible = panels[6];
            activityPanel.Visible = panels[7];


        }

        private void btnAddAttributeset_Click(object sender, EventArgs e)
        {
            add_attributeset add = new add_attributeset();
            add.ShowDialog();
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {

            AttributeSetModel.id = attributesetGrid.Rows[attributesetGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
            AttributeSetModel.name = attributesetGrid.Rows[attributesetGrid.SelectedRows[0].Index].Cells[1].Value.ToString();

            add_attributeset update = new add_attributeset(true);
            update.ShowDialog();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            add_attribute add = new add_attribute();
            add.ShowDialog();

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            Models.AttributeModel.id = attributeGrid.Rows[attributeGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
            Models.AttributeModel.name = attributeGrid.Rows[attributeGrid.SelectedRows[0].Index].Cells[1].Value.ToString();

            add_attribute update = new add_attribute(true);
            update.ShowDialog();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            add_province add = new add_province();
            add.ShowDialog();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            ProvinceModel.id = provinceGrid.Rows[provinceGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
            ProvinceModel.name = provinceGrid.Rows[provinceGrid.SelectedRows[0].Index].Cells[1].Value.ToString();

            add_province update = new add_province(true);
            update.ShowDialog();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            add_attributeValue add = new add_attributeValue();
            add.ShowDialog();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            if (metroGrid4.Rows.Count != 0)
            {
                AttributeValueModel.id = metroGrid4.Rows[metroGrid4.SelectedRows[0].Index].Cells[0].Value.ToString();
                AttributeValueModel.name = metroGrid4.Rows[metroGrid4.SelectedRows[0].Index].Cells[1].Value.ToString();
                AttributeValueModel.attribute = attributeValueGrid.Rows[attributeValueGrid.SelectedRows[0].Index].Cells[1].Value.ToString();

                add_attributeValue update = new add_attributeValue(true);
                update.ShowDialog();
            }
            else
            {
                MetroMessageBox.Show(this, "You need to add a value first", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void attributeValueGrid_MouseClick(object sender, MouseEventArgs e)
        {
            string tableName = "attributes";

            string pro_ID = attributeValueGrid.Rows[attributeValueGrid.SelectedRows[0].Index].Cells[0].Value.ToString();

            string query = string.Format(Queries.attributevalueId, pro_ID);
            DataSet ds = DbCommand.getDataSet(query, tableName);

            if (ds != null)
                metroGrid4.DataSource = ds.Tables[tableName];

        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            add_department add = new add_department();
            add.ShowDialog();
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            DepartmentModel.id = departmentGrid.Rows[departmentGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
            DepartmentModel.name = departmentGrid.Rows[departmentGrid.SelectedRows[0].Index].Cells[1].Value.ToString();
            add_department update = new add_department(true);
            update.ShowDialog();
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            string tableName = "departmentLike";

            string dep_name = metroTextBox5.Text;

            string query = string.Format(Queries.departmentLike, dep_name);
            DataSet ds = DbCommand.getDataSet(query, tableName);

            if (ds != null)
                departmentGrid.DataSource = ds.Tables[tableName];
        }

        private void metroButton10_Click(object sender, EventArgs e)
        {

            string tableName = "attributeVLike";

            string att_name = metroTextBox4.Text;
            string att_ID = attributeValueGrid.Rows[attributeValueGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
            string query = string.Format(Queries.attributeValueLike2, att_name, att_ID);
            DataSet ds = DbCommand.getDataSet(query, tableName);

            if (ds != null)
                metroGrid4.DataSource = ds.Tables[tableName];
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            string tableName = "provinceLike";

            string pro_name = metroTextBox3.Text;

            string query = string.Format(Queries.provinceLike, pro_name);
            DataSet ds = DbCommand.getDataSet(query, tableName);

            if (ds != null)
                provinceGrid.DataSource = ds.Tables[tableName];
        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            string tableName = "attributeLike";

            string att_name = metroTextBox2.Text;

            string query = string.Format(Queries.attributeLike, att_name);
            DataSet ds = DbCommand.getDataSet(query, tableName);

            if (ds != null)
                attributeGrid.DataSource = ds.Tables[tableName];
            attributeGrid.Columns[0].Width = 30;

        }

        private void metroButton13_Click(object sender, EventArgs e)
        {
            string tableName = "attributeSetLike";

            string attS_name = metroTextBox1.Text;

            string query = string.Format(Queries.attributeSetLike, attS_name);
            DataSet ds = DbCommand.getDataSet(query, tableName);

            if (ds != null)
                attributesetGrid.DataSource = ds.Tables[tableName];
        }

        private void districtGrid_MouseClick(object sender, MouseEventArgs e)
        {
            string tableName = "district";

            string dis_ID = districtGrid.Rows[districtGrid.SelectedRows[0].Index].Cells[0].Value.ToString();

            string query = string.Format(Queries.districtId, dis_ID);
            DataSet ds = DbCommand.getDataSet(query, tableName);

            if (ds != null)
                metroGrid6.DataSource = ds.Tables[tableName];
        }

        private void metroButton16_Click(object sender, EventArgs e)
        {
            add_district add = new add_district();
            add.ShowDialog();
        }

        private void metroButton15_Click(object sender, EventArgs e)
        {
            if (metroGrid6.Rows.Count != 0)
            {
                DistrictModel.id = metroGrid6.Rows[metroGrid6.SelectedRows[0].Index].Cells[0].Value.ToString();
                DistrictModel.name = metroGrid6.Rows[metroGrid6.SelectedRows[0].Index].Cells[1].Value.ToString();
                DistrictModel.province = districtGrid.Rows[districtGrid.SelectedRows[0].Index].Cells[1].Value.ToString();

                add_district update = new add_district(true);
                update.ShowDialog();
            }
            else if (metroGrid6 != null)
            {
                MetroMessageBox.Show(this, "You need to select a district first", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MetroMessageBox.Show(this, "You need to add a district first", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void metroButton14_Click(object sender, EventArgs e)
        {
            string tableName = "districtLike";

            string dis_name = metroTextBox6.Text;
            string dis_ID = districtGrid.Rows[districtGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
            string query = string.Format(Queries.districtLike, dis_name, dis_ID);
            DataSet ds = DbCommand.getDataSet(query, tableName);

            if (ds != null)
                metroGrid6.DataSource = ds.Tables[tableName];
        }

        private void metroButton19_Click(object sender, EventArgs e)
        {
            add_employee add = new add_employee();
            add.ShowDialog();
        }

        private void metroButton18_Click(object sender, EventArgs e)
        {
            EmployeeModel.id = employeeGrid.Rows[employeeGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
            EmployeeModel.name = employeeGrid.Rows[employeeGrid.SelectedRows[0].Index].Cells[1].Value.ToString();
            EmployeeModel.lastName = employeeGrid.Rows[employeeGrid.SelectedRows[0].Index].Cells[2].Value.ToString();
            EmployeeModel.tc = employeeGrid.Rows[employeeGrid.SelectedRows[0].Index].Cells[3].Value.ToString();
            EmployeeModel.tel = employeeGrid.Rows[employeeGrid.SelectedRows[0].Index].Cells[4].Value.ToString();
            EmployeeModel.adress = employeeGrid.Rows[employeeGrid.SelectedRows[0].Index].Cells[5].Value.ToString();
            EmployeeModel.district = employeeGrid.Rows[employeeGrid.SelectedRows[0].Index].Cells[6].Value.ToString();
            EmployeeModel.provice = employeeGrid.Rows[employeeGrid.SelectedRows[0].Index].Cells[7].Value.ToString();
            EmployeeModel.department = employeeGrid.Rows[employeeGrid.SelectedRows[0].Index].Cells[8].Value.ToString();
            EmployeeModel.salary = employeeGrid.Rows[employeeGrid.SelectedRows[0].Index].Cells[9].Value.ToString();
            add_employee update = new add_employee(true);
            update.ShowDialog();
        }

        private void metroButton17_Click(object sender, EventArgs e)
        {
            string tableName = "employeeLike";

            string emp_name = metroTextBox7.Text;

            string query = string.Format(Queries.employeeLike, emp_name);
            DataSet ds = DbCommand.getDataSet(query, tableName);

            if (ds != null)
                employeeGrid.DataSource = ds.Tables[tableName];
        }

        private void activityTile_Click(object sender, EventArgs e)
        {
            panelControl(7);

            string tableName = "activity";
            metroGrid4.DataSource = null;

            string query = Queries.activityType;
            DataSet ds = DbCommand.getDataSet(query, tableName);

            if (ds != null)
                activityGrid.DataSource = ds.Tables[tableName];

            activityGrid.Columns[0].Width = 30;
        }

        private void activityGrid_MouseClick(object sender, MouseEventArgs e)
        {
            string tableName = "activity";

            string act_ID = activityGrid.Rows[activityGrid.SelectedRows[0].Index].Cells[0].Value.ToString();

            string query = string.Format(Queries.activityId, act_ID);
            DataSet ds = DbCommand.getDataSet(query, tableName);

            if (ds != null)
                metroGrid8.DataSource = ds.Tables[tableName];
        }

        private void metroButton22_Click(object sender, EventArgs e)
        {
            add_activity add = new add_activity();
            add.ShowDialog();
        }

        private void metroButton21_Click(object sender, EventArgs e)
        {
            activity.id = metroGrid8.Rows[metroGrid8.SelectedRows[0].Index].Cells[0].Value.ToString();
            activity.name = metroGrid8.Rows[metroGrid8.SelectedRows[0].Index].Cells[1].Value.ToString();
            activity.activityType = activityGrid.Rows[activityGrid.SelectedRows[0].Index].Cells[1].Value.ToString();

            add_activity update = new add_activity(true);
            update.ShowDialog();
        }

        private void metroButton20_Click(object sender, EventArgs e)
        {
            string tableName = "activityLike";

            string act_name = metroTextBox8.Text;
            string actType_ID = activityGrid.Rows[activityGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
            string query = string.Format(Queries.activityLike, act_name, actType_ID);
            DataSet ds = DbCommand.getDataSet(query, tableName);

            if (ds != null)
                metroGrid8.DataSource = ds.Tables[tableName];
        }

        private void metroButton23_Click(object sender, EventArgs e)
        {
            DialogResult dr = MetroMessageBox.Show(this, "are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (dr == DialogResult.Yes)
            {
                AttributeSetModel.id = attributesetGrid.Rows[attributesetGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
                string query = string.Format(Queries.delAttributeSet_attribute, AttributeSetModel.id);

                DbCommand.insertIntoDb(query);

                query = string.Format(Queries.delAttributeSet, AttributeSetModel.id);

                DbCommand.insertIntoDb(query);
            }
        }

        private void metroButton24_Click(object sender, EventArgs e)
        {
            DialogResult dr = MetroMessageBox.Show(this, "are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (dr == DialogResult.Yes)
            {
                Models.AttributeModel.id = attributeGrid.Rows[attributeGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
                string query = string.Format(Queries.delAttributeSet_attribute2, Models.AttributeModel.id);

                DbCommand.insertIntoDb(query);
                query = string.Format(Queries.delAttributeValue2, Models.AttributeModel.id);

                DbCommand.insertIntoDb(query);
                query = string.Format(Queries.delAttribute, Models.AttributeModel.id);

                DbCommand.insertIntoDb(query);
            }
        }

        private void metroButton25_Click(object sender, EventArgs e)
        {
            DialogResult dr = MetroMessageBox.Show(this, "are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (dr == DialogResult.Yes)
            {
                AttributeValueModel.id = metroGrid4.Rows[metroGrid4.SelectedRows[0].Index].Cells[0].Value.ToString();
                string query = string.Format(Queries.delAttributeValue2, AttributeValueModel.id);

                DbCommand.insertIntoDb(query);
            }
        }

        private void metroButton26_Click(object sender, EventArgs e)
        {
            DialogResult dr = MetroMessageBox.Show(this, "are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (dr == DialogResult.Yes)
            {
                ProvinceModel.id = provinceGrid.Rows[provinceGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
                string query = string.Format(Queries.delDistrict2, ProvinceModel.id);

                DbCommand.insertIntoDb(query);

                query = string.Format(Queries.delProvince, ProvinceModel.id);

                DbCommand.insertIntoDb(query);


            }
        }

        private void metroButton27_Click(object sender, EventArgs e)
        {
            DialogResult dr = MetroMessageBox.Show(this, "are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (dr == DialogResult.Yes)
            {
                DistrictModel.id = metroGrid6.Rows[metroGrid6.SelectedRows[0].Index].Cells[0].Value.ToString();
                string query = string.Format(Queries.delDistrict, DistrictModel.id);

                DbCommand.insertIntoDb(query);
            }
        }

        private void metroButton28_Click(object sender, EventArgs e)
        {
            DialogResult dr = MetroMessageBox.Show(this, "are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (dr == DialogResult.Yes)
            {
                EmployeeModel.id = employeeGrid.Rows[employeeGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
                string query = string.Format(Queries.delEmployee, EmployeeModel.id);

                DbCommand.insertIntoDb(query);
            }
        }

        private void metroButton29_Click(object sender, EventArgs e)
        {
            DialogResult dr = MetroMessageBox.Show(this, "are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (dr == DialogResult.Yes)
            {
                DepartmentModel.id = departmentGrid.Rows[departmentGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
                string query = string.Format(Queries.delDepartment, DepartmentModel.id);

                DbCommand.insertIntoDb(query);
            }
        }

        private void metroButton30_Click(object sender, EventArgs e)
        {
            DialogResult dr = MetroMessageBox.Show(this, "are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (dr == DialogResult.Yes)
            {
                activity.id = metroGrid8.Rows[metroGrid8.SelectedRows[0].Index].Cells[0].Value.ToString();
                string query = string.Format(Queries.delActivity, activity.id);

                DbCommand.insertIntoDb(query);
            }
        }

        private void admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginForm l = new loginForm();
            l.Show();
        }

        private void attributesetGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (attributesetGrid.SelectedRows.Count != 0)
            {
                string tableName = "attributeSetAttributes";


                string set_ID = attributesetGrid.Rows[attributesetGrid.SelectedRows[0].Index].Cells[0].Value.ToString();
                string query = string.Format(Queries.attributeSetAttributes, set_ID);
                DataSet ds = DbCommand.getDataSet(query, tableName);
                //
                //Gelen veriler metroGrid2'ye aktardı
                if (ds != null)
                    attributeSetAttributesGrid.DataSource = ds.Tables[tableName];
            }
        }

        private void activityPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void attributevaluePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void districtGrid_SelectionChanged(object sender, EventArgs e)
        {
            /*if(districtGrid.Rows.Count != 0)
            {
                string tableName = "district";

                string dis_ID = districtGrid.Rows[districtGrid.SelectedRows[0].Index].Cells[0].Value.ToString();

                string query = String.Format(Queries.districtId, dis_ID);
                DataSet ds = DbCommand.getDataSet(query, tableName);

                if (ds != null)
                    metroGrid6.DataSource = ds.Tables[tableName];
            }*/

        }
    }
}
