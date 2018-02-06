using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            string address = @"http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";
            string xml;
            var client = new WebClient();

            xml = client.DownloadString(address);
            File.WriteAllText(@"..\..\blah.xml", xml);
            VypisKurz();

            Console.ReadKey();
        }

        private static void VypisKurz()
        {
            XmlReader xmlReader = XmlReader.Create(@"..\..\blah.xml");
            while (xmlReader.Read())
            {
                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "Cube"))
                {
                    if (xmlReader.HasAttributes)
                        Console.WriteLine(xmlReader.GetAttribute("currency") + " -- " + xmlReader.GetAttribute("rate"));
                }
            }
        }
    }
}
