namespace My_Calc.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using My_Calc.Helpers;
    using My_Calc.Models;

    public class CalcController : Controller
    {
        private const int DefaultX = 3;
        private const int DefaultY = 32;
        private const string DefaultResult = "No data";
        private string dateTime = DateTime.Now.ToString("dd MMMM yyyy  HH:mm:ss");

        public static List<string> Results { get; protected set; } = new List<string>();

        // GET: Calc
        public ActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// Calculate the operation of two integer variables
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return this.View(new CalcModel() { X = DefaultX, Y = DefaultY, Result = DefaultResult });
        }

        /// <summary>
        /// Calculate the operation of two integer variables
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(CalcModel model)
        {
            string result = "No data";

            switch (model.Op)
            {
                case Operation.Add:
                    {
                        result = (model.X + model.Y).ToString();
                        break;
                    }

                case Operation.Deduct:
                    {
                        result = (model.X - model.Y).ToString();
                        break;
                    }

                case Operation.Share:
                    {
                        if (model.Y == 0)
<<<<<<< HEAD
                        {
                            result = "Error! Dividing by zero.";
                        }
=======
                            result = "Error! Dividing by zero.";//todo pn строку - в ресурсы
>>>>>>> aa43406b5f3da7f70ea7b3de7f33e647b8dcf43d
                        else
                        {
                            result = (model.X / model.Y).ToString();
                        }

                        break;
                    }

                case Operation.Multiply:
                    {
                        result = (model.X * model.Y).ToString();
                        break;
                    }
<<<<<<< HEAD
            }           
=======
            }

            string dateTime = DateTime.Now.ToString("dd MMMM yyyy  HH:mm:ss");//todo pn это можно в константу вынести
>>>>>>> aa43406b5f3da7f70ea7b3de7f33e647b8dcf43d
            
            model.Result = string.Format("{0} {1}{3}{2} = {4}\n", this.dateTime, model.X, model.Y, model.Op.DisplayName(), result);

            Results.Add(model.Result);

            return this.View(model);
        }
    }
}