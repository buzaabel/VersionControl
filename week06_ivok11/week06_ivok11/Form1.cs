using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            harmasfeladat();
            dataGridView1.DataSource = RateDatas;
            
        }

        public void harmasfeladat()
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
        }
    }
}
