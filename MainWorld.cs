using System;

// :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

public class MainWorld{

    // =====================================================================
    // User
    public int fieldSizeX;
    public int fieldSizeY;

    public int userPosX;
    public int userPosY;

    public float ballPosX;
    public float ballPosY;

    public float BALL_SPEED = 1.0F; //0.25F;

    //----------------------------------------
    // Filed
    public string SOLID_ROW = ""; 
    public string DRAWER;

    public string USER_CHR = "##########"; 
    public int USER_CHR_TOP_OFFSET = 5; 

    public string BALL_CHR = "@"; 
    public string EMPTY_CHR = " "; 
    public string SOLID_CHR = "="; 
    public string COL_SYM = "|"; 


    //----------------------------------------
    public bool isAlife = true;
    public bool XIs200 = false;
    public bool YIs200 = false;

    //----------------------------------------
    // 0 == NO MOVEMENT in eny direction of 'X' or 'Y'
    // '-1' == UP for 'Y' or LEFT for 'X'
    // '+1' == DOWN for 'Y' or RIGHT for 'X'

    private int _VecX = 1; 
    private int _VecY = -1; 

    //----------------------------------------

    // =====================================================================
    public MainWorld(int[] fieldSize){

        // -----------------------------------------------------------------
        fieldSizeX = fieldSize[0];
        fieldSizeY = fieldSize[1];

        userPosX = ( (fieldSizeX/2)-(USER_CHR.Length/2) );
        userPosY = ( (fieldSizeY - USER_CHR_TOP_OFFSET) );

        ballPosX = ( (fieldSizeX/2)-(USER_CHR.Length/2) );
        ballPosY = userPosY + 2;
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

        XIs200 = false;
        YIs200 = false;
        // -----------------------------------------------------------------            
        // _Vector X movement
        if(_VecX < 0){

            ballPosX--;
            if(ballPosX < 1)
                _VecX = 1;

        }else if(_VecX > 0){

            ballPosX++;
            if(ballPosX > fieldSizeX-1)
                _VecX = -1;
        
        } //else{ // No movement increase or decrease }
        // --------------------------
        // _Vector Y movement
        if(_VecY < 0){

            ballPosY--;
            if(ballPosY < 1)
                _VecY = 1;

        }else if(_VecY > 0){

            ballPosY++;
            if(ballPosY > fieldSizeY-1)
                _VecY = -1;
        
        } //else{ // No movement increase or decrease }



        // ballPosY +=
        // XIs200 = true;
        // -----------------------------------------------------------------            
        /*
        if(XIs200 && YIs200){
            //aTimer.Dispose();
            Console.WriteLine(" Game Over! \nYou lose");
        }
        */
        // -----------------------------------------------------------------            

    }
    // =====================================================================
    public void UpdateUserPos(ConsoleKey key){

        // -----------------------------------------------------------------            
        switch(key){
            // -----------------------------
            // Movement controls
            case ConsoleKey.LeftArrow: if(userPosX < USER_CHR.Length+1) break; userPosX -= 2; break;
            //case ConsoleKey.UpArrow: if(userPosY < 1) break; userPosY--; break;
            case ConsoleKey.RightArrow: if(userPosX > fieldSizeX-3) break; userPosX += 2; break;
            //case ConsoleKey.DownArrow: if(userPosY > fieldSizeY-2) break; userPosY++; break;
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
                if(_Y == userPosY && _X == userPosX){
                    DRAWER = DRAWER.Substring(0, DRAWER.Length - USER_CHR.Length+1);
                    DRAWER += USER_CHR;
                }else
                    DRAWER += EMPTY_CHR;

                // -----------------------------------------------            
                if(_Y == ballPosY && _X == ballPosX){ 
                    DRAWER = DRAWER.Substring(0, DRAWER.Length - 1);
                    DRAWER += BALL_CHR;
                }
                // -----------------------------------------------            
                // Check for collision
                if(_Y == ballPosY && _X == ballPosX && _Y == userPosY && _X == userPosX){ 
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