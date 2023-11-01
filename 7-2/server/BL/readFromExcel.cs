using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BL
{
  public  class readFromExcel
    {
        public int ReadFromExcel(string path)
        {
            bool possiblePath = path.IndexOfAny(Path.GetInvalidPathChars()) == -1;
            if (possiblePath == false)
                return 0;
            using (var reader = new StreamReader(path, Encoding.UTF8))
            
            {
                //עובר על השורות בקובץ
                for (int i = 0; !reader.EndOfStream; i++)
                {
                    var line = Convert.ToString(reader.ReadLine());
                    var values = line.Split(',');
                    if (i == 0)
                    {

                    }
                    else
                    {
                        //עובר על העמודות בקובץ
                        for (int j = 0; j < values.Length; j++)
                        {
                            //switch (j)
                            //{
                            //    case 0:
                            //        {
                            //            if (values[j] == "")
                            //                j = 6;
                            //            lineToAdd.Number = int.Parse(values[j]);
                            //            break;
                            //        }
                            //    case 1:
                            //        {
                            //            departureToAdd.StationName = values[j];
                            //            break;
                            //        }
                            //    case 2:
                            //        {
                            //            departureToAdd.Id = values[j];
                            //            departureToAdd = departureToAdd.Save();
                            //            break;
                            //        }
                            //    case 3:
                            //        {
                            //            destinationToAdd.StationName = values[j];

                            //            break;
                            //        }
                            //    case 4:
                            //        {
                            //            destinationToAdd.Id = values[j];
                            //            destinationToAdd = destinationToAdd.Save();
                            //            lineToAdd.Departure = departureToAdd;
                            //            lineToAdd.Destination = destinationToAdd;
                            //            lineToAdd = lineToAdd.Save();
                            //            break;
                            //        }
                            //    case 5:
                            //        {
                            //            lineTimeToadd.startTripTime = TimeSpan.Parse(values[j]);
                            //            break;
                            //        }
                            //    case 6:
                            //        {
                            //            lineTimeToadd.endTripTime = TimeSpan.Parse(values[j]);
                            //            lineTimeToadd.line = lineToAdd;
                            //            lineTimeToadd.shift = ShiftTypeModels.getShiftTypeByTime(lineTimeToadd.startTripTime);
                            //            lineTimeToadd.Save();
                            //            break;
                            //        }
                            //    case 7:
                            //        {
                            //            if (values[j] == "")
                            //            {
                            //                j = 12;
                            //            }
                            //            else
                            //            {
                            //                driver.driverID = values[j];
                            //            }
                            //            break;
                            //        }
                            //    case 8:
                            //        {
                            //            driver.driverName = values[j];
                            //            break;
                            //        }
                            //    case 9:
                            //        {
                            //            driver.driverPhone = values[j];
                            //            break;
                            //        }
                            //    case 10:
                            //        {
                            //            driver.driverGmail = values[j];
                            //            break;
                            //        }
                            //    case 11:
                            //        {
                            //            if (values[j] == "כן")
                            //                driver.extraHours = true;
                            //            else
                            //            {
                            //                driver.extraHours = false;
                            //            }
                            //            break;
                            //        }
                            //    case 12:
                            //        {
                            //            driver.preferedShift = ShiftTypeModels.find(int.Parse(values[j]));
                            //            driver.Save();
                            //            break;
                            //        }
                            //}
                        }
                        //departureToAdd = new StationModel();
                        //lineToAdd = new LineModel();
                        //lineTimeToadd = new LineTimeModels();
                        //destinationToAdd = new StationModel();
                        //driver = new DriverModels();
                    }
                }
            }
            return 1;
        }
    }
}
