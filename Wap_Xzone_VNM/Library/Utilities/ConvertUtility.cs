using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace WapXzone_VNM.Library.Utilities
{
    public class ConvertUtility
    {
        public static string FormatTimeVn(DateTime dt, string defaultText)
        {
            if (ToDateTime(dt) != new DateTime(1900, 1, 1))
                return dt.ToString("dd-mm-yy");
            else
                return defaultText;
        }
        public static double ToDouble1(string obj)
        {
            double retVal;
            try
            {
                obj = obj.Replace(",", "").Replace(".", ",").Replace(" ", "");

                retVal = Convert.ToDouble(obj);
            }
            catch
            {
                retVal = 0;
            }

            return retVal;
        }
        public static int ToInt32(object obj)
        {
            int retVal = 0;

            try
            {
                retVal = Convert.ToInt32(obj);
            }
            catch
            {
                retVal = 0;
            }

            return retVal;
        }

        public static decimal ToDecimal(object obj)
        {
            decimal retVal = 0;

            try
            {
                retVal = Convert.ToDecimal(obj);
            }
            catch
            {
                retVal = 0;
            }

            return retVal;
        }

        public static int ToInt32(object obj, int defaultValue)
        {
            int retVal = defaultValue;

            try
            {
                retVal = Convert.ToInt32(obj);
            }
            catch
            {
                retVal = defaultValue;
            }

            return retVal;
        }

        public static string ToString(object obj)
        {
            string retVal;

            try
            {
                retVal = Convert.ToString(obj);
            }
            catch
            {
                retVal = String.Empty;
            }

            return retVal;
        }

        public static DateTime ToDateTime(object obj)
        {
            DateTime retVal;
            try
            {
                retVal = Convert.ToDateTime(obj);
            }
            catch
            {
                retVal = DateTime.Now;
            }
            if (retVal == new DateTime(1, 1, 1)) return DateTime.Now;

            return retVal;
        }

        public static DateTime ToDateTime(object obj, DateTime defaultValue)
        {
            DateTime retVal;
            try
            {
                retVal = Convert.ToDateTime(obj);
            }
            catch
            {
                retVal = DateTime.Now;
            }
            if (retVal == new DateTime(1, 1, 1)) return defaultValue;

            return retVal;
        }

        public static bool ToBoolean(object obj)
        {
            bool retVal;

            try
            {
                retVal = Convert.ToBoolean(obj);
            }
            catch
            {
                retVal = false;
            }

            return retVal;
        }

        public static double ToDouble(object obj)
        {
            double retVal;

            try
            {
                retVal = Convert.ToDouble(obj);
            }
            catch
            {
                retVal = 0;
            }

            return retVal;
        }

        public static double ToDouble(object obj, double defaultValue)
        {
            double retVal;

            try
            {
                retVal = Convert.ToDouble(obj);
            }
            catch
            {
                retVal = defaultValue;
            }

            return retVal;
        }


        public static DataSet SplitDataTable(DataTable dt, int noOfRowsInTable)
        {
            DataSet ds = new DataSet();
            try
            {
                ds.Tables.Add(dt.Clone());
                ds.Tables[0].TableName = "FirstSet";
                ds.Tables.Add(dt.Clone());
                ds.Tables[1].TableName = "SecondSet";

                if (dt.Rows.Count >= noOfRowsInTable)
                {
                    for (int i = 0; i < noOfRowsInTable; i++)
                    {
                        DataRow dr = ds.Tables[0].NewRow();
                        for (int k = 0; k < dt.Columns.Count; k++)
                        {
                            dr[k] = dt.Rows[i][k];
                        }
                        ds.Tables[0].Rows.Add(dr);
                    }
                    for (int j = noOfRowsInTable; j < dt.Rows.Count; j++)
                    {
                        DataRow dr1 = ds.Tables[1].NewRow();
                        for (int l = 0; l < dt.Columns.Count; l++)
                        {
                            dr1[l] = dt.Rows[j][l];
                        }
                        ds.Tables[1].Rows.Add(dr1);
                    }
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = ds.Tables[0].NewRow();
                        for (int k = 0; k < dt.Columns.Count; k++)
                        {
                            dr[k] = dt.Rows[i][k];
                        }
                        ds.Tables[0].Rows.Add(dr);
                    }
                }
                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }

        }

    }
}
