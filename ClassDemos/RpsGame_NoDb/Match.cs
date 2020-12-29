
using System;
using System.Collections.Generic;

namespace RpsGame_NoDb
{
    class Match
    {
        private Guid matchdId = Guid.NewGuid();
        public Guid MatchId {get{return matchdId;}}
        public Player Player1 { get; set; } // always the computer
        public Player Player2 { get; set; } // always the user
        public List<Round> Rounds = new List<Round>();
        private int p1RoundWins { get; set; } // how many rounds has the player won?
        private int p2RoundWins { get; set; }
        private int ties { get; set; }

        //below are methods
        /// <summary>
        /// This is the description of the method called RoundWinner
        /// This method takes an optional Player and increments the number of round wins for that player.
        /// No arguments means a tie.
        /// </summary>
        /// <param name="p"></param>
        public void RoundWinner(Player p = null){
            if(p.PlayerId == Player1.PlayerId){
                p1RoundWins++;
            }
            else if(p.PlayerId == Player2.PlayerId) {
                p2RoundWins++;
            }
            else {
                ties++;
            }
        }
        public Player MatchWinner() {
            if(p1RoundWins  == 2) {
                return Player1;
            } else if(p2RoundWins == 2) {
                return Player2;
            } else {
                return null;
            }
        }
    }
}