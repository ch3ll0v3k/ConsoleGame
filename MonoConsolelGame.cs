using System;
using System.Timers;
// :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::


class MonoConsolelGame{

    // =====================================================================
    static Timer aTimer;
    static ConsoleKeyInfo CKI;
    static MainWorld MW;
    static int worldUpdateSpeed = 1000/20;



    // =====================================================================
    static void Main(string[] argv){

        // -----------------------------------------------------------------
        //File FS = new File(); // Red config from user.cnf

        // -----------------------------------------------------------------
        bool allowToRun = false;
        string answ = "";

        while(true){

            Console.Clear();
            _WriteLine("");
            _WriteLine("\t\t|---------------------------------------------------------|");
            _WriteLine("\t\t|               Welcome to Terminal Battle                |");
            _WriteLine("\t\t|---------------------------------------------------------|");
            _WriteLine("\t\t| Init new level (y)                                      |");
            _WriteLine("\t\t| Continue level (c)                                      |");
            _WriteLine("\t\t| Exit (q)                                                |");
            _WriteLine("\t\t|---------------------------------------------------------|\n");

            answ = _ReadLine().ToLower();

            if(answ == "q"){
                break;
            }else if(answ == "y"){
                allowToRun = true;
                break;
            }
        }


        // -----------------------------------------------------------------
        if(allowToRun){
            Updater();
        }
        // -----------------------------------------------------------------

    }
    // =====================================================================
    private static void Updater(){

        // -----------------------------------------------------------------
        int[] fieldSize = {90, 34};
        // -----------------------------------------------------------------
        MW = new MainWorld(fieldSize);
        MW.Init();

        aTimer = new Timer();
        RunTimer();
        // -----------------------------------------------------------------
        while(true){

            //CKI = Console.ReadKey();
            if(!MW.isAlife){
                aTimer.AutoReset = false;
                aTimer.Enabled = false;
                aTimer.Dispose();
                Console.Clear();
                YouLose();
                break;
            }else{
                MW.UpdateUserPos(Console.ReadKey().Key);
            }
        }
        // -----------------------------------------------------------------
    }

    // =====================================================================
    private static void RunTimer(){

        // -----------------------------------------------------------------
        aTimer = new System.Timers.Timer(worldUpdateSpeed); 
        aTimer.Elapsed += UpdateWorldEvent;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
        // -----------------------------------------------------------------

    }

    // =====================================================================
    private static void UpdateWorldEvent(Object source, ElapsedEventArgs e){

        // -----------------------------------------------------------------
        MW.UpdateAllEntitys();
        MW.RedrawWord();
        //_WriteLine("UpdateWorldEvent: called");
        // -----------------------------------------------------------------

    }

    // =====================================================================
    private static void YouLose(){

        // -----------------------------------------------------------------
        _WriteLine("");
        _WriteLine("\t\t|---------------------------------------------------------|");
        _WriteLine("\t\t|---------------------------------------------------------|");
        _WriteLine("\t\t|                       You lose !!!                      |");
        _WriteLine("\t\t|---------------------------------------------------------|");
        _WriteLine("\t\t|---------------------------------------------------------|\n");

        // -----------------------------------------------------------------

    }
    // =====================================================================
    public static int _GetRandom(int A, int B){ 
        Random RND = new Random(); return RND.Next(A, B);
    }
    // =====================================================================
    public static int _ReadInt(){ return int.Parse(Console.ReadLine()); }
    // =====================================================================
    public static string _ReadLine(){ return Console.ReadLine(); }
    // =====================================================================
    public static void _WriteLine(string str){ Console.WriteLine(str); }
    // =====================================================================

}

// :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::