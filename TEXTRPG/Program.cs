using System.Numerics;
namespace TEXTRPG
{
    

    class Program
    {
      

        static void Main(String[] args)
        {
            GameManager gm = new GameManager();
           
            gm.init();
            int temp = 1;
            while (!GameManager.isGameEnd)
            {
                gm.village();
                int a = -1;
                try
                {
                    a = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input");
                }
                switch (a)
                {
                    case 1:
                        //스테이터스 확인
                        gm.showStat();
                        break;
                    case 2:
                        //인벤토리 관리
                        gm.invenMode();
                       
                        break;
                    case 3:
                        //상점
                        gm.Shopping();
                        
                        break;
                    //던전
                    case 4:
                        gm.DungeonMode();
                        break;
                    //회복
                    case 5:
                        gm.heal();

                        break;
                    case 0:
                        GameManager.isGameEnd = true;
                        break;
                }
                

            }

            if(GameManager.isGameOver)
                gm.gameEnd();
            else
                gm.save();


        }

       


    }
}
