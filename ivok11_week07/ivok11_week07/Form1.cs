using ivok11_week07.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ivok11_week07
{
    public partial class Form1 : Form
    {
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();
        public Form1()
        {
            InitializeComponent();
            Population = GetPopulation(@"C:\Temp\nép.csv");
            BirthProbabilities = GetBP(@"C:\Temp\születés.csv");
            DeathProbabilities = GetDP(@"C:\Temp\halál.csv");
            dataGridView1.DataSource = BirthProbabilities;
        }
        public List<Person> GetPopulation(string csvpath)
        {
            List<Person> population = new List<Person>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        NbrOfChildren = int.Parse(line[2])
                    });
                }
            }

            return population;
        }



        public List<BirthProbability> GetBP(string csvpath)
        {
            List<BirthProbability> BProbability = new List<BirthProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    BProbability.Add(new BirthProbability()
                    {
                        Age= int.Parse(line[0]),

                        NbrOfChildren = int.Parse(line[1]),
                        
                        Probability = double.Parse(line[2])
                    });
                }
            }

            return BProbability;
           
        }


        public List<DeathProbability> GetDP(string csvpath)
        {
            List<DeathProbability> DProbability = new List<DeathProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    DProbability.Add(new DeathProbability()
                    {
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[0]),

                        Age = int.Parse(line[1]),                       

                        Probability = double.Parse(line[2])
                    });
                }
            }

            return DProbability;
        }
    }
}
