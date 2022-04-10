using Aveva.Core.Database;
using System;
using System.Windows.Forms;

namespace IspecGenerator
{
    internal class Spec
    {
        private DbElement NewSpec { get; set; }
        public string CeIspecImport { get; }
        public DbElement DbTextElement { get; set; }
        public DbElement MainSele { get; private set; }
        public DbElement Sele { get; private set; }
        public DbElement Spco { get; private set; }

        public Spec(string ceIspecImport)
        {
            CeIspecImport = ceIspecImport;
            NewSpec = null;
            DbTextElement = null;
            MainSele = null;
            Sele = null;
            Spco = null;
        }

        

        internal bool TryToCreateSpec()
        {
            DbElement ce = CurrentElement.Element;
            
            try
            {
                NewSpec = ce.CreateFirst(DbElementType.GetElementType("SPEC"));
            }
            catch (Exception)
            {
                MessageBox.Show("You can't create this element at this level");
                return false ;
            }

            NewSpec.SetAttribute(DbAttributeInstance.NAME, CeIspecImport);
            NewSpec.SetAttribute(DbAttributeInstance.PURP, "INSU");
            NewSpec.SetAttribute(DbAttributeInstance.TDEF, "NONE");
            NewSpec.SetAttribute(DbAttributeInstance.QUES, "TYPE");
            NewSpec.SetAttribute(DbAttributeInstance.FISSUE, "unset");
            NewSpec.SetAttribute(DbAttributeInstance.FINPUT, "IspecGenerator Addin");

            CreateText();
            CreateMainSelec();
            return true;
        }

        private void CreateText()
        {
            DbTextElement = NewSpec.CreateFirst(DbElementType.GetElementType("TEXT"));
            DbTextElement.SetAttribute(DbAttributeInstance.STEX, "INSUL");

        }

        private void CreateMainSelec()
        {
            MainSele = DbTextElement.CreateAfter(DbElementType.GetElementType("SELE"));
            MainSele.SetAttribute(DbAttributeInstance.QTYPE, "ANY");
            MainSele.SetAttribute(DbAttributeInstance.TANS, "INSU");
            MainSele.SetAttribute(DbAttributeInstance.QUES, "TEMP");
            MainSele.SetAttribute(DbAttributeInstance.TDEF, "NONE");
        }

        internal void CreateSelec(int count, double ans, double maxans)
        {
            Sele = MainSele.Create(count, DbElementType.GetElementType("SELE"));

            Sele.SetAttribute(DbAttributeInstance.QTYPE, "ANY");
            Sele.SetAttribute(DbAttributeInstance.QUES, "PBOR");
            Sele.SetAttribute(DbAttributeInstance.TDEF, "NONE");
            
            
            Sele.SetAttribute(DbAttributeInstance.ANSW, ans);
            Sele.SetAttribute(DbAttributeInstance.MAXA, maxans);
        }

        internal void CreateSpco(int spcoIterator, DbDouble bore)
        {
            Spco = Sele.Create(spcoIterator, DbElementType.GetElementType("SPCO"));
            Spco.SetAttribute(DbAttributeInstance.ANSW, bore);
            Spco.SetAttribute(DbAttributeInstance.MAXA, bore);
        }
    }
}