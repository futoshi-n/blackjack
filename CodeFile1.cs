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

            User user = new User();
            Dealer dealer = new Dealer();

            user.Draw(Deck.DrawCard());
            user.Draw(Deck.DrawCard());
            user.Draw(Deck.DrawCard());

            dealer.Draw(Deck.DrawCard());
            dealer.Draw(Deck.DrawCard());
            dealer.Draw(Deck.DrawCard());


            Console.WriteLine(user.Point);            
            Console.WriteLine(user.Burst);

            Console.WriteLine(dealer.Point);
            Console.WriteLine(dealer.Burst);



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
        /// <summary>
        /// カードを引く
        /// </summary>
        /// <returns></returns>
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
    /// <summary>
    /// プレイヤー
    /// </summary>
    class User 
    {
        List<Card> card = new List<Card>();
 
        /// <summary>
        /// 得点
        /// </summary>
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
        /// <summary>
        /// バースト確認
        /// </summary>
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
        /// <summary>
        /// 手札に加える
        /// </summary>
        /// <param name="cards"></param>
        public void Draw(Card cards)
        {
            
            card.Add(cards);
        }
    }
    class Dealer :User
    {

    }
}

