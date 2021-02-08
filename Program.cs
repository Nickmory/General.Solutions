using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GrapePicking
{
    public class CommuncationHelper
    {
       private static  readonly string[] Words = {" gaixare Dzmi! ", " icocxle brat ", "Shemogevle", "sposibo", "kaii chemo dzmao"};

        public static string RandomCommunication()
        {
            var random = new Random();
            var randomNumber = random.Next(0,Words.Length);
            var desiredWord = Words.Take(randomNumber + 1).Last();
            return desiredWord;
        }
    }
    public static class AllWorkMan
    {
        public static List<WorkMan> GetAllWorkMan(params WorkMan[] workMan) => workMan.ToList();
        public static List<int> GetZeroFromToTen(params int[] integers) => integers.ToList();
        public static List<WorkMan> AllWorkMen;
        public  static  List<WorkMan> GetWorkMenWithNoneVedra() => AllWorkMan.AllWorkMen.Where(x => x.IWantVedraaaaaaaaaaaaaaaaaa).ToList();
    }
    public class WorkMansQrepedAmmout
    {
        public WorkMansQrepedAmmout(double grapeAmmount)
        {
            GrapeAmmount = grapeAmmount;
        }
        public double GrapeAmmount { get; }
    }

    public class Man
    { 
        public string Name { get; }
        public string LastName { get; }
        public string WhoIAm() => $"me var {Name} {LastName}";
        public Man(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }
    }
  public class VedroMan : Man
    {
        public VedroMan(string name, string lastName): base(name, lastName)
        {
           
        }
        public async void Support()
        {
            await Task.Run(() =>
            {
                var workMan = AllWorkMan.GetWorkMenWithNoneVedra()
                    .OrderBy(x => x.QuantityMassOfGrapes).LastOrDefault();
                if (workMan == null)
                    return;
                workMan.IWantVedraaaaaaaaaaaaaaaaaa = false;
                var workMansQrepedAmmout = new WorkMansQrepedAmmout(workMan.QuantityMassOfGrapes);
                workMan.WorkMansQrepedAmmouts.Add(workMansQrepedAmmout);
                workMan.ClearGrapes();
                
                Console.WriteLine($"me {WhoIAm()} Inebe Vedraaaaaaaaaa!!!!");
                Console.WriteLine($"{workMan.WhoIAm()}- {CommuncationHelper.RandomCommunication()}");
            });
         
        }
        private int VedroValue { get; }
        private string Name { get; }
    }
    public class DoubleRandomGenerator
    {
        public static double Generate()
        {
            var random = new Random();
            var first = random.Next(1, 9);
            var second = random.Next(1, 9);
            var newValue = $"{first}.{second}";
            var randomNumber = double.Parse(newValue);
            return randomNumber;
        }
    }
    public class WorkMan:Man
    {
        public double Power { get; set; }
        public bool AmResting { get; set; }
        public bool IWantVedraaaaaaaaaaaaaaaaaa { get; set; }
        
        public List<WorkMansQrepedAmmout> WorkMansQrepedAmmouts = new List<WorkMansQrepedAmmout>(); 
        public WorkMan(string name, string lastName):base (name ,lastName)
        {
            Power = 100;
            CurrentGrapes = new List<Grape>();
        }
        public List<Grape> CurrentGrapes { get; private set; }

        public void ClearGrapes() => CurrentGrapes = new List<Grape>();
        public double QuantityMassOfGrapes => CurrentGrapes.Sum(x => x.Mass);
        public double QuantityMassAlreadyQraped => WorkMansQrepedAmmouts.Sum(x => x.GrapeAmmount);

        public double FullAmountOfGrape => QuantityMassOfGrapes + QuantityMassAlreadyQraped;
        
        public void Working()
        {
            if (AmResting)
                Recover();
            else
                GrapePicking();
        }
     
        private async void GrapePicking()
        {
            await Task.Run(() =>
            {
                var sumOfGrapes = QuantityMassOfGrapes;
                if (sumOfGrapes > 50)
                {
                    if (!IWantVedraaaaaaaaaaaaaaaaaa)
                        IWantVedraaaaaaaaaaaaaaaaaa = true;
                    Console.WriteLine($"{WhoIAm()} : Vedraaaaaaaaaaa");
                    Recover(); 
                }
               
                var grape = new Grape(DoubleRandomGenerator.Generate());
                CurrentGrapes.Add(grape);
                Power -= DoubleRandomGenerator.Generate();
                if (!AllWorkMan.GetWorkMenWithNoneVedra().Any())
                {
                    Console.WriteLine($"{WhoIAm()} chemi dakrefili yurdznebis raodenoba aris {QuantityMassOfGrapes}");
                    Console.WriteLine($" {WhoIAm()}Chemi dzala aris  {Power}");
                }
                if (Power < 10)
                    AmResting = true;
            });
        }
        private async void Recover()
        {
            await Task.Run(() =>
            {
                if (Power > 100)
                {
                    AmResting = false;
                    Power = 100;
                    Console.WriteLine($"{WhoIAm()} axlave brat");
                    Console.WriteLine($" {WhoIAm()}Chemi dzala aris  {Power}");
                }

                Power += DoubleRandomGenerator.Generate();
                Console.WriteLine($" {WhoIAm()} visveneb");
            });
        }
    }
    public class Grape
    {
        public Grape(double mass)
        {
            Mass = mass;
        }
        public double Mass { get; }
    }
    internal static class Program
    {
        private static void Main(string[] args)
        {
           var workman1 = new WorkMan("nika ", "morbedadze");
            var workman2 = new WorkMan("rezo ", "mishvelidze");
            // var workman3 = new WorkMan("giorgi", "kvariani");
            // var workman4 = new WorkMan("nika", "dolidze");
            var vedroman1 = new VedroMan("Lue" ,"Surmanva");
            var allWorkMan = AllWorkMan.GetAllWorkMan(workman1, workman2);
            AllWorkMan.AllWorkMen = allWorkMan; 
            var now = DateTime.Now;
            var finalDot = now.AddMinutes(1);
            var logDateTimes = new List<DateTime>();
            while (DateTime.Now <= finalDot)
            {
                Thread.Sleep(4000);
                var internalNow = DateTime.Now;
                if (logDateTimes.Any(x => x.Hour == internalNow.Hour && x.Minute == internalNow.Minute &&
                                          x.Second == internalNow.Second)) continue;
                logDateTimes.Add(internalNow);
                workman1.Working();
                workman2.Working();
                vedroman1.Support();
            }
            var allWorkMen = new List<WorkMan>();
            allWorkMen.AddRange(new[] {workman1, workman2});
            var საპრიზო_ადგილები = მომე_საპრიზო_ადგილები(allWorkMen);
            საპრიზო_ადგილები.ForEach(PrintResult);
            Console.ReadLine();
        }
        static List<საპრიზო_ადგილი> მომე_საპრიზო_ადგილები(List<WorkMan> workMen)
        {
            var საპრიზოადგილები = new List<საპრიზო_ადგილი>();
            var orderedByGrape = workMen.OrderByDescending(x => x.FullAmountOfGrape);
            var count = 1;
            foreach (var workMan in orderedByGrape)
            {
                var საპრიზოადგილი = new საპრიზო_ადგილი(workMan, count);
                საპრიზოადგილები.Add(საპრიზოადგილი);
                count++;
            }
            return საპრიზოადგილები;
        }
        private static void PrintResult(საპრიზო_ადგილი საპრიზო_ადგილი)
        {
            var workman1Sum = საპრიზო_ადგილი.WorkMan.FullAmountOfGrape;
            Console.WriteLine(
                $"{საპრიზო_ადგილი.PrizePlace}).{საპრიზო_ადგილი.WorkMan.WhoIAm()} chemi dakrefili yurdznebis Raodenoba sabolood aris {workman1Sum}");
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public class საპრიზო_ადგილი
        {
            public საპრიზო_ადგილი(WorkMan workMan, int prizePlace)
            {
                WorkMan = workMan;
                PrizePlace = prizePlace;
            }
            public WorkMan WorkMan { get; }
            public int PrizePlace { get; }
        }
    }
}


   

