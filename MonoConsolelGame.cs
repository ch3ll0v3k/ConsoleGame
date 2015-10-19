using System;
using System.Timers;
// :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::


class MonoConsolelGame{

    // =====================================================================
    static Timer aTimer;
    static ConsoleKeyInfo CKI;
    static MainWorld MW;
    static int worldUpdateSpeed = 45;
    // =====================================================================
    static void Main(string[] argv){

        // -----------------------------------------------------------------
        int[] userPos = {10, 10};
        int[] fieldSize = {90, 30};
        // -----------------------------------------------------------------
        MW = new MainWorld(fieldSize, userPos);
        MW.InitWorld();

        aTimer = new Timer();
        RunTimer();
        // -----------------------------------------------------------------
        while(true){

            CKI = Console.ReadKey();
            MW.UpdateUserPos(CKI.Key);

        }
        // -----------------------------------------------------------------
        //_ReadLine();
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
        MW.RedrawWord();
        //_WriteLine("UpdateWorldEvent: called");
        // -----------------------------------------------------------------

    }

    // =====================================================================
    public static string GetSpaces(int offset){
        
        // -----------------------------------------------------------------
        string output = "";

        for(int i=0; i<offset; i++){
            output += " ";
        }
        return output;
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