using System;

namespace RpsGame_NoDb
{
    class Player
    {
        public Player(){}
        public Player(string fname, string lname){
            this.Fname = fname;
            this.Lname = lname;
        }
        private Guid playerId = Guid.NewGuid();
        public int PlayerId { 
            get {
                return PlayerId;
            }
        }

        private string fName;
        public string Fname {
            get { return fName; }
            set { 
                if(value is string && value.Length < 20 && value.Length > 0){
                    fName = value; 
                }
                else {
                    throw new Exception("The name you sent is not valid.");
                }
            }
        }
        private string lName;
        public string Lname {
            get { return lName; }
            set { 
                if(value is string && value.Length < 20 && value.Length > 0){
                    lName = value; 
                }
                else {
                    throw new Exception("The name you sent is not valid.");
                }
            }
        }
        

        private int numWins;
        private int numLosses;
        
        public void AddWinn(){
            numWins++;
        }
        public void AddLoss(){
            numLosses++;
        }

        public int[] GetWinLossRecord(){
            int[] winsAndLosses = new int[2]; // create an array to hold the num of wins and losses.
            winsAndLosses[0] = numWins; // put in the wins and losses.
            winsAndLosses[1] = numLosses;
            return winsAndLosses; // return the array.
        }
        
    
    }
}