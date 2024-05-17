﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class Bishop : Piece
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        /// <param name="c"></param>
        public Bishop(Color color, int id) : base(color, id)
        {
        }

        public override bool CanMove(int x, int y, int x2, int y2)
        {
            if (Math.Abs(x - x2) != Math.Abs(y - y2))
            {
                throw new InvalidOperationException("Invalid move for Bishop");
            }

            if (x2 < 0 || x2 > 7 || y2 < 0 || y2 > 7)
            {
                throw new InvalidOperationException("Invalid move for Bishop: destination out of bounds.");
            }

            return true;    
        }

        public override List<Case> PossibleMoves(Case caseInitial, Chessboard chessboard)
        {
            if (chessboard == null || caseInitial == null)
            {
                throw new ArgumentNullException();
            }

            List<Case> possibleMoves = new List<Case>();
            (int colInc, int lineInc)[] directions = { (-1, 1), (1, 1), (-1, -1), (1, -1) }; // Top Left, Top Right, Bot Left, Bot Right
    
            foreach (var (colInc, lineInc) in directions)
            {
                for (int i = 1; i < 8; i++)
                {
                    int newColumn = caseInitial.Column + (colInc * i);
                    int newLine = caseInitial.Line + (lineInc * i);
            
                    if (!IsWithinBoardBoundaries(newColumn, newLine))
                    {
                        break;
                    }

                    Case potentialCase = chessboard.Board[newColumn, newLine];
                    if (newColumn >= 0 && newColumn < 8 && newLine >= 0 && newLine < 8)
                    {
                        if (CanMove(caseInitial.Column, caseInitial.Line, newColumn, newLine))
                        {
                            if (!potentialCase.IsCaseEmpty() && potentialCase.Piece.Color != this.Color)
                            {
                                possibleMoves.Add(potentialCase);
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return possibleMoves;
        }

        private bool IsWithinBoardBoundaries(int column, int line)
        {
            return column >= 0 && column < 8 && line >= 0 && line < 8;
        }

        private void AddPotentialMove(List<Case> possibleMoves, Case potentialCase)
        {
            if (!potentialCase.IsCaseEmpty() && potentialCase.Piece.Color != this.Color)
            {
                possibleMoves.Add(potentialCase);
            }
        }
    }
}