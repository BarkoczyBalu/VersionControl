using Mikroszimulacio.Entities;
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

namespace Mikroszimulacio
{
    public partial class Form1 : Form
    {
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();
        public Form1()
        {
            InitializeComponent();

            Population = GetPopulation(@"D:\Suli\Tananyag\V. félév\IRF\Gyak\7\nép.csv");
            BirthProbabilities = GetBirthProb(@"D:\Suli\Tananyag\V. félév\IRF\Gyak\7\születés.csv");
            DeathProbabilities = GetDeathProb(@"D:\Suli\Tananyag\V. félév\IRF\Gyak\7\halál.csv");
        }

        public List<Person> GetPopulation(string csvpath)
        {
            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    Population.Add(new Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        NumberOfChildren = int.Parse(line[2])
                    });
                }
            }

            return Population;
        }

        public List<BirthProbability> GetBirthProb(string csvpath)
        {
            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    BirthProbabilities.Add(new BirthProbability()
                    {
                        Age = int.Parse(line[0]),
                        NumberOfChildren = int.Parse(line[1]),
                        BProb = int.Parse(line[2])
                    });
                }
            }

            return BirthProbabilities;
        }

        public List<DeathProbability> GetDeathProb(string csvpath)
        {
            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    DeathProbabilities.Add(new DeathProbability()
                    {
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[0]),
                        Age = int.Parse(line[1]),
                        DProb = int.Parse(line[2])
                    });
                }
            }

            return DeathProbabilities;
        }
    }
}
