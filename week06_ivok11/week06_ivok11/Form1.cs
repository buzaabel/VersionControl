using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using week06_ivok11.Entities;
using week06_ivok11.MnbServiceReference;

namespace week06_ivok11
{
    public partial class Form1 : Form
    {

        BindingList<RateData> RateDatas =new BindingList<RateData>();
       
        public Form1()
        {
            InitializeComponent();
            Kulonresz();           
            dataGridView1.DataSource = RateDatas;
            
        }

        private void Kulonresz()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = "EUR",
                startDate = "2020-01-01",
                endDate = "2020-06-30"
            };

            var response = mnbService.GetExchangeRates(request);
            var result = response.GetExchangeRatesResult;
            var xml = new XmlDocument();
            xml.LoadXml(result);

            foreach (XmlElement element in xml.DocumentElement)
            {
                var rate = new RateData();
                RateDatas.Add(rate);
                rate.Date = DateTime.Parse(element.GetAttribute("date"));
                var childElement = (XmlElement)element.ChildNodes[0];
                rate.Currency = childElement.GetAttribute("curr");
                var unit = decimal.Parse(childElement.GetAttribute("unit"));
                var value = decimal.Parse(childElement.InnerText);
                if (unit != 0)
                    rate.Value = value / unit;
            }

        }

        

       
            
          
        
    }
}
