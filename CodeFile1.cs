using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SoloLearn
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("hello");

            Deck d = new Deck();
            // Console.WriteLine(d.card[0].No);
            /*
            Card card =new Card();
            card.No =12;
            Console.WriteLine(card.NoString);
            Console.WriteLine(card.Point );
            */
            Console.ReadLine();
        }
    }
    public class Card
    {
        public string Mark { get; set; }


        public int No { get; set; }


        public string NoString
        {
            get
            {
                switch (No)
                {
                    case 1:
                        {
                            return "A";
                        }
                    case 11:
                        {
                            return "J";
                        }
                    case 12:
                        {
                            return "Q";
                        }
                    case 13:
                        {
                            return "K";
                        }
                }
                return No.ToString();
            }
        }
        public int Point
        {
            get
            {
                switch (No)
                {
                    case 11:
                        {
                            return 10;
                        }
                    case 12:
                        {
                            return 10;
                        }
                    case 13:
                        {
                            return 10;
                        }
                }
                return No;
            }
        }
    }
    public class Deck
    {
        public Deck()
        {
            string[] marks = new string[] { "ハート", "スペード", "クラブ", "ダイヤ" };

            List<Card> card = new List<Card>();

            foreach (string mark in marks)
            {
                for (int i = 1; i <= 13; i++)
                {
                    card.Add(new Card() { Mark = mark, No = i });
                    
                }
            }
        }
       // public Card CardNo(int i)
       // {

           // int t = this.card[i].No;
            //return t;
       // }
    }
}

