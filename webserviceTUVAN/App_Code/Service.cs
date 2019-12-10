using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Web;
using TUVAN;
// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{

    TUVAN.thuattoanC4 c45;
    TUVAN.Attribute attr_SoThich = new TUVAN.Attribute("SoThich", new string[] { "Lướt web", "Chơi game", "Nghe nhac", "Chụp ảnh và quay video" }, "sothich", "Sở Thích");
    TUVAN.Attribute attr_GioiTinh = new TUVAN.Attribute("GioiTinh", new string[] { "Nam", "Nữ" }, "gioitinh", "Giới Tính");
    TUVAN.Attribute attr_Tuoi = new TUVAN.Attribute("Tuoi", new string[] { "Trẻ", "Trung niên", "Già" }, "tuoi", "Tuổi");
    TUVAN.Attribute attr_ThuNhap = new TUVAN.Attribute("Thunhap", new string[] { "Cao", "Trung bình", "Thấp" }, "Thunhap", "Thu nhập");


    public TUVAN.Attribute[] attributes;
    DataTable tb_Mau;
    string connectionString = "";
    OleDbCommand cmd = null;
    OleDbConnection objCon = null;
    OleDbDataAdapter objDA = null;

    public DataTable getdata()
    {
        String path = AppDomain.CurrentDomain.BaseDirectory;
       
        DataTable objDTExcel = new DataTable();
        string szConStr = collect_Con(System.IO.Path.GetExtension(path + @"\App_Data\DATASET.xls"), path + @"\App_Data\DATASET.xls");
        try
        {
            objCon = new OleDbConnection(szConStr);
            objCon.Open();
            objDA = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", objCon);
            objDA.Fill(objDTExcel);
        }
        catch (Exception ex)
        {
            
        }
        finally
        {
            if (objDA != null)
            {
                objDA.Dispose();
                objDA = null;
            }

            if (objCon != null)
            {
                objCon.Close();
                objCon.Dispose();
                objCon = null;
            }
        }

        return objDTExcel;
    }
    public string collect_Con(string szFileExtension, string szPath)
    {

        switch (szFileExtension.ToUpper())
        {
            case ".XLS":
                connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + szPath + ";Extended Properties=\"Excel 8.0;HDR=YES;\"";
                break;
            case ".XLSX":
                connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=
                                        " + szPath + ";Extended Properties=\"Excel 12.0;HDR=YES;\"";
                break;
            default:
                break;
        }

        return connectionString;

    }


    DataTable tbTree, tb_CTDT;
    bool flat;
    int countSubject;
    String xeploai;
    Data_Access.common db;
    public DataSet CreateTree(){
        attributes = new TUVAN.Attribute[] { attr_GioiTinh, attr_SoThich, attr_ThuNhap, attr_Tuoi };
         tb_Mau = getdata();
         c45 = new thuattoanC4(tb_Mau, attributes);
         DataSet ds = new DataSet();
         ds.Tables.Add(c45.CreateTree());
        return ds;
    }

    public DataTable getTableTree()
    {
        DataTable tb = new DataTable();
        String path = AppDomain.CurrentDomain.BaseDirectory;
        tb.ReadXml(path + @"\App_Data\tree.xml");
        return tb;
    }
    String infor;
    String danhsachmasp;
    public String getConsultingResults(string infor)
    {
       
        this.infor = infor;
         tbTree = getTableTree();


        tbTree.DefaultView.RowFilter = "Parent_ID=1";
        DataTable tb = tbTree.DefaultView.ToTable();
        foreach (DataRow rowParent in tb.Rows)
        {
            
            danhsachmasp = rowParent["MaSP"].ToString()+",";
            String Parent_ID = rowParent["ID"].ToString();
            Dequy(Parent_ID);
            if (flag)
                break;
        }

        return danhsachmasp;
           }
    bool flag = false;
    public void Dequy(String Parent_ID)
    {
        try{
            tbTree.DefaultView.RowFilter = "Parent_ID=" + Parent_ID;
            DataTable tb = tbTree.DefaultView.ToTable();
            if (tb.Rows.Count == 1)
                if (tb.Rows[0]["TinhHieuQua"].ToString().Equals("Có"))
                {
                    danhsachmasp += tb.Rows[0]["MaSP"].ToString();
                    flag = true;
                }
                else if (tb.Rows[0]["TinhHieuQua"].ToString().Equals("Không"))
                    danhsachmasp = "";
            foreach (DataRow rowChild in tb.Rows)
            {
                if (this.infor.IndexOf(rowChild["SoThich"].ToString())>0 || this.infor.IndexOf(rowChild["GioiTinh"].ToString()) > 0|| this.infor.IndexOf(rowChild["Tuoi"].ToString()) > 0|| this.infor.IndexOf(rowChild["Thunhap"].ToString()) > 0)
                danhsachmasp += rowChild["MaSP"].ToString() + ",";
                if (rowChild["TinhHieuQua"].ToString().Equals("Có"))
                    return;
                //else
                //   //if(rowChild["TinhHieuQua"].ToString().Equals("Không"))
                //   //     danhsachmasp = "";
                String Child_ID = rowChild["ID"].ToString();
                Dequy(Child_ID);
            }
        }
        catch (Exception ex) { }
       
    }
   
	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}
}
