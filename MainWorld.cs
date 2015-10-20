using System;

// :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

public class MainWorld{

    // =====================================================================
    // User
    public int fieldSizeX;
    public int fieldSizeY;

    public int userPosX;
    public int userPosY;

    public float enemyPosX;
    public float enemyPosY;

    public float ENEMY_SPEED = 1.0F; //0.25F;

    //----------------------------------------
    // Filed
    public string SOLID_ROW = ""; 
    public string DRAWER;

    public string USER_CHR = "#"; 
    public string ENEMY_CHR = "@"; 
    public string EMPTY_CHR = " "; 
    public string SOLID_CHR = "="; 
    public string COL_SYM = "|"; 

    public bool isAlife = true;
    //----------------------------------------

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
    public void Init(){

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
            enemyPosX -= ENEMY_SPEED;
        }else if(userPosX > enemyPosX){
            enemyPosX += ENEMY_SPEED;
        }else{
            XIs200 = true;
        }
        // -----------------------------------------------------------------            
        if(userPosY < enemyPosY){
            enemyPosY -= ENEMY_SPEED;
        }else if(userPosY > enemyPosY){
            enemyPosY += ENEMY_SPEED;
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

        Console.WriteLine(COL_SYM+SOLID_ROW+COL_SYM);
        for(int _Y=0; _Y < fieldSizeY; _Y++){

            DRAWER = "";

            for(int _X=0; _X < fieldSizeX; _X++){

                // -----------------------------------------------            
                if(_Y == userPosY && _X == userPosX)
                    DRAWER += USER_CHR;
                else
                    DRAWER += EMPTY_CHR;

                // -----------------------------------------------            
                if(_Y == enemyPosY && _X == enemyPosX){ 
                    DRAWER = DRAWER.Substring(0, DRAWER.Length - 1);
                    DRAWER += ENEMY_CHR;
                }
                // -----------------------------------------------            
                // Check for collision

                if(_Y == enemyPosY && _X == enemyPosX && _Y == userPosY && _X == userPosX){ 
                    isAlife = false;
                }
                // -----------------------------------------------            
            }
            Console.WriteLine(COL_SYM+DRAWER+COL_SYM);

        }
        Console.WriteLine(COL_SYM+SOLID_ROW+COL_SYM);
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