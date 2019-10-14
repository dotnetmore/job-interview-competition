using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            var VsegoProdano = SingletonGlobalProdano.GetInstance();

            BaseOfProduct baseOfProduct = new BaseOfProduct(10,10,10,10);
            Console.WriteLine(baseOfProduct);


            baseOfProduct.Prodaga(); 
            BaseHistory @base = new BaseHistory();

            @base.History.Push(baseOfProduct.SaveState());

            baseOfProduct.Prodaga(); 

            baseOfProduct.RestoreState(@base.History.Pop());

            baseOfProduct.Prodaga(); 

            Console.WriteLine(VsegoProdano);

            baseOfProduct.Prodaga();
            baseOfProduct.Prodaga();

            Console.WriteLine(baseOfProduct);

            Console.Read();
        }
    }

    // Originator
    class BaseOfProduct
    {
        public int Meat { get; private set;}
        public int Apelsin { get; private set; }
        public int Banan { get; private set; }
        public int Klubnika { get; private set; }

        public BaseOfProduct(int meat, int apelsin, int banan, int klubnika)
        {
            this.Meat = meat;
            this.Apelsin = apelsin;
            this.Banan = banan;
            this.Klubnika = klubnika;
        }

        public void Prodaga()
        {
            var VsegoProdano = SingletonGlobalProdano.GetInstance();

            Console.WriteLine($"\n Продаем все по 1 шт:");
            if (Meat > 0)
            {
                Meat--;
                VsegoProdano.ProdaliMeat++;
                Console.WriteLine("Продали Мясо.Осталось-{0}", Meat);
            }
            else
                Console.WriteLine("Мяса больше нет");

            if (Apelsin > 0)
            {
                Apelsin--;
                VsegoProdano.ProdaliApelsin++;
                Console.WriteLine("Продали Апельсин.Осталось-{0}", Apelsin);
            }
            else
                Console.WriteLine("Апельсин больше нет");

            if (Banan > 0)
            {
                Banan--;
                VsegoProdano.ProdaliBanan++;
                Console.WriteLine("Продали Banan.Осталось-{0}", Banan);
            }
            else
                Console.WriteLine("Banan больше нет");

            if (Klubnika > 0)
            {
                Klubnika--;
                VsegoProdano.ProdaliKlubnika++;
                Console.WriteLine("Продали Klubnika.Осталось-{0}", Klubnika);
            }
            else
                Console.WriteLine("Klubnika больше нет");

            Console.WriteLine();
        }
        // сохранение состояния
        public BasaOfProductMemento SaveState()
        {
            Console.WriteLine($"Сохранение состава Базы. Meat:{Meat} , Apelsin: {Apelsin} , Banan: {Banan} , Klubnika: {Klubnika} ");
            return new BasaOfProductMemento(Meat, Apelsin, Banan, Klubnika);
        }

        // восстановление состояния
        public void RestoreState(BasaOfProductMemento ProductMemento)
        {
            this.Meat = ProductMemento.Meat;
            this.Apelsin = ProductMemento.Apelsin;
            this.Banan = ProductMemento.Banan;
            this.Klubnika = ProductMemento.Klubnika;

            Console.WriteLine($"Восстановление Бфзы. Meat:{Meat} , Apelsin: {Apelsin} , Banan: {Banan} , Klubnika: {Klubnika}");
        }

        public override string ToString()
        {
            return $"Сейчас на Базе:\t\t\t  Meat:{Meat} , Apelsin: {Apelsin} , Banan: {Banan}, Klubnika: {Klubnika}";
        }
    }

    // Memento
    class BasaOfProductMemento
    {
        public int Meat { get; private set; }
        public int Apelsin { get; private set; }
        public int Banan { get; private set; }
        public int Klubnika { get; private set; }

        public BasaOfProductMemento(int meat, int apelsin, int banan, int klubnika)
        {
            this.Meat = meat;
            this.Apelsin = apelsin;
            this.Banan = banan;
            this.Klubnika = klubnika;
        }
    }

    // Caretaker
    class BaseHistory
    {
        public Stack<BasaOfProductMemento> History { get; private set; }
        public BaseHistory()
        {
            History = new Stack<BasaOfProductMemento>();
        }
    }

    public class SingletonGlobalProdano
    {
        private static readonly Lazy<SingletonGlobalProdano> lazy =
            new Lazy<SingletonGlobalProdano>(() => new SingletonGlobalProdano());

        public int ProdaliMeat { get;  set; }
        public int ProdaliApelsin { get;  set; }
        public int ProdaliBanan { get;  set; }
        public int ProdaliKlubnika { get;  set; }

        private SingletonGlobalProdano()
        {
        }

        public static SingletonGlobalProdano GetInstance()
        {
            return lazy.Value;
        }

        public override string ToString()
        {
            return $"Всего продали: ProdaliMeat={ProdaliMeat}, ProdaliApelsin={ProdaliApelsin}, ProdaliBanan={ProdaliBanan}, ProdaliKlubnika={ProdaliKlubnika}";
        }
    }
}
