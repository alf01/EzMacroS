using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using EzMacroS.Conditions;
using EzMacroS.Ivokers;

namespace EzMacroS.Commands
{
    public static class CommandConverter
    {
        public static List<ICommand> ConvertToCommands(List<string> doList, double playspeed, IList<BaseCondition> conditionList)
        {
            var keysConverter = new KeysConverter();

            var resultList = new List<ICommand>();

//            foreach (var action in doList)

            for (var k = 0; k < doList.Count; k++)
            {
                var action = doList[k];
                var c = "_";
                var cmd = action.Split(Convert.ToChar(c));
                if (cmd[0].ToUpper() == "SLEEP")
                {
                    var timeString = cmd[1].ToUpper();

                    int hours;
                    int minutes;
                    int secons;
                    int ms = 0;

                    var processStr = cmd[1];
                    string[] resultStr = null;


                    void innerTimeProcessing(char letter, int time)
                    {
                        if (processStr != null)
                        {
                            resultStr = processStr.ToUpper().Split(letter);
                            if (resultStr.Length > 1)
                            {
                                var x = Convert.ToInt32(resultStr[0]);
                                ms += x * time;
                                if (!string.IsNullOrEmpty(resultStr[1]))
                                {
                                    processStr = resultStr[1];
                                }
                                else
                                {
                                    processStr = null;
                                }
                            }
                            else
                            {
                                //process to next
                                // ms += Convert.ToInt32(resultStr[1]);
                                //  processStr = null;
                            }
                        }
                    }

                    innerTimeProcessing('H', 3600000);
                    innerTimeProcessing('M', 60000);
                    innerTimeProcessing('S', 1000);

                    ////--
                    //if (processStr != null)
                    //{
                    //    resultStr = processStr.ToUpper().Split('H');
                    //    if (resultStr.Length > 1)
                    //    {
                    //        var x = Convert.ToInt32(resultStr[0]);
                    //        ms += x * 3600000;
                    //        if (!string.IsNullOrEmpty(resultStr[1]))
                    //        {
                    //            processStr = resultStr[1];
                    //        }
                    //        else
                    //        {
                    //            processStr = null;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        //process to next
                    //       // ms += Convert.ToInt32(resultStr[1]);
                    //      //  processStr = null;
                    //    }
                    //}
                    ////--
                    ////--
                    //if (processStr != null)
                    //{
                    //    resultStr = processStr.ToUpper().Split('M');
                    //    if (resultStr.Length > 1)
                    //    {
                    //        var x = Convert.ToInt32(resultStr[0]);
                    //        ms += x * 60000;
                    //        if (!string.IsNullOrEmpty(resultStr[1]))
                    //        {
                    //            processStr = resultStr[1];
                    //        }
                    //        else
                    //        {
                    //            processStr = null;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        //process to next
                    //        // ms += Convert.ToInt32(resultStr[1]);
                    //        //  processStr = null;
                    //    }
                    //}
                    ////--
                    ////--
                    //if (processStr != null)
                    //{
                    //    resultStr = processStr.ToUpper().Split('S');
                    //    if (resultStr.Length > 1)
                    //    {
                    //        var x = Convert.ToInt32(resultStr[0]);
                    //        ms += x * 1000;
                    //        if (!string.IsNullOrEmpty(resultStr[1]))
                    //        {
                    //            processStr = resultStr[1];
                    //        }
                    //        else
                    //        {
                    //            processStr = null;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        //process to next
                    //        // ms += Convert.ToInt32(resultStr[1]);
                    //        //  processStr = null;
                    //    }
                    //}
                    ////--
                    ////--
                    if (!string.IsNullOrEmpty(processStr))
                    {                        
                        ms += Convert.ToInt32(processStr);
                    }
                   
                    //--

                    if (cmd.Length < 2)
                    {
                        throw new Exception();
                    }

                    if (playspeed.CompareTo(1) == 0) //double check equals 1
                    {
                        resultList.Add(new SleepCommand(ms));
                    }
                    else
                    {
                        resultList.Add(new SleepCommand(Convert.ToInt32(Math.Round(ms * playspeed))));
                    }
                }
                else if (cmd[0].ToUpper() == "KEY")
                {
                    if (cmd.Length < 3)
                    {
                        throw new Exception();
                    }

                    if (cmd[1].ToUpper() == "DOWN")
                    {
                        resultList.Add(new KeyCommand(true, Convert.ToByte(keysConverter.ConvertFromString(cmd[2]))));
                    }
                    else if (cmd[1].ToUpper() == "UP")
                    {
                        resultList.Add(new KeyCommand(false, Convert.ToByte(keysConverter.ConvertFromString(cmd[2]))));
                    }
                }
                else if (cmd[0].ToUpper() == "MOUSE")
                {
                    if (cmd[1].ToUpper() == "MOVE")
                    {
                        if (cmd.Length < 4)
                        {
                            throw new Exception();
                        }

                        resultList.Add(new MouseMoveCommand(Convert.ToInt32(cmd[2]), Convert.ToInt32(cmd[3])));
                    }
                    else if (cmd[1].ToUpper() == "SLIDE")
                    {
                        resultList.Add(new MouseSlideCommand(Convert.ToInt32(cmd[2]), Convert.ToInt32(cmd[3])));
                    }
                    else if (cmd[1].ToUpper() == "SAVE")
                    {
                        // MousePositionsave = new Point(Cursor.Position.X, Cursor.Position.Y);
                        throw new NotImplementedException();
                    }
                    else if (cmd[1].ToUpper() == "LOAD")
                    {
                        //                    if (MousePositionsave != null)
                        //                    {
                        //                        Cursor.Position = MousePositionsave;
                        //                    }
                        throw new NotImplementedException();
                    }
                    else if (cmd[1].ToUpper() == "LEFT")
                    {
                        if (cmd[2].ToUpper() == "DOWN")
                        {
                            resultList.Add(new MouseKeyCommand(true, MouseKeys.Left));
                        }
                        else if (cmd[2].ToUpper() == "UP")
                        {
                            resultList.Add(new MouseKeyCommand(false, MouseKeys.Left));
                        }
                    }
                    else if (cmd[1].ToUpper() == "RIGHT")
                    {
                        if (cmd[2].ToUpper() == "DOWN")
                        {
                            resultList.Add(new MouseKeyCommand(true, MouseKeys.Right));
                        }
                        else if (cmd[2].ToUpper() == "UP")
                        {
                            resultList.Add(new MouseKeyCommand(false, MouseKeys.Right));
                        }
                    }
                    else if (cmd[1].ToUpper() == "MIDDLE")
                    {
                        if (cmd[2].ToUpper() == "DOWN")
                        {
                            resultList.Add(new MouseKeyCommand(true, MouseKeys.Middle));
                        }
                        else if (cmd[2].ToUpper() == "UP")
                        {
                            resultList.Add(new MouseKeyCommand(false, MouseKeys.Middle));
                        }
                    }
                }
                else if (cmd[0].ToUpper() == "NEXT")
                {
                    if (cmd[2].ToUpper() == "REPEAT")
                    {
                        //                    for (var i = 0; i < Convert.ToInt32(cmd[3]) - 1; i++)
                        //                    {
                        //                        for (var k = 0; k < Convert.ToInt32(cmd[1]); k++)
                        //                        {
                        //                            //Console.Beep(1000, 400);
                        //                            if (Dolist.Count > curindex + k + 1)
                        //                            {
                        //                                DoCommand(Dolist[curindex + k + 1], curindex);
                        //                            }
                        //                        }
                        //                    }
                    }
                }
                else if (cmd[0].ToUpper() == "PRINT")
                {
                    //   var codestring = cmd[1]; //.ToUpper();
                    resultList.Add(new PrintCommand(cmd[1]));
                }

                else if (cmd[0].ToUpper() == "IF")
                {
                  
                   var conditionName = cmd[1];
                   
                   //find end; 
                   int startIndex = k+1;
                   int endIndex = -1;
                   
                   for (int i = startIndex; i < doList.Count; i++)
                   {
                       var ac = doList[i];
                     //  var c = "_";
                       var cmdx = ac.Split(Convert.ToChar(c));
                       if (cmdx[0].ToUpper() == "ENDIF")
                       {
                           if (cmdx[1] == conditionName)
                           {
                               endIndex = i - startIndex;
                               break;
                           }
                       }
                   }

                   if (endIndex > -1)
                   {
                       var sublist = doList.GetRange(startIndex, endIndex);
                       k += endIndex +1 ;

                       var subCommands = ConvertToCommands(sublist, playspeed, conditionList);

                       var globalCondition = conditionList.FirstOrDefault(f => f.ConditionName.ToUpper().Equals(conditionName.ToUpper()));
                       if (globalCondition != null)
                       {
                           resultList.Add(new IfCommand(globalCondition, subCommands));
                       }
                   }
                }
            }

            return resultList;
        }
    }
}