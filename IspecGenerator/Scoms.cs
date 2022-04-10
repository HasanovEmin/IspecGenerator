using Aveva.Core.Database;
using Aveva.Core.Database.Filters;
using System;
using System.Collections.Generic;

namespace IspecGenerator
{
    class Scoms
    {
        public Dictionary<double, DbElement> scomsAndValue { get; set; }
        private DbElement ceCateImport { get; set; }
        private string CeIspecImport { get; set; }
        private DbElement Scom { get; set; }
        public DbElement Spco { get; set; }
        private double Key { get; set; }
        public double Ans { get;  set; }
        public double Maxans { get;  set; }

        private List<double> doubleValue;
        public DbDouble bore;

        public Scoms(DbElement cateName, string ceIspecImport)
        {
            scomsAndValue = new Dictionary<double, DbElement>();
            ceCateImport = cateName;
            CeIspecImport = ceIspecImport;
            doubleValue = new List<double>();


            CollectScoms();
        }



        public void CollectScoms()
        {
            TypeFilter filter = new TypeFilter(DbElementType.GetElementType("SCOM"));

            try
            {
                DBElementCollection scoms = new DBElementCollection(ceCateImport, filter);

                foreach (DbElement item in scoms)
                {
                    double[] para = item.GetDoubleArray(DbAttributeInstance.PARA);
                    double para1 = para[0] / 2;
                    scomsAndValue.Add(para1, item);
                }
            }
            catch (Exception)
            {

            }

            foreach (var item in scomsAndValue)
            {
                string name = item.Value.GetAsString(DbAttributeInstance.NAME);
                
            }
        }


        public DbElement GenerateNewScom()
        {


            DbElement newScom = null;
            string spcoName = string.Empty;
            

            newScom = ceCateImport.CreateLast(DbElementType.GetElementType("SCOM"));
            string name = $"{ceCateImport.GetAsString(DbAttributeInstance.NAME)}-{Key}";
            newScom.SetAttribute(DbAttributeInstance.NAME, name);
            newScom.SetAttribute(DbAttributeInstance.PARA, doubleValue.ToArray());
            scomsAndValue.Add(Key, newScom);

            return newScom;



        }

        public void isScomAvailableMethod(double value, List<double> doubleValue)
        {
            Key = value;
            this.doubleValue = doubleValue;
            
            bool founded = scomsAndValue.TryGetValue(Key, out DbElement scom);
            
            if (founded)
            {
                Scom = scom;
                FillSpco(Scom);
            }
            else
            {
                Scom = GenerateNewScom();
                FillSpco(Scom);
            }

        }

        private void FillSpco(DbElement scom)
        {
            Spco.SetAttribute(DbAttributeInstance.CATR, scom);
            string spcoName = $"{CeIspecImport}/{Ans}-{Maxans}degC_{Key}-{bore}";
            Spco.SetAttribute(DbAttributeInstance.NAME, spcoName);

            
        }
    }
}
