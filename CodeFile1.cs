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

            Game game = new Game();




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

   /* abstract class PlayerBase
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
        
        

    }*/

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
            Console.WriteLine("あなたの引いたカードは{0}の{1}です。",cards.Mark,cards.NoString);
            card.Add(cards);
        }
    }
    class Dealer :User
    {
        List<Card> card = new List<Card>();
        /// <summary>
        /// 手札に加える
        /// </summary>
        /// <param name="cards"></param>
        public void Draw(int i, Card cards)
        {
            if (i == 0)
                Console.WriteLine("ディーラーの引いたカードは{0}の{1}です。", cards.Mark, cards.NoString);
            else if (i == 1)
                Console.WriteLine("ディーラーの二枚目のカードはわかりません。");
            card.Add(cards);
        }

    }
    /// <summary>
    /// ゲーム
    /// </summary>
    class Game
    {
        Deck d = new Deck();
        User user = new User();
        Dealer dealer = new Dealer();
        public Game()
        {
            Console.WriteLine("ブラックジャックをはじめます。");
            Console.ReadLine();



            for (int i = 0; i < 2; i++)
                user.Draw(Deck.DrawCard());

            dealer.Draw(0, Deck.DrawCard());
            dealer.Draw(1, Deck.DrawCard());

            DeckQ();

        }

        public void DeckQ()
        {

            UserPoint();
            Console.WriteLine("カードを引きますか？引く場合はYを、引かない場合はNを入力してください。");
            string c = Console.ReadLine();
        }

        public void UserPoint()
        {
            Console.WriteLine("あなたの現在の得点は{0}です。", user.Point);

            if (user.Burst)
                Console.WriteLine("ディーラーの勝ちです");
        }
        
    }
}

