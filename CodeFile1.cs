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

            List<Card> card = new List<Card>();

            Deck d = new Deck();
          //  Console.WriteLine(d.CardNo(23));
           // Console.WriteLine(d.CardMark(23));

            User user = new User();
            // card.Add(d.DrawCard());
            // Console.WriteLine(card[0].NoString);
            // Console.WriteLine(card[0].Mark);
            // Console.ReadLine();
            card.Add(Deck.DrawCard());
            card.Add(Deck.DrawCard());
            card.Add(Deck.DrawCard());
            card.Add(Deck.DrawCard());
            card.Add(Deck.DrawCard());
            card.Add(Deck.DrawCard());
            card.Add(Deck.DrawCard());
            card.Add(Deck.DrawCard());

            user.Draw(card[0]);
            user.Draw(card[1]);
            user.Draw(card[2]);
            user.Draw(card[3]);
            user.Draw(card[4]);
            user.Draw(card[5]);
            user.Draw(card[6]);
            user.Draw(card[7]);


            Console.WriteLine(user.Point);
            
            Console.WriteLine(user.Burst);
            


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

    /// <summary>
    /// カード
    /// </summary>
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
    /// <summary>
    /// 山札
    /// </summary>
    public  class Deck
    {
        public static List<Card> card;
        public Deck()
        {
            string[] marks = new string[] { "ハート", "スペード", "クラブ", "ダイヤ" };

            card = new List<Card>();
            
            foreach (string mark in marks)
            {
                for (int i = 1; i <= 13; i++)
                {
                    card.Add(new Card() { Mark = mark, No = i });
                    
                }
            }
            card = card.OrderBy(a => Guid.NewGuid()).ToList();
        }
        public static Card DrawCard()
        {
            Card c= new Card();
            c = card[0];
            card.RemoveAt(0);
            return c;
        }
        
          public string CardNo(int i)
          {
           return card[i].NoString;
          }
        public string CardMark(int i)
        {
            return card[i].Mark;
        }
    }

    abstract class PlayerBase
    {
        List<Card> card = new List<Card>();
        public List<Card> Card
        {
            get { return card; }
            set { Card = value; }
        
        }
        public int Point 
        {
            get {
                int x=0;
                foreach (Card c in card)
                {
                    x += c.Point;
                }
                return x;
                }
        
        }
        public bool Burst()
        {
            
            int point = 0;
            for (int i=0; i<card.Count; i++)
            {
                point += card[i].Point;
            }
            if(point>21)
                return true;

            return false;

        }

        public abstract void Draw(Card cards);
        
        

    }

    class User 
    {
        List<Card> card = new List<Card>();
        public List<Card> Card
        {
            get { return card; }
            set { Card = value; }

        }
        public int Point
        {
            get
            {
                int x = 0;
                foreach (Card c in card)
                {
                    x += c.Point;
                }
                return x;
            }

        }
        public bool Burst
        {
            get{
                int point = 0;
                for (int i = 0; i < card.Count; i++)
                {
                    point += card[i].Point;
                }
                if (point > 21)
                    return true;

                return false;
            }
        }
        public void Draw(Card cards)
        {
            
            card.Add(cards);
        }
    }
}

