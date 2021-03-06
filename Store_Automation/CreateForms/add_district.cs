﻿using DataAccess;
using MetroFramework.Forms;
using Models;
using System;
using System.Data;

namespace StoreAutomationUI
{
    public partial class add_district : MetroForm
    {
        bool update;

        public add_district()
        {
            InitializeComponent();
        }
        public add_district(bool u)
        {
            InitializeComponent();
            update = u;
        }

        private void add_district_Load(object sender, EventArgs e)
        {
            string tableName = "province";

            DataSet ds = DbCommand.getDataSet(Queries.province, tableName);

            if (ds != null)
            {
                provinceList.DisplayMember = "Name";
                provinceList.ValueMember = "ID";
                provinceList.DataSource = ds.Tables[tableName];
                provinceList.SelectedItem = null;
                provinceList.PromptText = "Choose from the list";
            }
            if (!update)
            {
                string idName = "id";

                string idQuery = string.Format(Queries.newID, "district_ID", "district");
                DataSet idDs = DbCommand.getDataSet(idQuery, idName);


                try
                {
                    id.Text = ((int)(idDs.Tables[idName].Rows[0]["max(district_ID)"]) + 1).ToString();
                }
                catch (Exception)
                {
                    id.Text = "1";
                }


            }
            else
            {
                id.Text = DistrictModel.id;
                id.Enabled = false;
                name.Text = DistrictModel.name;
                provinceList.Text = DistrictModel.province;

                metroButton1.Text = "Update";
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string Id = id.Text;
            string Name = name.Text;
            string provinceId = provinceList.SelectedValue.ToString();
            if (!update)
            {
                string query = string.Format(Queries.insDistrict, Id, Name, provinceId);
                DbCommand.insertIntoDb(query);
            }
            else
            {

                string query = string.Format(Queries.upDistrict, Name, provinceId, Id);
                DbCommand.insertIntoDb(query);
            }
            this.Close();
        }
    }
}
