using System;

// :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

public class MainWorld{

    // =====================================================================
    public int fieldSizeX;
    public int fieldSizeY;

    public int userPosX;
    public int userPosY;

    public int enemyPosX;
    public int enemyPosY;

    public string USER_CHR = "#"; 
    public string ENEMY_CHR = "@"; 
    public string EMPTY_CHR = " "; 
    public string SOLID_CHR = "="; 
    //----------------------------------------
    // Filed
    
    public string SOLID_ROW = ""; 

    // =====================================================================
    public MainWorld(int[] fieldSize, int[] userPos){

        // -----------------------------------------------------------------
        fieldSizeX = fieldSize[0];
        fieldSizeY = fieldSize[1];

        userPosX = userPos[0];
        userPosY = userPos[1];

        enemyPosX = _GetRandom(userPosX+10, fieldSizeX-2);
        enemyPosY = _GetRandom(userPosY+10, fieldSizeY-2);
        // -----------------------------------------------------------------
        //_ReadLine();
        // -----------------------------------------------------------------

    }

    // =====================================================================
    public void InitWorld(){

        // -----------------------------------------------------------------
        CreateSolidRow();
        // -----------------------------------------------------------------

    }
    // =====================================================================
    public void UpdateAllEntitys(){

        bool XIs200 = false;
        bool YIs200 = false;
        // -----------------------------------------------------------------            
        if(userPosX < enemyPosX){
            enemyPosX--;
        }else if(userPosX > enemyPosX){
            enemyPosX++;
        }else{
            XIs200 = true;
        }
        // -----------------------------------------------------------------            
        if(userPosY < enemyPosY){
            enemyPosY--;
        }else if(userPosY > enemyPosY){
            enemyPosY++;
        }else{
            XIs200 = true;
        }
        // -----------------------------------------------------------------            
        if(XIs200 && YIs200){
            //aTimer.Dispose();
            Console.WriteLine(" Game Over! \nYou lose");
        }
        // -----------------------------------------------------------------            

    }
    // =====================================================================
    public void UpdateUserPos(ConsoleKey key){

        // -----------------------------------------------------------------            
        switch(key){
            // -----------------------------
            // Movement controls
            case ConsoleKey.LeftArrow: 
                if(userPosX < 1) break; userPosX -= 2; break;

            case ConsoleKey.UpArrow: 
                if(userPosY < 1) break; userPosY--; break;

            case ConsoleKey.RightArrow: 
                if(userPosX > fieldSizeX-3) break; userPosX += 2; break;

            case ConsoleKey.DownArrow: 
                if(userPosY > fieldSizeY-2) break; userPosY++; break;

            // -----------------------------
        }
        // -----------------------------------------------------------------

    }
    // =====================================================================
    public void RedrawWord(){

        // -----------------------------------------------------------------
        Console.Clear();

        Console.WriteLine("|"+SOLID_ROW+"|");
        for(int _Y=0; _Y < fieldSizeY; _Y++){

            string outLine = "";

            for(int _X=0; _X < fieldSizeX; _X++){

                // -----------------------------------------------            
                if(_Y == userPosY && _X == userPosX)
                    outLine += USER_CHR;
                else
                    outLine += EMPTY_CHR;

                // -----------------------------------------------            
                if(_Y == enemyPosY && _X == enemyPosX){ 
                    outLine = outLine.Substring(0, outLine.Length - 1);
                    outLine += ENEMY_CHR;
                }
                
                // -----------------------------------------------            
            }
            Console.WriteLine("|"+outLine+"|");

        }
        Console.WriteLine("|"+SOLID_ROW+"|");
        // -----------------------------------------------------------------
    
    }
    // =====================================================================
    public void CreateSolidRow(){
        
        // -----------------------------------------------------------------
        for(int i=0; i < fieldSizeX; i++){ SOLID_ROW += SOLID_CHR; }
        // -----------------------------------------------------------------

    }

    // =====================================================================
    public int _GetRandom(int A, int B){ 
        Random RND = new Random(); return RND.Next(A, B);
    }
    // =====================================================================
    public int _ReadInt(){ return int.Parse(Console.ReadLine()); }
    // =====================================================================
    public string _ReadLine(){ return Console.ReadLine(); }
    // =====================================================================
    public void _WriteLine(string str){ Console.WriteLine(str); }
    // =====================================================================

}

// :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::