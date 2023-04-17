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
            using var reader = new StreamReader(filename);
            var serializer = new XmlSerializer(typeof(ObservableCollection<Debtor>));
            return (ObservableCollection<Debtor>)serializer.Deserialize(reader);
        }

        public static void SaveFile(string filename, ObservableCollection<Debtor> debtors)
        {
            using var writer = new StreamWriter(filename);
            var serializer = new XmlSerializer(typeof(ObservableCollection<Debtor>));
            serializer.Serialize(writer, debtors);

        }

    }
}
