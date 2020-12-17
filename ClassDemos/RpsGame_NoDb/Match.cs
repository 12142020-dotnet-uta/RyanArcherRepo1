
using System;
using System.Collections.Generic;

namespace RpsGame_NoDb
{
    class Match
    {
        private Guid matchdId = new Guid();
        public Guid MatchId {get{return matchdId;}}
        public Player Player1 { get; set; } // always the computer
        public Player Player2 { get; set; } // always the user
        List<Round> Rounds = new List<Round>();
        private int p1RoundWins { get; set; }
        private int p2RoundWins { get; set; }
        private int ties { get; set; }
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