
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TicTacToe
{
	[Activity (Label = "Game")]			
	public class Game : Activity
	{
		private int turn = 0;
		private bool playerOne = false; // This variable determines if player One wins.
		private bool playerTwo = false; // This variable determines if player Two wins.
		private bool draw = false; // This variable determines if its a draw.
		private int [,] Record = new int[3,3]; // An array that records the movements in-game.

		void dbg ( String msg )
		{
			var MsgBox = new AlertDialog.Builder (this);
			MsgBox.SetMessage (msg);
			MsgBox.SetNegativeButton ("OK", delegate {} );
			MsgBox.Show ();
		}

		void checkVictory ()
		{

			// Variable 'i' stands for row
			for (int i = 0; i < 3; i++) {
				// Variable 'c' stands for column
				// Check for a horizontal victory
				for (int c = 0; c < 3; c++) {
					if (Record [i, c] == turn) {
						// Continue
					} else {
						break;
					}

					// If we're at the last column
					if (c == 2) {
						if (turn == 1) {
							playerOne = true;
							break;
						} else {
							playerTwo = true;
							break;
						}
					}
				}
			}

			// Variable 'c' stands for column
			for (int c = 0; c < 3; c++) {
				// Variable 'r' stands for row
				for (int r = 0; r < 3; r++) {
					if (Record [r, c] == turn) {
						// Continue
					} else {
						break;
					}

					// If we're at the last row
					if (r == 2) {
						if (turn == 1) {
							playerOne = true;
							break;
						} else {
							playerTwo = true;
							break;
						}
					}
				}
			}

			// Variable 'c' represents column
			// Check for a diagonal victory.
			for (int c = 0; c < 3; c++) {
				if (Record [c, c] == turn) {
					// Continue
				} else {
					break;
				}

				// If we're at the last column
				if (c == 2) {
					if (turn == 1) {
						playerOne = true;
						break;
					} else {
						playerTwo = true;
						break;
					}
				}
			}

			for (int c = 0; c < 3; c++) {
				if (Record [c, 2 - c] == turn) {
					// Continue
				} else {
					break;
				}

				// If we're at the last column
				if (c == 2) {
					if (turn == 1) {
						playerOne = true;
						break;
					} else {
						playerTwo = true;
						break;
					}
				}
			}

			for (int r = 0; r < 3; r++) {
				for (int c = 0; c < 3; c++) {
					if (Record [r, c] != 0) {
						// Continue
					}
					else {
						r = 3;
						break;
					}

					if ((r == 2) &&
						(c == 2))
						draw = true;
				}
			}

			// Display the result
			if ( (playerOne == true) ||
				(playerTwo == true) ||
				(draw == true ) ) {
				var MsgBox = new AlertDialog.Builder (this);

				if (playerOne == true)
					MsgBox.SetMessage ("Player one wins.");
				else if (playerTwo == true)
					MsgBox.SetMessage ("Player two wins.");
				else if (draw == true)
					MsgBox.SetMessage ("Its a draw!");

				MsgBox.SetNegativeButton ("Reset", delegate {
					// Reset the activity
					Finish ();
					StartActivity ( typeof ( Game ) );
				} );

				MsgBox.Show ();
			}
		}

		void changeButton ( Button but, int column, int row )
		{
			// Update board
			if (Record [row, column] == 0) {
				Record [row, column] = turn;

				// Check for a victory
				checkVictory ();

				// Swap turns
				if (turn == 1) {
					but.Text = "X";
					turn = 2;
				} else if ( turn == 2 ) {
					but.Text = "O";
					turn = 1;
				}
			} else {
				dbg ("Please pick an empty slot.");
			}
		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Display the window
			SetContentView (Resource.Layout.Game);

			// Reset variables
			draw = false;
			playerOne = false;
			playerTwo = false;
			turn = 1;

			// Resources
			Button Button4 = FindViewById <Button> (Resource.Id.Button4);
			Button Button6 = FindViewById <Button> (Resource.Id.Button6);

			// Tic-Tac-Toe Buttons.
			Button C1R1 = FindViewById <Button> (Resource.Id.C1R1);
			Button C2R1 = FindViewById <Button> (Resource.Id.C2R1);
			Button C3R1 = FindViewById <Button> (Resource.Id.C3R1);
			Button C1R2 = FindViewById <Button> (Resource.Id.C1R2);
			Button C2R2 = FindViewById <Button> (Resource.Id.C2R2);
			Button C3R2 = FindViewById <Button> (Resource.Id.C3R2);
			Button C1R3 = FindViewById <Button> (Resource.Id.C1R3);
			Button C2R3 = FindViewById <Button> (Resource.Id.C2R3);
			Button C3R3 = FindViewById <Button> (Resource.Id.C3R3);

			// Resource CallBacks
			Button4.Click += delegate {
				StartActivity (typeof(MainActivity));
				Finish ();
			};
			Button6.Click += delegate {
				Finish ();
				StartActivity (typeof(Game));
			};

			// Tic-Tac-Toe Resources.
			C1R1.Click += delegate {
				changeButton (C1R1, 0, 0);
			};
			C2R1.Click += delegate {
				changeButton (C2R1, 1, 0);
			};
			C3R1.Click += delegate {
				changeButton (C3R1, 2, 0);
			};
			C1R2.Click += delegate {
				changeButton (C1R2, 0, 1);
			};
			C2R2.Click += delegate {
				changeButton (C2R2, 1, 1);
			};
			C3R2.Click += delegate {
				changeButton (C3R2, 2, 1);
			};
			C1R3.Click += delegate {
				changeButton (C1R3, 0, 2);
			};
			C2R3.Click += delegate {
				changeButton (C2R3, 1, 2);
			};
			C3R3.Click += delegate {
				changeButton (C3R3, 2, 2);
			};
		}
	}
}

