using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace prjProg6112_ICE_Task_
{
    class Read_WriteDetails : Details
    {
        public string strDisplay = "";

        //Path for textfile
        public string PATH = Path.GetFullPath(@"..\..\..\") + "LuckyWinner.txt";

        //Instantiating a list
        static List<Details> DetailList = new List<Details>();

        //Pushing details to List
        public void PushToListDetails(string PlayerName, string PlayerSurname, string PlayerEmail)
        {
            DetailList.Add(new Read_WriteDetails()
            {
                PlayerName = GetName(),
                PlayerSurName = GetSurname(),
                PlayerEmail = GetEmail(),
            });
        }

        //Saves data to the File
        #region Save & Reading File
        public void SaveToTextFile()
        {
            try
            {
                if (!File.Exists(PATH))
                {
                    using (StreamWriter SW = File.CreateText(PATH))
                    {
                        foreach (var Value in DetailList)
                        {
                            SW.WriteLine("Player Name: " + PlayerName);
                            SW.WriteLine("Player Surame: " + PlayerSurName);
                            SW.WriteLine("Player Email: " + PlayerEmail);
                            SW.Close();//closeing the text file
                        }
                    }
                }
                else
                {
                    using (StreamWriter SW = new StreamWriter(PATH, true))
                    {
                        SW.WriteLine("Player Name: " + PlayerName);
                        SW.WriteLine("Player Surame: " + PlayerSurName);
                        SW.WriteLine("Player Email: " + PlayerEmail);
                        SW.Close();//closeing the text file
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error ocured " + ex.ToString());
            }
        }
        public void DeleteTextFile()
        {
            try
            {
                File.Delete(PATH);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error ocured " + ex.ToString());
            }
        }

        //Reads from the File
        public string ReadFromTextFile()
        {
            if (!File.Exists(PATH))
            {
                using (StreamWriter SW = File.CreateText(PATH))
                {
                    foreach (var Value in DetailList)
                    {
                        SW.WriteLine("Player Name: " + PlayerName);
                        SW.WriteLine("Player Surnname: " + PlayerSurName);
                        SW.WriteLine("Player email: " + PlayerEmail);
                        SW.Close();//closeing the text file
                    }
                }
            }
            strDisplay = "";

            try
            {
                StreamReader SR = new StreamReader(PATH, true);
                
                    strDisplay = SR.ReadToEnd();
                    SR.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error ocured " + ex.ToString());
            }
            return strDisplay;
        }
        #endregion

        //Getters & Setters
        #region Getters & Setters
        public string GetName()
        {
            return PlayerName;
        }
        public string GetSurname()
        {
            return PlayerSurName;
        }
        public string GetEmail()
        {
            return PlayerEmail;
        }
        
        public override void SetName(string strPlayerName)
        {
            PlayerName = strPlayerName;
        }

        public override void SetSurName(string strPlayerSurName)
        {
            PlayerSurName = strPlayerSurName;
        }

        public override void SetEmail(string strPlayerEmail)
        {
            PlayerEmail = strPlayerEmail;
        }
        #endregion
    }
}
