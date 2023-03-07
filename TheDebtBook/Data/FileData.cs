using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TheDebtBook.Models;

namespace TheDebtBook.Data
{
    public class FileData
    {
        public static ObservableCollection<Debtor> ReadFile(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Debtor));
            TextReader reader = new StreamReader(filename);

            var debtors = (ObservableCollection<Debtor>)serializer.Deserialize(reader);
            reader.Close();
            return debtors;
        }

        public static void SaveFile(string filename, ObservableCollection<Debtor> debtors)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Debtor));
            TextWriter writer = new StreamWriter(filename);

            serializer.Serialize(writer, debtors);
            writer.Close();
        }
    }
}
